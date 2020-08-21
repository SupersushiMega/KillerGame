using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAttributes : MonoBehaviour
{
    public bool isOccupied;

    void ChangeStatus(bool Status)
    {
        isOccupied = Status;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, transform.localScale);
    }
}
