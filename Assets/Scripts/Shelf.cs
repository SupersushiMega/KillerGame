using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    List<GameObject> Cupcakes = new List<GameObject>();

    public Transform shelf;
    public float Space = 20f;
    [Range(0f, 20f)]
    public float ItemCount = 1f;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in shelf)
        {
            if (child.transform.tag == "Untagged")
            {
                Cupcakes.Add(child.gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        short i;
        if (ItemCount != 0)
        {
            for (i = 1; i <= (ItemCount / Space) * Cupcakes.Count; i++)
            {
                Cupcakes[i - 1].SetActive(true);
            }
        }

        else
        {
            i = 1;
        }

#pragma warning disable CS1717 // Die Zuweisung wurde für dieselbe Variable durchgeführt.
        for (i = i; i <= Cupcakes.Count; i++)
#pragma warning restore CS1717 // Die Zuweisung wurde für dieselbe Variable durchgeführt.
        {
            Cupcakes[i - 1].SetActive(false);
        }
    }

    public void TakeCupcake()
    {
        if (ItemCount >= 1)
        {
            ItemCount--;
        }
    }
}
