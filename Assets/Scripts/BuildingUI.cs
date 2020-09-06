using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    public GameObject button;
    public PlayerShopManager PlayerShop;

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
                if (tmp.GetComponent<BuildButton>() != null)
                {
                    tmp.GetComponent<BuildButton>().setup(X, Y, scale / 32, 1);
                }
            }
        }
    }
}
