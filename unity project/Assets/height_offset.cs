using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class height_offset : MonoBehaviour
{
    public float height;
    public GameObject footObject;
    public Slider slider;

    public void heightOffset()
    {
        height = slider.value;
        footObject.transform.localPosition = new Vector3(height, 0, 0);
    }

}
