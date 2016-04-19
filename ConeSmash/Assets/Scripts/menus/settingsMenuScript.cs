using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class settingsMenuScript : MonoBehaviour {

    private Button classicControl;
    private Button tiltControl;

    public Canvas levelMenu;


    // Use this for initialization
    void Start () {
	
        classicControl = GameObject.Find("SettingsMenu/ClassicControl").GetComponent<Button>();
        tiltControl = GameObject.Find("SettingsMenu/TiltControl").GetComponent<Button>();

        if (PlayerPrefs.HasKey("Control")) { controlChoice(PlayerPrefs.GetString("Control")); } else { controlChoice("classic"); }
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
