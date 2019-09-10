using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Valve.VR
{
    public class tracker_changer : MonoBehaviour
    {
        public Dropdown dropdown;
        public SteamVR_TrackedObject footObject;
    // Start is called before the first frame update
    void Start()
        {

        }
        public void change()
        {
            footObject.SetDeviceIndex(dropdown.value);
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}