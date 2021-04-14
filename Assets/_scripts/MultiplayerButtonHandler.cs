using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultiplayerButtonHandler : MonoBehaviour {

    public Button singleButton;
    public Button multiButton;
    public Button minus;
    public Button plus;
    public Text numText;
    public Color greyedText;

    private int numPlayers = 4;

    //public Color disabledColor;
    //public Color abledColor;

	// Use this for initialization
	void Start () {
        singleButton.interactable = true;
        multiButton.interactable = false;
        numText.text = numPlayers.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void singlePressed()
    {
        singleButton.interactable = false;
        multiButton.interactable = true;

        minus.interactable = false;
        plus.interactable = false;
        numText.color = greyedText;
    }

    public void multiPressed()
    {
        singleButton.interactable = true;
        multiButton.interactable = false;

        minus.interactable = true;
        plus.interactable = true;
        numText.color = Color.black;

        if (numPlayers <= 2)
        {
            numPlayers = 2;
            numText.text = numPlayers.ToString();
            minus.interactable = false;
        }
        /**
        ColorBlock cbOn = onButton.colors;
        cbOn.normalColor = disabledColor;
        offButton.colors = cbOn;

        ColorBlock cbOff = offButton.colors;
        cbOff.normalColor = abledColor;
        offButton.colors = cbOff;
        */
    }

    public void minusPressed()
    {
        numPlayers--;
        if (numPlayers <= 2)
        {
            numPlayers = 2;
            minus.interactable = false;
        }
        numText.text = numPlayers.ToString();
    }

    public void plusPressed()
    {
        numPlayers++;
        if (numPlayers > 2)
        {
            minus.interactable = true;
        }
        numText.text = numPlayers.ToString();
    }

    public int getPlayers()
    {
        return numPlayers;
    }

    public void setPlayers(int newPLayers)
    {
        numPlayers = newPLayers;
        numText.text = numPlayers.ToString();
    }
}
