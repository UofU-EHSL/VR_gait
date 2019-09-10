using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foot_calculation : MonoBehaviour
{
	public GameObject foot;
    
	public foot_calculation()
	{
		foot.transform.localPosition = new Vector3(foot.transform.localPosition.x + this.gameObject.transform.position.x,foot.transform.localPosition.y,foot.transform.localPosition.z);
	}
}
