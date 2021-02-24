using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    public Text text;
    public string StartRecording;
    public string StopRecording;

    public void toggle()
    {
        if (text.text == StartRecording)
        {
            text.text = StopRecording;
        }
        else
        {
            text.text = StartRecording;
        }
    }
}
