using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour {

    public int numButtons;
    public List<GameObject> buttons;
    public bool updated = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!updated)
        {
            if (numButtons <= buttons.Count)
            {
                for (int i = 0; i < numButtons; i++)
                {
                    buttons[i].SetActive(true);
                }
                for (int i = numButtons; i < buttons.Count; i++)
                {
                    buttons[i].SetActive(false);
                }
                updated = true;
            }
        }
	}
}
