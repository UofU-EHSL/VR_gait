using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class circle : MonoBehaviour
{
    //verticies
    List<Vector3> verticiesList = new List<Vector3> { };
    float x;
    float y;
    for (int i = 0; i<n; i ++)


// Start is called before the first frame update
void Start()
    {
        {
            x = radius * Mathf.Sin((2 * Mathf.PI * i) / n);
            y = radius * Mathf.Cos((2 * Mathf.PI * i) / n);
            verticiesList.Add(new Vector3(x, y, 0f));
        }
        Vector3[] verticies = verticiesList.ToArray();

        //triangles
        List<int> trianglesList = new List<int> { };
    for (int i = 0; i < (n - 2); i++)
    {
        trianglesList.Add(0);
        trianglesList.Add(i + 1);
        trianglesList.Add(i + 2);
    }
    int[] triangles = trianglesList.ToArray();
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
