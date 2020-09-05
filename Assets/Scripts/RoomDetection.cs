using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoomDetection : MonoBehaviour
{
    public GameObject Wall;
    public Vector2 ListPos;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("ShopFloor"))
        {
            Wall.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ShopFloor"))
        {
            Wall.SetActive(true);
        }
    }
}
