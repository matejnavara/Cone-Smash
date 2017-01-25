using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSpecialMove : MonoBehaviour {

    public GameObject moveObj;
    public GameObject rechargeObj;

    private Button moveBtn;
    private Image rechargeImg;
    private Text moveTxt;

    private Vector3 force;
    private float rechargeCounter;
    private float recharchRate;
    private Rigidbody player;
    private bool triggered;

    // Use this for initialization
    void Start () {

        triggered = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        moveBtn = moveObj.GetComponent<Button>();
        rechargeImg = rechargeObj.GetComponent<Image>();
        moveTxt = moveObj.GetComponentInChildren<Text>();
        rechargeCounter = 100f;
        selectMove();
	
	}

    void selectMove()
    {
        int choice;

        if (PlayerPrefs.HasKey("selectedBall"))
        {
            choice = PlayerPrefs.GetInt("selectedBall");
        }
        else {
            choice = 1;
        }

        switch (choice)
        {
            case 1:
                force = transform.up * 50f;
                recharchRate = 0.3f;
                moveTxt.text = "S H O O T !";
                break;
            case 2:
                force = transform.up * 20f;
                recharchRate = 0.5f;
                moveTxt.text = "B O U N C E !";
                break;
            case 3:
                force = transform.forward * 200f;
                recharchRate = 0.2f;
                moveTxt.text = "B O W L !";
                break;
            default:
                print("Error case at selectMove");
                break;
        }
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
            player.AddForce(force, ForceMode.Impulse);
            triggered = false;
            rechargeCounter = 0;
        }
        
        if(rechargeCounter < 100f)
        {
            //Recharging power
            rechargeCounter += recharchRate;
            rechargeObj.transform.localScale = new Vector3(1, rechargeCounter / 100f, 1);
            rechargeImg.color = new Color(1, 0, 0, 1);
            moveBtn.interactable = false;
        }
        else
        {
            //Power recharged!
            
            rechargeImg.color = new Color(0, 1, 0, 1);
            moveBtn.interactable = true;
        }
    }
	
	
}
