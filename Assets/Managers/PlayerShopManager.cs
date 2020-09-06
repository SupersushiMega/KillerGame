using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerShopManager : MonoBehaviour
{

    public Transform ShopEntrance;
    public GameObject StandartRoom;
    public BuildingUI BuildUI;

    public ushort SizeX = 10;
    public ushort SizeY = 10;

    public float RoomScale = 16;

    private byte[,] RoomMap;
    private GameObject[,] InstanciatetRoomList;
    

    // Start is called before the first frame update
    void Start()
    {
        RoomMap = new byte[SizeX, SizeY];
        InstanciatetRoomList = new GameObject[SizeX, SizeY];
        ushort X;
        ushort Y;
        for (X = 0; X < SizeX; X++)
        {

            for (Y = 0; Y < SizeY; Y++)
            {
                RoomMap[X, Y] = 0;
            }
        }
        UpdateGrid();
        BuildUI.OpenUI();
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
                if (RoomMap[X, Y] == 1)
                {
                    Offset = new Vector3(RoomScale * (X - (SizeX / 2)), 0, RoomScale * Y);
                    if (Offset != new Vector3(0, 0, 0) && InstanciatetRoomList[X, Y] != null)
                    {
                        InstanciatetRoomList[X, Y] = Instantiate(StandartRoom, ShopEntrance, false);
                        InstanciatetRoomList[X, Y].transform.localPosition = Offset;
                    }
                }
            }
        }
    }
}
