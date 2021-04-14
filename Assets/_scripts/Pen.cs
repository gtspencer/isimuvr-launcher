using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Pen : VRTK_InteractableObject {

	public WhiteBoard whiteboard;
	private RaycastHit touch;
	public GameObject tipObj;
	private float tipHeight;
	private Vector3 tip;
	private Quaternion lastAngle;
	public Color penColor = Color.blue;

	private bool lastTouch;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		tipHeight = tipObj.transform.localScale.y;
		tip = tipObj.transform.position;
		//Debug.Log (tipHeight);

		if (Physics.Raycast (tip, transform.up, out touch, tipHeight)) {
			if (!(touch.collider.tag == "WhiteBoard"))
				return;
			
			this.whiteboard = touch.collider.GetComponent<WhiteBoard> ();
			//VRTK_ControllerHaptics.TriggerHapticPulse (GetGrabbingObject(), 1.0f);

			this.whiteboard.SetColor (penColor);
			this.whiteboard.SetTouchPosition (touch.textureCoord.x, touch.textureCoord.y);
			this.whiteboard.ToggleTouch (true);
			//Debug.Log ("touching!");

			if (!lastTouch) {
				lastTouch = true;
				lastAngle = transform.rotation;
			}
		} else {
			this.whiteboard.ToggleTouch (false);
			lastTouch = false;
		}

		if (lastTouch) {
			transform.rotation = lastAngle;
		}
	}

	public override void Grabbed(GameObject grabbingObject) {
		base.Grabbed (grabbingObject);

	}
}
