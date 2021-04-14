using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
    public class ControllerTips : MonoBehaviour
    {

        public VRTK_InteractableObject controllerScript;
        public GameObject text;

        // Update is called once per frame
        void Update()
        {
            if (controllerScript.IsTouched())
            {
                text.SetActive(true);
            } else
            {
                text.SetActive(false);
            }
        }
    }

}
