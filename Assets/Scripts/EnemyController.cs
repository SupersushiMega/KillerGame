using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    public float lookRadius = 10f;
    public Vector2 MinMaxTargetChangeDelay;

    float delay;
    bool HasTarget = true;
    GameObject[] TargetPosibilities;
    Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        TargetPosibilities = GameObject.FindGameObjectsWithTag("Target");
        agent = GetComponent<NavMeshAgent>();
        target = TargetPosibilities[Random.Range(0, TargetPosibilities.Length)].transform;
        agent.SetDestination(target.position);
    }

    // Update is called once per frame
    void Update()
    {
        /*while (HasTarget == false && target.position.x == transform.position.x && target.position.z == transform.position.z)
        {
            
        }*/

        if (target.position.x == transform.position.x && target.position.z == transform.position.z && HasTarget == true)
        {
            HasTarget = false;
            delay = Random.Range(MinMaxTargetChangeDelay.x, MinMaxTargetChangeDelay.y);
            Debug.Log(delay);
            Invoke("TargetChange", delay);
        }
    }

    void TargetChange()
    {
        target = TargetPosibilities[Random.Range(0, TargetPosibilities.Length)].transform;
        agent.SetDestination(target.position);
        HasTarget = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
