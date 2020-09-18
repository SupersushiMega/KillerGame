using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

[System.Serializable]
public class Furniture
{
    public GameObject PreviewModel;
    public GameObject PlaceModel;
    public float yOffset;

    public Furniture()
    {

    }
}


public class BuildingMode : MonoBehaviour
{
    public Transform PlayerCam;
    public Transform WaypointParent;

    public CustomerManager customerManager;

    public Furniture[] furniture;

    public byte CurrentSelection = 0;

    List<GameObject> FurnitureInstances;

    public UInt16 MouseWheelSensitivity = 1000;

    GameObject tmp;

    Vector3 PreviewRot;
    Vector3 PreviewPos;
    Vector3 Origin;
    Vector3 Rotation;
    

    // Start is called before the first frame update
    void Start()
    {
        FurnitureInstances = new List<GameObject>();
        Origin = new Vector3(0f, -100f, 0f);
        PreviewRot = new Vector3(-90, 0, 0);
        foreach (Furniture i in furniture)
        {
            tmp = Instantiate(i.PreviewModel, transform);
            FurnitureInstances.Add(tmp);
            tmp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        Origin = PlayerCam.position;
        Rotation = PlayerCam.TransformDirection(Vector3.forward);
        PreviewRot.z += Input.mouseScrollDelta.y * MouseWheelSensitivity * Time.deltaTime;
        if (Physics.Raycast(Origin, Rotation, out Hit, 50f))
        {
            if (Hit.collider.gameObject.tag == "ShopFloor")
            {
                FurnitureInstances[CurrentSelection].SetActive(true);
                PreviewPos = Hit.point;
                PreviewPos.y = furniture[CurrentSelection].yOffset;
                FurnitureInstances[CurrentSelection].transform.position = PreviewPos;
                FurnitureInstances[CurrentSelection].transform.rotation = Quaternion.Euler(PreviewRot);
                if (Input.GetButtonDown("Fire1"))
                {
                    tmp = Instantiate(furniture[CurrentSelection].PlaceModel);
                    tmp.transform.position = PreviewPos;
                    tmp.transform.rotation = Quaternion.Euler(PreviewRot);
                    tmp.transform.parent = WaypointParent;
                    customerManager.getWaypoints();
                }
            }

            else
            {
                FurnitureInstances[CurrentSelection].SetActive(false);
            }
        }
    }
}
