using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuScript : MonoBehaviour
{

    public GameManager GMS;
    public GameObject pausePanel;
    private Button restartButton;
    private Button mainmenuButton;


    void Start()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManager>();
        restartButton = GameObject.Find("GameUI/Pause Panel/Restart Button").GetComponent<Button>();
        mainmenuButton = GameObject.Find("GameUI/Pause Panel/MainMenu Button").GetComponent<Button>();
        pausePanel = this.gameObject;

        restartButton.onClick.AddListener(delegate { GMS.Reset(); });
        mainmenuButton.onClick.AddListener(delegate { GMS.MainMenu(); });
    }

    void Update()
    {
        if (!GMS.paused)
        {
            pausePanel.SetActive(false);
        }

    }


}
