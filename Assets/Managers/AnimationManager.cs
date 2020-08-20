using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject Pan;
    public GameObject Minigun;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Pan.GetComponent<Animator>().Play("PanSwing");
        }

        if (Input.GetButton("Fire2"))
        {
            Minigun.GetComponent<Animator>().Play("MinigunRotate");
        }
    }
}
