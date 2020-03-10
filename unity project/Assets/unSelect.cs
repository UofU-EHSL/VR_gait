using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class unSelect : MonoBehaviour
{
    public void UnSelect()
    {
        foreach (Transform child in transform)
        {
            if (child.gameObject.GetComponent<Image>()) {
                child.gameObject.GetComponent<Image>().enabled = false;
            }
        }
    }
}
