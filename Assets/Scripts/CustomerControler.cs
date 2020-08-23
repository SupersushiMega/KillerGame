using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CustomerControler : MonoBehaviour
{
    public NPCHealth Health;

    public float StandardSpeed = 6f;
    public float PanicSpeed = 20f;

    public float StandardAcceleration = 8f;
    public float PanicAcceleration = 24f;

    public float lookRadius = 10f;

    GameObject Target;
    Vector3 Spawn;

    float panic;

    CustomerManager Manager;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        panic = 0;
        Spawn = transform.position;
        Manager = transform.parent.GetComponent<CustomerManager>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Health.Health > 0)
        {
            if (panic > 0)
            {
                panic -= 10 * Time.deltaTime;
                agent.speed = PanicSpeed;
                agent.acceleration = PanicAcceleration;
            }

            else
            {
                agent.speed = StandardSpeed;
                agent.acceleration = StandardAcceleration;
                if (!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance) || panic < 0)
                {
                    panic = 0;
                    if (Target != null)
                    {
                        Target.GetComponent<WaypointAttributes>().isOccupied = false;
                    }
                    Manager.AskForDestination(gameObject);
                }
            }
        }
    }
    public void Panic(Vector3 Position)
    {
        float distance = Vector3.Distance(Position, transform.position);
        if (distance <= lookRadius)
        {
            Target.GetComponent<WaypointAttributes>().isOccupied = false;
            panic = 100;
            agent.SetDestination(transform.parent.position);
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
