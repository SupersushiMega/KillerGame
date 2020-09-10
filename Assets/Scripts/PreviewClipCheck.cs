using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewClipCheck : MonoBehaviour
{
    Renderer render;
    public Color RED;
    public Color GREEN;
    // Start is called before the first frame update
    void Start()
    {
        render = gameObject.GetComponent<Renderer>();
        RED = new Color(1, 0, 0);
        GREEN = new Color(0, 1, 0);
        render.material.SetColor("_TintColor", GREEN);
    }

    private void OnTriggerEnter(Collider other)
    {
        render.material.SetColor("_TintColor", RED);
    }

    private void OnTriggerExit(Collider other)
    {
        render.material.SetColor("_TintColor", GREEN);
    }
}
