using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyScript : Photon.MonoBehaviour {

    public GameObject left;
    public GameObject right;

	//Not really the place for this but it's so small
	//Needed so only your avatar is transmitting, not every spawned one
	void Start() {
		if (photonView.isMine) {
			GetComponent<PhotonVoiceRecorder> ().enabled = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (photonView.isMine)
        {
            transform.rotation = VRTK.VRTK_DeviceFinder.DeviceTransform(VRTK.VRTK_DeviceFinder.Devices.Headset).rotation;
            transform.position = VRTK.VRTK_DeviceFinder.DeviceTransform(VRTK.VRTK_DeviceFinder.Devices.Headset).position;

            left.transform.rotation = VRTK.VRTK_DeviceFinder.DeviceTransform(VRTK.VRTK_DeviceFinder.Devices.LeftController).rotation;
            left.transform.position = VRTK.VRTK_DeviceFinder.DeviceTransform(VRTK.VRTK_DeviceFinder.Devices.LeftController).position;

            right.transform.rotation = VRTK.VRTK_DeviceFinder.DeviceTransform(VRTK.VRTK_DeviceFinder.Devices.RightController).rotation;
            right.transform.position = VRTK.VRTK_DeviceFinder.DeviceTransform(VRTK.VRTK_DeviceFinder.Devices.RightController).position;

        }
    }
}
