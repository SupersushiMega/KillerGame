using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShopManager : MonoBehaviour
{

    public Transform ShopEntrance;
    public GameObject StandartRoom;

    public ushort SizeX = 10;
    public ushort SizeY = 10;

    public float RoomScale = 16;

    private byte[,] RoomMap;
    

    // Start is called before the first frame update
    void Start()
    {
        RoomMap = new byte[SizeX, SizeY];
        ushort X;
        ushort Y;
        for (X = 0; X < SizeX; X++)
        {

            for (Y = 0; Y < SizeY; Y++)
            {
                RoomMap[X, Y] = 1;
            }
        }
        UpdateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateGrid()
    {
        Vector3 Offset;
        ushort X;
        ushort Y;
        for (X = 0; X < SizeX; X++)
        {
            for (Y = 0; Y < SizeY; Y++)
            {
                Debug.Log(X);
                if (RoomMap[X, Y] == 1)
                {
                    Offset = new Vector3(RoomScale * (X - (SizeX / 2)), 0, RoomScale * (Y - (Y / 2)));
                    Debug.Log((X / 2) - X);
                    if (Offset != new Vector3(0, 0, 0))
                    {
                        GameObject tmp = Instantiate(StandartRoom, ShopEntrance, false);
                        tmp.transform.localPosition = Offset;
                    }
                }
            }
        }
    }
}
