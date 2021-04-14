using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeScrollBar : MonoBehaviour {

    public Scrollbar bar;
    public float diff = 0.1f;
    public Button up;
    public Button down;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (bar.value <= 0)
        {
            down.interactable = false;
        } else
        {
            down.interactable = true;
        }
        if (bar.value >= 1)
        {
            up.interactable = false;
        } else
        {
            up.interactable = true;
        }
	}

    public void goUp()
    {
        if (!(bar.value - diff > 1))
        {
            bar.value = bar.value + diff;
        } else
        {
            bar.value = 1;
        }
    }

    public void goDown()
    {
        if (!(bar.value - diff < 0)) {
            bar.value = bar.value - diff;
        } else
        {
            bar.value = 0;
        }
    }
}
