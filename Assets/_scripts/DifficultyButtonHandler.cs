using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonHandler : MonoBehaviour {

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    public Button noneButton;

    // Use this for initialization
    void Start () {
        noneButton.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void onEasy()
    {
        easyButton.interactable = false;
        mediumButton.interactable = true;
        hardButton.interactable = true;
        noneButton.interactable = true;
    }

    public void onMedium()
    {
        easyButton.interactable = true;
        mediumButton.interactable = false;
        hardButton.interactable = true;
        noneButton.interactable = true;
    }

    public void onHard()
    {
        easyButton.interactable = true;
        mediumButton.interactable = true;
        hardButton.interactable = false;
        noneButton.interactable = true;
    }

    public void onNone()
    {
        easyButton.interactable = true;
        mediumButton.interactable = true;
        hardButton.interactable = true;
        noneButton.interactable = false;
    }
}
