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

    private Image stars;
	private bool unlocked;

	// Use this for initialization
	void Start () {

        levels = new Button[4];
		level1 = GameObject.Find ("LevelMenu/Level1-1").GetComponent<Button>();
		level2 = GameObject.Find ("LevelMenu/Level1-2").GetComponent<Button>();
		level3 = GameObject.Find ("LevelMenu/Level1-3").GetComponent<Button>();
		level4 = GameObject.Find ("LevelMenu/Level1-4").GetComponent<Button>();
        stars = GameObject.Find("LevelMenu/Stars").GetComponent<Image>();

        levels[0] = level1;
        levels[1] = level2;
		levels[2] = level3;
		levels[3] = level4;

		checkLevels ();

	}

	public void checkLevels(){
		checkStars ();
		checkLocked ();
	}

    public void checkStars()
    {
        int total = 0;

        for(int i = 0; i < levels.Length; i++)
        {
			string temp = "level" + (i+1) + "Stars";
            int starcount = PlayerPrefs.GetInt(temp);
			if (starcount >= 1) { levels[i].transform.Find("star1").GetComponent<Image>().color = Color.yellow; 
			} else { levels[i].transform.Find("star1").GetComponent<Image>().color = Color.grey; }
			if (starcount >= 2) { levels[i].transform.Find("star2").GetComponent<Image>().color = Color.yellow; 
			} else { levels[i].transform.Find("star2").GetComponent<Image>().color = Color.grey; }
			if (starcount == 3) { levels[i].transform.Find("star3").GetComponent<Image>().color = Color.yellow; 
			} else { levels[i].transform.Find("star3").GetComponent<Image>().color = Color.grey; }
            print("Fixing stars for " + temp);

            total += starcount;
        }

        totalStars(total);
    }

    void totalStars(int x)
    {
        stars.transform.Find("totalStars").GetComponent<Text>().text = x.ToString();
    }

    void checkLocked()
    {

        for(int i = 1; i < levels.Length - 1; i++)
        {
			string temp = "level" + (i) + "Stars";
            int starcount = PlayerPrefs.GetInt(temp);
			if (starcount > 0 ) {
				levels[i+1].transform.Find("locked").GetComponent<Image>().enabled = false; 
				levels [i+1].interactable = true;
				} else { 
				levels[i+1].transform.Find("locked").GetComponent<Image>().enabled = true; 
				levels [i+1].interactable = false;
			}
            print("Fixing locked for " + temp);
        }
    }

	
}
