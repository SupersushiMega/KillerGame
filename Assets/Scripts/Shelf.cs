using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    List<GameObject> Cupcakes = new List<GameObject>();
    public float Space = 20;
    [Range(0f, 20f)]
    public int ItemCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            Cupcakes.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        short i;
        if (ItemCount != 0)
        {
            for (i = 0; i <= (ItemCount / Space) * Cupcakes.Count; i++)
            {
                Cupcakes[i].SetActive(true);
            }
        }

        else
        {
            i = 0;
        }

#pragma warning disable CS1717 // Die Zuweisung wurde für dieselbe Variable durchgeführt.
        for (i = i; i <= Cupcakes.Count; i++)
#pragma warning restore CS1717 // Die Zuweisung wurde für dieselbe Variable durchgeführt.
        {
            Cupcakes[i].SetActive(false);
        }
    }
}
