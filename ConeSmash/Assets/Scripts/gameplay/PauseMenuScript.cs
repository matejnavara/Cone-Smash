using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenuScript : MonoBehaviour
{

    public GameManager GMS;
    public GameObject pausePanel;
    private Toggle musicToggle;
    private Toggle sfxToggle;
    private Button restartButton;
    private Button mainmenuButton;


    void Start()
    {
        GMS = GameObject.Find("GameManager").GetComponent<GameManager>();

        restartButton = GameObject.Find("GameUI/Pause Panel/Restart Button").GetComponent<Button>();
        mainmenuButton = GameObject.Find("GameUI/Pause Panel/MainMenu Button").GetComponent<Button>();
        musicToggle = GameObject.Find("GameUI/Pause Panel/Music Toggle").GetComponent<Toggle>();
        sfxToggle = GameObject.Find("GameUI/Pause Panel/Sfx Toggle").GetComponent<Toggle>();
        pausePanel = this.gameObject;

        if (!PlayerPrefs.HasKey("Music") || PlayerPrefs.GetString("Music") == "off") { musicToggle.isOn = false; } else { musicToggle.isOn = true; }
        if (!PlayerPrefs.HasKey("Sfx") || PlayerPrefs.GetString("Sfx") == "off") { sfxToggle.isOn = false; } else { sfxToggle.isOn = true; }

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

    //SOUND
    public void toggleMusic()
    {

        if (musicToggle.isOn)
        {
            PlayerPrefs.SetString("Music", "on");
            GMS.soundOn("music");
            print("MUSIC ON");
        }
        else if (!musicToggle.isOn)
        {
            PlayerPrefs.SetString("Music", "off");
            GMS.soundOff("music");
            print("MUSIC OFF");
        }
    }

    public void toggleSfx()
    {

        if (sfxToggle.isOn)
        {
            PlayerPrefs.SetString("Sfx", "on");
            GMS.soundOn("sfx");
            print("SFX ON");
        }
        else if (!sfxToggle.isOn)
        {
            PlayerPrefs.SetString("Sfx", "off");
            GMS.soundOff("sfx");
            print("SFX OFF");
        }
    }


}
