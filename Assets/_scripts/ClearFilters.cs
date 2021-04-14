using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearFilters : MonoBehaviour {

    public Button clear;
    public GenreButtonHandler genreButtons;
    public MultiplayerButtonHandler multiButtons;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void clearF()
    {
        genreButtons.onAll();
        multiButtons.setPlayers(4);
        multiButtons.multiPressed();
    }
}
