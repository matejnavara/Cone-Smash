using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class settingsMenuScript : MonoBehaviour {

    private Button classicControl;
    private Button tiltControl;
    private Toggle musicToggle;
    private Toggle sfxToggle;

    public Canvas levelMenu;


    // Use this for initialization
    void Start () {
	
        classicControl = GameObject.Find("SettingsMenu/ClassicControl").GetComponent<Button>();
        tiltControl = GameObject.Find("SettingsMenu/TiltControl").GetComponent<Button>();

        musicToggle = GameObject.Find("SettingsMenu/MusicToggle").GetComponent<Toggle>();
        sfxToggle = GameObject.Find("SettingsMenu/SfxToggle").GetComponent<Toggle>();

        if (PlayerPrefs.HasKey("Control")) { controlChoice(PlayerPrefs.GetString("Control")); } else { controlChoice("classic"); }
        if(PlayerPrefs.HasKey("Music") && PlayerPrefs.GetString("Music") == "off") { musicToggle.isOn = false; } else { musicToggle.isOn = true; }
        if (PlayerPrefs.HasKey("Sfx") && PlayerPrefs.GetString("Sfx") == "off") { sfxToggle.isOn = false; } else { sfxToggle.isOn = true; }
    }


    //SOUND
    public void toggleMusic()
    {

        if (musicToggle.isOn)
        {
            PlayerPrefs.SetString("Music", "on");
            print("MUSIC ON");
        }
        else if (!musicToggle.isOn)
        {
            PlayerPrefs.SetString("Music", "off");
            print("MUSIC OFF");
        }
    }

    public void toggleSfx()
    {

        if (sfxToggle.isOn)
        {
            PlayerPrefs.SetString("Sfx", "on");
            print("SFX ON");
        } else if (!sfxToggle.isOn)
        {
            PlayerPrefs.SetString("Sfx", "off");
            print("SFX OFF");
        }
    }


    //CONTROLS
    void controlChoice(string control)
    {
        if(control == "classic") {
            setClassic();
        } else {
            setTilt();
        }
    }


    public void setClassic()
    {
               
            PlayerPrefs.SetString("Control", "classic");
            classicControl.interactable = false;
            tiltControl.interactable = true;
            print("CLASSIC CONTROL");
        
    }

    public void setTilt()
    {
       
            PlayerPrefs.SetString("Control", "tilt");
            tiltControl.interactable = false;
            classicControl.interactable = true;
            print("TILT CONTROL");
        
    }

    //DATA CLEAR
    public void setClear()
    {
        PlayerPrefs.DeleteAll();
        setClassic();
        musicToggle.isOn = true;
        sfxToggle.isOn = true;
        levelMenu.GetComponent<levelMenuScript> ().checkLevels ();
    }

}
