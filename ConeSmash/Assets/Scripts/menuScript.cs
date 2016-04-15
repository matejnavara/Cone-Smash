using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public Canvas levelMenu;
    public Canvas settingsMenu;
    public Canvas quitMenu;

    public Button startButton;
    public Button settingsButton;
    public Button quitButton;

	// Use this for initialization
	void Start () {

        levelMenu = levelMenu.GetComponent<Canvas>();
        settingsMenu = settingsMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();

        startButton = startButton.GetComponent<Button>();
        settingsButton = settingsButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();

        levelMenu.enabled = false;
        settingsMenu.enabled = false;
        quitMenu.enabled = false;
	
	}

    //LEVEL SELECT MENU
    public void PlayPressed()
    {
		levelMenu.GetComponent<levelMenuScript> ().checkLevels ();
        levelMenu.enabled = true;
        startButton.enabled = false;
        settingsButton.enabled = false;
        quitButton.enabled = false;
    }

    //return to main menu
    public void BackPressed()
    {
        levelMenu.enabled = false;
        startButton.enabled = true;
        settingsButton.enabled = true;
        quitButton.enabled = true;
    }

    public void PlayLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    //SETTINGS MENU
    public void SettingsPressed()
    {
        settingsMenu.enabled = true;
        startButton.enabled = false;
        settingsButton.enabled = false;
        quitButton.enabled = false;
    }

    //return to main menu
    public void SettingsClosePressed()
    {
        settingsMenu.enabled = false;
        startButton.enabled = true;
        settingsButton.enabled = true;
        quitButton.enabled = true;
    }


    //QUIT MENU
    public void ExitPressed()
    {
        quitMenu.enabled = true;
        startButton.enabled = false;
        settingsButton.enabled = false;
        quitButton.enabled = false;
    }

    //return to main menu
    public void NoPressed()
    {
        quitMenu.enabled = false;
        startButton.enabled = true;
        settingsButton.enabled = true;
        quitButton.enabled = true;
    }

    //exit application
    public void YesPressed()
    {
        Application.Quit();
    }


}
