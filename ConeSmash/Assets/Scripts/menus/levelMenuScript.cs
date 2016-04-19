using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class levelMenuScript : MonoBehaviour {


    private Button[] levels;
	private Button level1;
	private Button level2;
	private Button level3;
	private Button level4;
    private Button level5;

    private Image stars;

	// Use this for initialization
	void Start () {

        levels = new Button[5];
		level1 = GameObject.Find ("LevelMenu/Level1-1").GetComponent<Button>();
		level2 = GameObject.Find ("LevelMenu/Level1-2").GetComponent<Button>();
		level3 = GameObject.Find ("LevelMenu/Level1-3").GetComponent<Button>();
		level4 = GameObject.Find ("LevelMenu/Level1-4").GetComponent<Button>();
        level5 = GameObject.Find("LevelMenu/Level1-5").GetComponent<Button>();
        stars = GameObject.Find("LevelMenu/Stars").GetComponent<Image>();

        levels[0] = level1;
        levels[1] = level2;
		levels[2] = level3;
		levels[3] = level4;
        levels[4] = level5;

		checkLevels ();

	}

    //Checks if a level is locked/unlocked as well as the number of stars
	public void checkLevels(){

        int total = 0;

        for(int i = 0; i < levels.Length; i++)
        {
            string previousLvl = "level" + i + "Stars";
            string currentLvl = "level" + (i+1) + "Stars";
            int previousStars = PlayerPrefs.GetInt(previousLvl);
            int currentStars = PlayerPrefs.GetInt(currentLvl);

            Image star1 = levels[i].transform.Find("star1").GetComponent<Image>();
            Image star2 = levels[i].transform.Find("star2").GetComponent<Image>();
            Image star3 = levels[i].transform.Find("star3").GetComponent<Image>();

            Image locked = levels[i].transform.Find("locked").GetComponent<Image>();

            //Checks if level 2 onwards have been unlocked from getting 1 of more star in the previous level
            if (previousStars > 0 || i == 0)
            {
                locked.enabled = false;
                levels[i].interactable = true;
                print("Unlocking level " + (i + 1));
                star1.enabled = true;
                star2.enabled = true;
                star3.enabled = true;
                print("Fixing stars for " + currentLvl);

                if (currentStars >= 1) { star1.color = Color.yellow; } else { star1.color = Color.grey; }
                if (currentStars >= 2) { star2.color = Color.yellow; } else { star2.color = Color.grey; }
                if (currentStars == 3) { star3.color = Color.yellow; } else { star3.color = Color.grey; }

            }
            else {
                locked.enabled = true;
                levels[i].interactable = false;
                print("Locking level " + (i + 1));
                star1.enabled = false;
                star2.enabled = false;
                star3.enabled = false;
            }         

            total += currentStars;
        }

        totalStars(total);
    }

    void totalStars(int x)
    {
        stars.transform.Find("totalStars").GetComponent<Text>().text = x.ToString();
    }

	
}
