using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public Transform WaypointsParent;
    public GameObject Customer;

    public Vector2Int CustomerSpawnMinMax;

    private int Amount;

    List<GameObject> Customers = new List<GameObject>();
    List<GameObject> Waypoints = new List<GameObject>();

    // Start is called before the first frame update

    void Start()
    {
        getWaypoints();
        Amount = Random.Range(CustomerSpawnMinMax.x, CustomerSpawnMinMax.y);
    }

    public void Update()
    {
        if (Customers.Count < Amount)
        {
            SpawnCustomers(1);
        }
    }

    public void Panic(Vector3 Position)
    {
        foreach (GameObject Customer in Customers)
        {
            Customer.GetComponent<CustomerControler>().Panic(Position);
        }
    }

    public void AskForDestination(GameObject Controler)
    {
        if (Waypoints.Count > 0)
        {
            GameObject target = Waypoints[Random.Range(0, Waypoints.Count)];
            if (!target.GetComponent<WaypointAttributes>().isOccupied == true || true)
            {
                target.GetComponent<WaypointAttributes>().isOccupied = true;
                Controler.GetComponent<CustomerControler>().TargetChange(target);
            }
        }
    }
    public void Destroy(GameObject customer)
    {
        Customers.Remove(customer);
    }

    public void SpawnCustomers(int Customercount)
    {
        Debug.Log("Spawn");
        int i;
        for (i = 0; i <= Customercount; i++)
        {
            Customers.Add(Instantiate(Customer, transform));
        }
    }

    public void getWaypoints()
    {
        Waypoints.Clear();
        foreach (Transform child in WaypointsParent)
        {
            foreach (Transform child2 in child)
            {
                if (child2.CompareTag("Target"))
                {
                    Waypoints.Add(child2.gameObject);
                }
            }
        }
    }
}
