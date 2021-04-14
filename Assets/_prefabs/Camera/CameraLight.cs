using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLight : MonoBehaviour {
    public Color on = Color.red;
    public Color off = Color.white;
    public float duration = 1f;
    private bool onFlag;
    private bool changing;
	public bool tset;

    private Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.material.color = on;
        onFlag = true;
        changing = false;
    }

    // Update is called once per frame
    void Update () {
        if (!changing)
        {
			StartCoroutine(changeColor());
        }
    }

    private void setOn() {
        rend.material.color = on;
        onFlag = true;
    }

	private void setOff() {
        rend.material.color = off;
        onFlag = false;
    }

    private IEnumerator changeColor()
    {
        changing = true;
        if (onFlag)
        {
            setOff();
        } else
        {
            setOn();
        }
		yield return new WaitForSeconds (duration);
        changing = false;
    }
}
