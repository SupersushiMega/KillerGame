using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAttributes : MonoBehaviour
{
    public GameObject moneyParticle;

    public Shelf shelf;
    public bool isOccupied = false;

   private void OnTriggerEnter(Collider other)
    {
        CustomerControler Enter = other.gameObject.GetComponent<CustomerControler>();
        if (Enter != null)
        {
            shelf.TakeCupcake();
            GameObject Mp = Instantiate(moneyParticle, other.transform);
            Destroy(Mp, 10f);
            Enter.GoHome();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        isOccupied = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isOccupied = false;
    }
}
