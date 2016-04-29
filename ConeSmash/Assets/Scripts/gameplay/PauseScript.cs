using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseScript : MonoBehaviour {

    public GameManager GMS;
    public Rigidbody player;
    public GameObject pauseButton;
    public GameObject pausePanel;
    public GameObject countdown;

    void Start()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManager>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        countdown = GameObject.Find("GameUI/Countdown");
        pauseButton = this.gameObject;
        pausePanel = GameObject.Find("GameUI/Pause Panel");

    }

    void Update()
    {
        if (!GMS.countDown || GMS.gameOver)
        {
            pauseButton.SetActive(false);
        }

    }

    public void Pause()
    {
        if (!GMS.paused)
        {
            GMS.paused = true;
            player.isKinematic = true;
            pausePanel.SetActive(true);
            
        } else if(GMS.paused)
        {
            GMS.paused = false;
            //countdown.SetActive(true); work to get countdown after unpause
            player.isKinematic = false;
            GMS.controller.SetActive(true);

        }
    }
}
