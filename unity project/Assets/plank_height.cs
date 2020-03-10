using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plank_height : MonoBehaviour
{
    public GameObject Elevator;
    public Slider slider;
    public Text realText;
    public string text;
    public GameObject plank;

    public void updateOnSlider()
    {
        plank = Elevator.transform.GetChild(Elevator.transform.childCount -1).transform.gameObject;
        plank.transform.position = new Vector3(0,slider.value/1000,0);
        realText.text = text + slider.value.ToString() + "mm";
    }
}
