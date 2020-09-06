using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    PlayerShopManager PlayerShop;
    public BuildingUI ui;
    public Button button;

    private ushort X;
    private ushort Y;

    public void Place()
    {
        if (PlayerShop != null)
        {
            PlayerShop.RoomMap[X, Y] = 1;
            PlayerShop.UpdateGrid();
            ui.UpdateButtons();
        }
        else 
        {
            Debug.LogError("PlayerShopManager is null");
        }
    }

    public void setup(ushort GridX, ushort GridY, float scale, byte Type, PlayerShopManager Manager)
    {
        X = GridX;
        Y = GridY;
        PlayerShop = Manager;
        button.transform.localScale = new Vector3(scale, scale, scale);
    }

    public void ButtonCheck()
    {
        if (PlayerShop != null)
        {
            if (PlayerShop.RoomMap[Mathf.Abs(X - 1), Y] != 0)
            {
                button.interactable = true;
            }

            else if (PlayerShop.RoomMap[X, Mathf.Abs(Y - 1)] != 0)
            {
                button.interactable = true;
            }

            if ((X + 1) < PlayerShop.SizeX)
            {
                if (PlayerShop.RoomMap[X + 1, Y] != 0)
                {
                    button.interactable = true;
                }
            }

            if ((Y + 1) < PlayerShop.SizeY)
            {
                if (PlayerShop.RoomMap[X, Y + 1] != 0)
                {
                    button.interactable = true;
                }
            }
        }
        else
        {
            Debug.LogError("PlayerShopManager is null");
        }
    }
}
