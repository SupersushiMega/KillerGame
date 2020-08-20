using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("AAH, I HIT SOMETHING!");
    }
}
