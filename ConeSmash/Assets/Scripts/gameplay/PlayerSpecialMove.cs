using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerSpecialMove : MonoBehaviour {

    public GameObject moveBtn;
    public GameObject rechargeImage;

    private Image image;
    private Text text;

    private Vector3 force;
    private float rechargeCounter;
    private float recharchRate;
    private Rigidbody player;
    private bool triggered;

    // Use this for initialization
    void Start () {

        triggered = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        image = rechargeImage.GetComponentInChildren<Image>();
        text = moveBtn.GetComponentInChildren<Text>();
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
                text.text = "S H O O T !";
                break;
            case 2:
                force = transform.up * 30f;
                recharchRate = 0.5f;
                text.text = "B O U N C E !";
                break;
            case 3:
                force = transform.forward * 200f;
                recharchRate = 0.2f;
                text.text = "B O W L !";
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
            rechargeCounter += recharchRate;
            rechargeImage.transform.localScale = new Vector3(1, rechargeCounter / 100f, 1);
            image.color = new Color(1, 0, 0, 1);
        }
        else
        {
            image.color = new Color(0, 1, 0, 1);
        }
    }
	
	
}
