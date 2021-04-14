using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRTK
{
    public class ControllerSpawnerTracker : MonoBehaviour
    {

        public GameObject cont;
        private Vector3 local;

        // Use this for initialization
        void Start()
        {
            local = cont.transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (Vector3.Distance(local, cont.transform.position) > 5 && !cont.GetComponent<VRTK_InteractableObject>().IsGrabbed())
            {
                cont.transform.position = local;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Ground" && !cont.GetComponent<VRTK_InteractableObject>().IsGrabbed())
            {
                cont.transform.position = local;
            }
        }
    }

}