using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSpecialMove : MonoBehaviour {

    bool triggered;
    float force = 50f;
    public float rechargeCounter = 100f;
    public float recharchRate = 0.2f;

    public GameObject recharge;

    Rigidbody player;
    RectTransform rechargeRect;
    public Image rechargeImage;

    // Use this for initialization
    void Start () {

        triggered = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        rechargeRect = recharge.GetComponent<RectTransform>();
        rechargeImage = recharge.GetComponentInChildren<Image>();
	
	}

    public void triggerMove()
    {
        if (!triggered && rechargeCounter >= 100f)
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
            rechargeCounter = 0;
        }
        
        if(rechargeCounter < 100f)
        {
            rechargeCounter += recharchRate;
            rechargeImage.color = new Color(1, 0, 0, 1);
            recharge.transform.localScale = new Vector3(1, rechargeCounter / 100f, 1);
        }
        else
        {
            rechargeImage.color = new Color(0, 1, 0, 1);
        }

        

    }
	
	
}
