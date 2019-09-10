using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class subject_ID_int : MonoBehaviour
{
    public int subjectID;
    public TextMeshProUGUI Subject_field;

    public void click()
    {
        PlayerPrefs.SetInt("Subject", subjectID++);
    }
    // Start is called before the first frame update
    void Start()
    {
        Subject_field.text = subjectID.ToString();
        subjectID = PlayerPrefs.GetInt("subject");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
