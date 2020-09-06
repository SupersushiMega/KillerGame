using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    public GameObject button;
    public PlayerShopManager PlayerShop;
    List<GameObject> buttonList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenUI()
    {
        ushort SizeX = PlayerShop.SizeX;
        ushort SizeY = PlayerShop.SizeY;

        ushort X;
        ushort Y;

        GameObject tmp;

        int scale;

        if (Screen.width < Screen.height)
        {
            scale = (Screen.width - 200) / SizeX;
        }

        else
        {
            scale = (Screen.height - 200) / SizeY;
        }

        for (X = 0; X < SizeX; X++)
        {
            for (Y = 0; Y < SizeY; Y++)
            {
                Vector3 Offset = new Vector3(scale * (X - (SizeX / 2)), scale * (Y - (SizeY / 2)), 0);
                tmp = Instantiate(button, transform, false);
                tmp.transform.localPosition = Offset;
                buttonList.Add(tmp);
                if (tmp.GetComponent<BuildButton>() != null)
                {
                    tmp.GetComponent<BuildButton>().setup(X, Y, scale / 32, 1, PlayerShop);
                    if (PlayerShop.RoomMap[X, Y] != 255)
                    {
                        tmp.GetComponent<Button>().interactable = false;
                    }
                    tmp.GetComponent<BuildButton>().ui = this;
                }
            }
        }
        UpdateButtons();
    }

    public void UpdateButtons()
    {
        foreach (GameObject i in buttonList)
        {
            if (i.GetComponent<BuildButton>() != null)
            {
                i.GetComponent<BuildButton>().ButtonCheck();
            }
        }
    }
}
