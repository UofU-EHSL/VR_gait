using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class form : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Button>().onClick.Invoke();
    }
}
