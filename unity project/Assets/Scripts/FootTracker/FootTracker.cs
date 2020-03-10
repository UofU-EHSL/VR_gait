using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

namespace VRGait.FootTracker
{

	//[RequireComponent(typeof(SteamVR_TrackedObject))]
	public class FootTracker : MonoBehaviour
	{

		public GameObject foot;
        public Material green;
        public Material red;
        public GameObject tempFoot;
        public GameObject dataRecorder;
        public int recorder_index;
        public Slider slider;
        public Vector3 init_location;
        private bool set = false;
        public GameObject child_foot;
        public GameObject[] allPossibleTrackers;
        public void Start()
        {
            init_location = gameObject.transform.localPosition;
        }
        public void Update()
        {
            if (set == true) {
                //transform.Translate(Vector3.up * slider.value, Space.World);
                child_foot.gameObject.transform.localPosition = new Vector3(0,slider.value/10,0);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<SteamVR_TrackedObject>())
            {
                tempFoot = other.gameObject;
                tempFoot.GetComponent<MeshRenderer>().material = green;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            tempFoot.GetComponent<MeshRenderer>().material = red;
        }
        public void setFeet()
        {
            set = true;
            init_location = gameObject.transform.localPosition;
            foot.transform.SetParent(tempFoot.transform);
            tempFoot.name = gameObject.name;
            tempFoot.GetComponent<MeshRenderer>().enabled = false;
            foreach (GameObject tracker in allPossibleTrackers)
            {
                tracker.GetComponent<MeshRenderer>().enabled = false;
            }
            //dataRecorder.GetComponent<VRGait.Data.DataRecorder>().trackGameObjects[recorder_index] = tempFoot;
        }
	}
}