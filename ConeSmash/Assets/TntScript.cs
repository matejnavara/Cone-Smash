using UnityEngine;
using System.Collections;

public class TntScript : MonoBehaviour {

    public float radius;
    public float power;
    public float lift;
    public GameObject tnt;
    private bool exploded;
    private Vector3 explosionPos;
    private ParticleSystem explosion;


	void Start () {

        explosion = gameObject.GetComponent<ParticleSystem>();
        exploded = false;
        explosionPos = transform.position;
        radius = 10.0f;
        power = 5.0f;
        lift = 3.0f;
        	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player" && !exploded)
        {
            print("BOOM!");
            explosion.Play();
            tnt.SetActive(false);
            Explode();
        }
    }

    private void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        exploded = true;
        foreach (Collider hit in colliders)
        { 
            Rigidbody rb = hit.GetComponentInParent<Rigidbody>();
            if(rb != null) {
                print("Exploding..." + hit.name);
                rb.AddExplosionForce(power, explosionPos, radius, lift, ForceMode.Impulse);
            }
        }  
    }

}
