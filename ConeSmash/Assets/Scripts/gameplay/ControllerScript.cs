using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

    public GameManager GMS;
    public GameObject controller;

    void Start()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManager>();
        controller = this.gameObject;
        
    }

    void Update()
    {
        if (!GMS.countDown || GMS.gameOver || GMS.paused)
        {
            controller.SetActive(false);
            print("Controls off");
        } 
        
    }
}
