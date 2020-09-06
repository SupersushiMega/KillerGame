using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BuildButton : MonoBehaviour
{

    public Button button;

    private ushort[] GridPos = new ushort[2];

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setup(ushort X, ushort Y, float scale, byte Type)
    {
        GridPos[0] = X;
        GridPos[0] = Y;
        button.transform.localScale = new Vector3(scale, scale, scale);
    }
}
