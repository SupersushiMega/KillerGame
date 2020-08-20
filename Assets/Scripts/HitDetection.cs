using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class HitDetection : MonoBehaviour
{
    public Transform Camera;
    public Transform BulletStart;
    public Transform Minigun;
    public GameObject Impact;
    public GameObject BulletHole;
    public GameObject Bullet;
    public ParticleSystem Muzzle;
    public float Inaccuracy = 0.2f;
    public float FireDelay = 10f;

    Transform Parent;
    float time;
    Vector3 Origin;
    Vector3 Rotation;
    Quaternion MinigunIdleRot;

    private void Start()
    {
        MinigunIdleRot = Minigun.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit Hit; 
            Origin = Camera.position;
            Rotation = Camera.TransformDirection(Vector3.forward);
            if (Physics.Raycast(Origin, Rotation, out Hit, 5f))
            {
                GameObject impactGO = Instantiate(Impact, Hit.point, Quaternion.LookRotation(Hit.normal));
                GameObject BullHol = Instantiate(BulletHole, Hit.point, Quaternion.LookRotation(Hit.normal));
                Destroy(impactGO, 1f);
                Destroy(BullHol, 10f);
            }
        }

        RaycastHit HitGlobal;
        Origin = Camera.position;
        Rotation = Camera.TransformDirection(Vector3.forward);

        if (Physics.Raycast(Origin, Rotation, out HitGlobal, 500f))
        {
            Minigun.LookAt(HitGlobal.point);
        }
        else
        {
            Minigun.rotation = MinigunIdleRot;
        }


        if (Input.GetButton("Fire2"))
        {
            if (time > FireDelay)
            {
                time = 0;
                Origin = Camera.position;
                Rotation = Camera.TransformDirection(Vector3.forward) + new Vector3(Random.Range(Inaccuracy, -Inaccuracy), Random.Range(Inaccuracy, -Inaccuracy), Random.Range(Inaccuracy, -Inaccuracy));
                Muzzle.Play();
                RaycastHit Hit;

                if (Physics.Raycast(Origin, Rotation, out Hit, 500f))
                {
                    Parent = Hit.transform;
                    BulletStart.LookAt(Hit.point);
                    GameObject BulletSpawn = Instantiate(Bullet, BulletStart.position, BulletStart.rotation);
                    GameObject impactGO = Instantiate(Impact, Hit.point, Quaternion.LookRotation(Hit.normal));
                    GameObject BullHol = Instantiate(BulletHole, Hit.point, Quaternion.LookRotation(Hit.normal), Parent);
                    Destroy(BulletSpawn, 1f);
                    Destroy(impactGO, 1f);
                    Destroy(BullHol, 10f);
                }
            }
            else
            {
                time =+ 1 * Time.deltaTime;
            }
        }
    }
}
