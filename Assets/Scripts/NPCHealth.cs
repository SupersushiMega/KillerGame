using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCHealth : MonoBehaviour
{
    public Rigidbody RigidBody;
    public NavMeshAgent agent;

    public float MaxHealth = 100f;

    public float Health;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        RigidBody.isKinematic = true;
        agent.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            RigidBody.isKinematic = false;
            agent.enabled = false;
        }
    }
    public void Damage(float Amount)
    {
        Health -= Amount;
    }
}
