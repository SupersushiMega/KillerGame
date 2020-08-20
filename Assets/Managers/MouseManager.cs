using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public bool CursorLock = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            CursorLock = !CursorLock;
        }

        if (CursorLock == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }

        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
