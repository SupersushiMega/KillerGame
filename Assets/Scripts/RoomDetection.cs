using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomDetection : MonoBehaviour
{
    public GameObject Wall;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ShopFloor")
        {
            
            Wall.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ShopFloor")
        {
            Wall.SetActive(true);
        }
    }
}
