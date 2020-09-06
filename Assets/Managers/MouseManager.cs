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
            
        }

        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
