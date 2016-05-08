using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public Canvas levelMenu;
    public Canvas shopMenu;
    public Canvas settingsMenu;
    public Canvas quitMenu;

    public Button startButton;
    public Button shopButton;
    public Button settingsButton;
    public Button quitButton;

	// Use this for initialization
	void Start () {

        levelMenu = levelMenu.GetComponent<Canvas>();
        shopMenu = shopMenu.GetComponent<Canvas>();
        settingsMenu = settingsMenu.GetComponent<Canvas>();
        quitMenu = quitMenu.GetComponent<Canvas>();

        startButton = startButton.GetComponent<Button>();
        shopButton = shopButton.GetComponent<Button>();
        settingsButton = settingsButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();

        levelMenu.enabled = false;
        shopMenu.enabled = false;
        settingsMenu.enabled = false;
        quitMenu.enabled = false;
	
	}

    //LEVEL SELECT MENU
    public void PlayPressed()
    {
        levelMenu.enabled = true;
        startButton.enabled = false;
        shopButton.enabled = false;
        settingsButton.enabled = false;
        quitButton.enabled = false;
    }

    //SHOP SELECT MENU
    public void ShopPressed()
    {
        shopMenu.enabled = true;
        startButton.enabled = false;
        shopButton.enabled = false;
        settingsButton.enabled = false;
        quitButton.enabled = false;
    }

    //return to main menu
    public void BackPressed()
    {
        levelMenu.enabled = false;
        shopMenu.enabled = false;
        startButton.enabled = true;
        shopButton.enabled = true;
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
        shopButton.enabled = false;
        settingsButton.enabled = false;
        quitButton.enabled = false;
    }

    //return to main menu
    public void SettingsClosePressed()
    {
        settingsMenu.enabled = false;
        startButton.enabled = true;
        shopButton.enabled = true;
        settingsButton.enabled = true;
        quitButton.enabled = true;
    }


    //QUIT MENU
    public void ExitPressed()
    {
        quitMenu.enabled = true;
        startButton.enabled = false;
        shopButton.enabled = false;
        settingsButton.enabled = false;
        quitButton.enabled = false;
    }

    //return to main menu
    public void NoPressed()
    {
        quitMenu.enabled = false;
        startButton.enabled = true;
        shopButton.enabled = true;
        settingsButton.enabled = true;
        quitButton.enabled = true;
    }

    //exit application
    public void YesPressed()
    {
        Application.Quit();
    }


}
