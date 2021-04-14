using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.IO.Pipes;
using System.Text;
using System.Security.Principal;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

public class ClientPipe : MonoBehaviour {

    private string[] argu;
    public TextMesh text;
    private static int numClients = 4;

    private Thread pipeThread;

    private void Awake()
    {
        argu = Environment.GetCommandLineArgs();
        text.text = "Argument: ";
        for (int i = 0; i < argu.Length; i++)
        {
            text.text = text.text + argu[i] + "\n";
        }
        //text.text += "I'm getting called";
        //StartClients();
        //Thread t = new Thread(new ThreadStart(ConnectPipe));
        //t.Start();
        pipeThread = new Thread(ServerThread);
        pipeThread.Start();
        //ConnectPipe();
    }

    private void ServerThread()//pipe server thread
    {
        NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("testpipe", PipeDirection.InOut, 1);

        text.text += "\nWait For Client";
        pipeServer.WaitForConnection();
        text.text += "\nClient connected ";

        /*
		// these code use to tansfer pictue size, here we use default size
		pipeServer.WriteByte ((byte)(width / 256));
		pipeServer.WriteByte ((byte)(width & 255));
		pipeServer.WriteByte ((byte)(height / 256));
		pipeServer.WriteByte ((byte)(height & 255));
		pipeServer.Flush ();
		*/
        while (pipeServer.IsConnected)
        {
            StreamString ss = new StreamString(pipeServer);
            ss.WriteString("test");
            //pipeServer.Flush();

            text.text += ss.ReadString();
            Thread.Sleep(500);
        }
        pipeServer.Close();
    }

    private void ConnectPipe()
    {
        text.text += "\nMe too";
        try
        {
            NamedPipeClientStream pipeIn = new NamedPipeClientStream(".", "toLauncher", PipeDirection.In);
            NamedPipeClientStream pipeOut = new NamedPipeClientStream(".", "toListener", PipeDirection.Out);
            
            text.text = text.text + "Connecting to server...\n";
            //pipeOut.Connect();
            pipeIn.Connect();
            pipeOut.Connect();

            StreamString ssIn = new StreamString(pipeIn);
            StreamString ssOut = new StreamString(pipeOut);

            
           
            

            //ssOut.WriteString("Vien still sucks");
            //ssOut.WriteString("Vien still sucks again");

            // Validate the server's signature string
            //listenPipe(ssIn, ssOut);
            while (true)
            {
                text.text += ssIn.ReadString();
            }
            /*if (ssIn.ReadString() == "I am the one true server!")
            {
                // The client security token is sent with the first write.
                // Send the name of the file whose contents are returned
                // by the server.
                //ssOut.WriteString("c:\\textfile.txt");

                // Print the file to the screen.
                text.text += ssIn.ReadString();

                //ssOut.WriteString("Vien still sucks");
                //StartCoroutine(wait());
                //ssOut.WriteString("Vien still sucks again");
            }
            else
            {
                Console.WriteLine("Server could not be verified.");
            }*/
        } catch (Exception ex)
        {
            text.text += ex;
        }

        /**
        StreamString ss = new StreamString(pipeClient);
        // Validate the server's signature string
        if (ss.ReadString() == "I am the one true server!")
        {
            // The client security token is sent with the first write.
            // Send the name of the file whose contents are returned
            // by the server.
            ss.WriteString("c:\\textfile.txt");

            // Print the file to the screen.
            Console.Write(ss.ReadString());
        }
        else
        {
            Console.WriteLine("Server could not be verified.");
        }
        */
    }

    async void listenPipe(StreamString ssIn, StreamString ssOut)
    {
        await Task.Run(() =>
        {
            //ssIn.ReadString();
            text.text += ssIn.ReadString();
            text.text += "test";
            //ssOut.WriteString("another");
        });
        //listenPipe(ssIn, ssOut);
        //await newData = ss.ReadString();


    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
    }

    // Helper function to create pipe client processes
    private void StartClients()
    {
        int i;
        string currentProcessName = Environment.CommandLine;
        Process[] plist = new Process[numClients];

        text.text = text.text + "Spawning client processes...\n";

        if (currentProcessName.Contains(Environment.CurrentDirectory))
        {
            currentProcessName = currentProcessName.Replace(Environment.CurrentDirectory, String.Empty);
        }

        // Remove extra characters when launched from Visual Studio
        currentProcessName = currentProcessName.Replace("\\", String.Empty);
        currentProcessName = currentProcessName.Replace("\"", String.Empty);

        for (i = 0; i < numClients; i++)
        {
            // Start 'this' program but spawn a named pipe client.
            plist[i] = Process.Start(currentProcessName, "spawnclient");
        }
        while (i > 0)
        {
            for (int j = 0; j < numClients; j++)
            {
                if (plist[j] != null)
                {
                    if (plist[j].HasExited)
                    {
                        text.text = text.text + "Client process[{0}] has exited." + 
                            plist[j].Id;
                        plist[j] = null;
                        i--;    // decrement the process watch count
                    }
                    else
                    {
                        Thread.Sleep(250);
                    }
                }
            }
        }
        text.text += "\nClient processes finished, exiting.";
    }



    /** From stackoverflow
    void communicatePipe()
    {
        //Create Client Instance
        NamedPipeClientStream client = new NamedPipeClientStream(".", "MyCOMApp",
                   PipeDirection.InOut, PipeOptions.None,
                   TokenImpersonationLevel.Impersonation);

        //Connect to server
        client.Connect();
        //Created stream for reading and writing
        StreamString clientStream = new StreamString(client);
        //Read from Server
        string dataFromServer = clientStream.ReadString();
        UnityEngine.Debug.Log("Received from Server: " + dataFromServer);
        //Send Message to Server
        clientStream.WriteString("Bye from client");
        //Close client
        client.Close();
    }
    */
}

// Defines the data protocol for reading and writing strings on our stream
public class StreamString
{
    private Stream ioStream;
    private UnicodeEncoding streamEncoding;

    public StreamString(Stream ioStream)
    {
        this.ioStream = ioStream;
        streamEncoding = new UnicodeEncoding();
    }

    public string ReadString()
    {
        int len;
        len = ioStream.ReadByte() * 256;
        //len += ioStream.ReadByte();
        byte[] inBuffer = new byte[len];
        ioStream.Read(inBuffer, 0, len);

        return streamEncoding.GetString(inBuffer);
    }

    public int WriteString(string outString)
    {
        byte[] outBuffer = streamEncoding.GetBytes(outString);
        int len = outBuffer.Length;
        if (len > UInt16.MaxValue)
        {
            len = (int)UInt16.MaxValue;
        }
        ioStream.WriteByte((byte)(len / 256));
        ioStream.WriteByte((byte)(len & 255));
        ioStream.Write(outBuffer, 0, len);
        ioStream.Flush();

        return outBuffer.Length + 2;
    }
}