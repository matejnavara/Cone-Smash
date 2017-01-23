using UnityEngine;
using System.Collections;

public class PlayerSpecialMove : MonoBehaviour {

    bool triggered;
    float force = 50f;
    public float recharge = 100f;
    Rigidbody player;
    RectTransform rechargeRect;

    public GameObject rechargeImage;

	// Use this for initialization
	void Start () {

        triggered = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        rechargeRect = rechargeImage.GetComponent<RectTransform>();
	
	}

    public void triggerMove()
    {
        if (!triggered && recharge >= 100f)
        {
            print("MOVE TRIGGERED!");
            triggered = true;
        }   
    }

    void FixedUpdate()
    {
        if (triggered)
        {
            player.AddForce(transform.up * force, ForceMode.Impulse);
            triggered = false;
            recharge = 0;
        }
        
        if(recharge < 100f)
        {
            recharge += 0.2f;
        }

        rechargeImage.transform.localScale = new Vector3( 1, recharge / 100f, 1);

    }
	
	
}
