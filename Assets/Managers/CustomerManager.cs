using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public Transform WaypointsParent;
    public GameObject Customer;

    public Vector2Int CustomerSpawnMinMax;

    List<GameObject> Customers = new List<GameObject>();
    List<GameObject> Waypoints = new List<GameObject>();

    // Start is called before the first frame update

    void Start()
    {
        SpawnCustomers();

        foreach (Transform child in WaypointsParent)
        {
            foreach (Transform child2 in child)
            {
                if (child2.tag == "Target")
                {
                    Waypoints.Add(child2.gameObject);
                }
            }
        }
    }

    public void Update()
    {
        if (Customers.Count == 0)
        {
            SpawnCustomers();
        }
    }

    public void Panic(Vector3 Position)
    {
        foreach (GameObject Customer in Customers)
        {
            Customer.GetComponent<CustomerControler>().Panic(Position);
        }
    }

    // Update is called once per frame
    public void AskForDestination(GameObject Controler)
    {
        GameObject target = Waypoints[Random.Range(0, Waypoints.Count)];
        if (!target.GetComponent<WaypointAttributes>().isOccupied == true || true)
        {
            target.GetComponent<WaypointAttributes>().isOccupied = true;
            Controler.GetComponent<CustomerControler>().TargetChange(target);
        }
    }
    public void Destroy(GameObject customer)
    {
        Customers.Remove(customer);
    }

    public void SpawnCustomers()
    {
        Debug.Log("Spawn");
        int Customercount = Random.Range(CustomerSpawnMinMax.x, CustomerSpawnMinMax.y);
        int i;
        for (i = 0; i <= Customercount; i++)
        {
            Instantiate(Customer, transform);
        }
        foreach (Transform child in transform)
        {
            Debug.Log("hello2");
            Customers.Add(child.gameObject);
        }
    }
}
