using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementNonRB : MonoBehaviour
{
    public float Sensitivity = 100f;
    public Transform Body;
    float Rotx = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;
        Rotx -= mouseY;

        Rotx = Mathf.Clamp(Rotx, -90f, 90f);

        transform.localRotation = Quaternion.Euler(Rotx, 0f, 0f);
        Body.Rotate(Vector3.up * mouseX);
    }
}
