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
    }


    //FIX TOGGLES
    public void toggleMusic()
    {
        if (musicToggle.isOn == true)
        {
            musicToggle.isOn = false;
            PlayerPrefs.SetString("Music", "off");
            print("MUSIC OFF");
        }else if (musicToggle.isOn == false)
        {
            musicToggle.isOn = true;
            PlayerPrefs.SetString("Music", "on");
            print("MUSIC ON");
        }
    }

    public void toggleSfx()
    {
        if (sfxToggle.isOn)
        {
            sfxToggle.isOn = false;
            PlayerPrefs.SetString("Sfx", "off");
            print("SFX OFF");
        } else if (!sfxToggle.isOn)
        {
            sfxToggle.isOn = true;
            PlayerPrefs.SetString("Sfx", "on");
            print("SFX ON");
        }
    }



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

    public void setClear()
    {
        PlayerPrefs.DeleteAll();
        setClassic();
		levelMenu.GetComponent<levelMenuScript> ().checkLevels ();
    }

}
