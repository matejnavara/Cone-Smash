using UnityEngine;
using System.Collections;

public class coneScript : MonoBehaviour {

    private GameObject cone;

    private GameManager gm;
    private bool knockedOver;
    private bool scored;
    private CapsuleCollider capsule;
    private MeshCollider mesh;
    private float offset = 0.6f;


	// Use this for initialization
	void Start () {     
        cone = gameObject;
        gm = GameManager.Manager;
        cone.transform.rotation = Quaternion.identity;
        knockedOver = false;
        scored = false;

    }

    // Update is called once per frame
    void Update() {
     
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
            cone.GetComponentInChildren<MeshCollider>().enabled = true;
            cone.GetComponentInChildren<CapsuleCollider>().enabled = false;

            //print("Knocked over: " + cone.name);
            gm.AddScore(1);
            scored = true;
        }

        if(knockedOver && scored && (cone.transform.rotation.z < 0.1 && cone.transform.rotation.z > -0.1))
        {
            //print("Oops! Haven't knocked over: " + cone.name);
            cone.GetComponentInChildren<CapsuleCollider>().enabled = true;
            cone.GetComponentInChildren<MeshCollider>().enabled = false;
            knockedOver = false;
            gm.AddScore(-1);
            scored = false;

        }

    }
}
