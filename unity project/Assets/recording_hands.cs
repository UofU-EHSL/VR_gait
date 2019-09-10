using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recording_hands : MonoBehaviour
{
    public Toggle toggle;
    public GameObject leftHand;
    public GameObject rightHand;

    public void toggle_hands()
    {
        if (toggle.GetComponent<Toggle>().isOn == true)
        {
            leftHand.SetActive(true);
            rightHand.SetActive(true);
        }
        else
        {
            leftHand.SetActive(false);
            rightHand.SetActive(false);
        }
    }
}
