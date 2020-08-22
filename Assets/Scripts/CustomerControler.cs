using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerControler : MonoBehaviour
{
    GameObject Target;
    public float lookRadius = 10f;

    CustomerManager Manager;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        Manager = transform.parent.GetComponent<CustomerManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance))
        {
            if (Target != null)
            {
                Target.GetComponent<WaypointAttributes>().isOccupied = false;
            }
            Manager.AskForDestination(gameObject);
        }
    }

    public void TargetChange(GameObject target)
    {
        Target = target;
        agent.SetDestination(target.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
