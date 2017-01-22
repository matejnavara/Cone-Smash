using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject levelMenu;
    public GameObject shopMenu;
    public GameObject settingsMenu;
    public GameObject quitMenu;



    // Use this for initialization
    void Start () {
        BackPressed();
    }

    //LEVEL SELECT MENU
    public void PlayPressed()
    {
        levelMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    //SHOP SELECT MENU
    public void ShopPressed()
    {
        shopMenu.SetActive(true);
        shopMenu.GetComponent<shopMenuScript>().setupShop();
        mainMenu.SetActive(false);
    }

    //SETTINGS MENU
    public void SettingsPressed()
    {
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    //QUIT MENU
    public void ExitPressed()
    {
        quitMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    //return to main menu
    public void BackPressed()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
        shopMenu.SetActive(false);
        settingsMenu.SetActive(false);
        quitMenu.SetActive(false);
    }

    public void PlayLevel(int index)
    {
        SceneManager.LoadScene(index);
    }

    //exit application
    public void YesPressed()
    {
        Application.Quit();
    }


}
