using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Furniture
{

}

public class BuildingMode : MonoBehaviour
{
    public Transform PlayerCam;
    public GameObject[] Shelf = new GameObject[2];

    private GameObject shelf;
    Vector3 PreviewPos;
    Vector3 Origin;
    Vector3 Rotation;

    // Start is called before the first frame update
    void Start()
    {
        Origin = new Vector3(0, -100, 0);
        shelf = Instantiate(Shelf[0], transform);
        shelf.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit Hit;
        Origin = PlayerCam.position;
        Rotation = PlayerCam.TransformDirection(Vector3.forward);
        if (Physics.Raycast(Origin, Rotation, out Hit, 50f))
        {
            if (Hit.collider.gameObject.tag == "ShopFloor")
            {
                shelf.SetActive(true);
                PreviewPos = Hit.point;
                PreviewPos.y = shelf[1];
                shelf.transform.position = PreviewPos;
            }
        }

        else
        {
            shelf.SetActive(false);
        }
    }
}
