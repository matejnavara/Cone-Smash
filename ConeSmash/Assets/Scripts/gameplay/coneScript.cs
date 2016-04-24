using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class coneScript : MonoBehaviour {

    private GameObject cone;

    private GameManager gm;
    private bool knockedOver;
    private bool scored;
    private CapsuleCollider capsule;
    private MeshCollider mesh;
    private Rigidbody rb;
    private float offset = 0.6f;


    // Use this for initialization
    void Start () {     
        cone = gameObject;
        gm = GameManager.Manager;

        capsule = cone.GetComponentInChildren<CapsuleCollider>();
        mesh = cone.GetComponentInChildren<MeshCollider>();
        rb = cone.GetComponent<Rigidbody>();
        cone.transform.rotation = Quaternion.identity;

        knockedOver = false;
        scored = false;

    }

    // Update is called once per frame
    void Update() {

        freezeCone(); //TODO pretty crude, consider moving.
     
        if (!knockedOver) { 
            if (cone.transform.rotation.x > offset || cone.transform.rotation.x < -offset)
            {
                //print("X rot exceeded: " + cone.transform.rotation.x.ToString());
                knockedOver = true;
            }
            if (cone.transform.rotation.y > offset || cone.transform.rotation.y < -offset)
            {
                //print("Y rot exceeded: " + cone.transform.rotation.y.ToString());
                knockedOver = true;
            }
            if (cone.transform.rotation.z > offset || cone.transform.rotation.z < -offset)
            {
                //print("Z rot exceeded: " + cone.transform.rotation.z.ToString());
                knockedOver = true;
            }
        }

        if(knockedOver && !scored)
        {
            mesh.enabled = true;
            capsule.enabled = false;

       
            gm.AddScore(1,gameObject);

            scored = true;
        }

        if(knockedOver && scored && (cone.transform.rotation.z < 0.1 && cone.transform.rotation.z > -0.1))
        {
            //print("Oops! Haven't knocked over: " + cone.name);
            capsule.enabled = true;
            mesh.enabled = false;
            knockedOver = false;
            gm.AddScore(-1,gameObject);
            scored = false;

        }

    }

    public void freezeCone()
    {
        if (gm.paused && !rb.isKinematic)
        {
            rb.isKinematic = true;
        } else if(!gm.paused && rb.isKinematic)
        {
            rb.isKinematic = false;
        }
    }
}
