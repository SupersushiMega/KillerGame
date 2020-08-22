using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeachTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach(Transform child in transform)
        {
            Debug.Log("Success");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
