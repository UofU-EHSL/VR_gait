using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicElevator : MonoBehaviour
{
    public float NewHeight;
    public bool MovePlatform;

    // Start is called before the first frame update
    void Start()
    {
        NewHeight = 15.0f;
        MovePlatform = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (MovePlatform)
        {
            Debug.Log("I Was Here, new height is : "+ NewHeight.ToString());
            gameObject.transform.position.Set(0, NewHeight, 0); 
            MovePlatform = false;
        }
    }
}
