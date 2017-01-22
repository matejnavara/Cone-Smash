using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class shopMenuScript : MonoBehaviour {

    public GameObject ball1;
    public GameObject ball2;
    public GameObject ball3;
    
    public Button footballSelect;
    public Button basketballSelect;
    public Button bowlingballSelect;

    public Animation footballAnim;
    public Animation basketballAnim;
    public Animation bowlingballAnim;


	// Use this for initialization
	void Start () {
        setupShop();
	}

    public void setupShop()
    {
        try
        {
            switchSelection(getSelectedBall());
        }
        catch
        {
            footballSelect = ball1.GetComponent<Button>();
            basketballSelect = ball2.GetComponent<Button>();
            bowlingballSelect = ball3.GetComponent<Button>();

            footballAnim = ball1.GetComponentInChildren<Animation>();
            basketballAnim = ball2.GetComponentInChildren<Animation>();
            bowlingballAnim = ball3.GetComponentInChildren<Animation>();

            switchSelection(getSelectedBall());
        }
        
    }

    private int getSelectedBall()
    {
        int selectedBall;

        if (PlayerPrefs.HasKey("selectedBall"))
        {
            selectedBall = PlayerPrefs.GetInt("selectedBall");
        } else {
            selectedBall = 1;
            PlayerPrefs.SetInt("selectedBall", selectedBall);
        }

        return selectedBall;      
    }

    public void switchSelection(int selection)
    {

        switch (selection)
        {
            case 1:
                print("Football selected");
                footballSelect.interactable = false;
                footballAnim.Play();
                basketballSelect.interactable = true;
                basketballAnim.Stop();
                bowlingballSelect.interactable = true;
                bowlingballAnim.Stop();
                break;

            case 2:
                print("Basketball selected");
                footballSelect.interactable = true;
                footballAnim.Stop();
                basketballSelect.interactable = false;
                basketballAnim.Play();
                bowlingballSelect.interactable = true;
                bowlingballAnim.Stop();
                break;

            case 3:
                print("Bowling ball selected");
                footballSelect.interactable = true;
                footballAnim.Stop();
                basketballSelect.interactable = true;
                basketballAnim.Stop();
                bowlingballSelect.interactable = false;
                bowlingballAnim.Play();
                break;

            default:
                print("Error case");
                break;
        }

        PlayerPrefs.SetInt("selectedBall", selection);

    }

	
}
