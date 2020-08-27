using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAttributes : MonoBehaviour
{

    public Shelf shelf;
    public bool isOccupied = false;

    void ChangeStatus(bool Status)
    {
        isOccupied = Status;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }

   private void OnTriggerEnter(Collider other)
    {
        CustomerControler Enter = other.gameObject.GetComponent<CustomerControler>();
        if (Enter != null)
        {
            shelf.TakeCupcake();
        }
    }
}
