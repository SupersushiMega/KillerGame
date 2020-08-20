using JetBrains.Annotations;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public MouseManager mouseManager;
    public Transform Camera;
    public Transform Player;
    public Vector3 Offset;
    public int Sensitivity = 1000;
    public bool InvertMouseY = false;
    public bool InvertMouseX = false;
    
    Vector3 RotTmp;
    float RotX;
    float RotY;

    // Update is called once per frame
    void Update()
    {
        RotX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        RotY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        RotTmp = Camera.eulerAngles;

        //===============================================================
        if (mouseManager.CursorLock)
        {
            if (InvertMouseY)
            {
                RotTmp.y = RotTmp.y - RotX;
            }
            else
            {
                RotTmp.y = RotTmp.y + RotX;
            }

            //===============================================================

            if (InvertMouseX)
            {
                RotTmp.x = RotTmp.x + RotY;
            }
            else
            {
                RotTmp.x = RotTmp.x - RotY;
            }

            //===============================================================

            if (RotTmp.x > 90 && RotTmp.x < 270)
            {
                RotTmp.x = Camera.eulerAngles.x;
            }

            Camera.eulerAngles = RotTmp;
        }

        Camera.position = Player.position + Offset;

    }
}
