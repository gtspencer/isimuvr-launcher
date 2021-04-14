using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRTK.Examples;

public class PrefabButton : MonoBehaviour {

    public Button button;
    public Image gameImage;
    public Text gameName;

    public UI_Interactions interactions;

	// Use this for initialization
	void Start () {
        button.onClick.AddListener(HandleClick);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Setup()
    {
        
    }

    public void HandleClick()
    {
        interactions.gameSelected();
    }
}
