using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour{

	protected string levelName;
	protected int levelIndex;
	protected float levelStartTime;
	private int highScore;
	private int stars;

	
    public string getName() { return levelName; }
    public int getIndex() { return levelIndex; }
    public float getStartTime(){ return levelStartTime;}

	public int getHighScore(){ return PlayerPrefs.GetInt(levelName + "Highscore"); }
	public void setHighScore(int score){
        highScore = score;
        PlayerPrefs.SetInt(levelName + "Highscore", score);
        print("Logging highscore for " + levelName + "Highscore" + " as " + score);
    }

	public int getStars(){ return PlayerPrefs.GetInt(levelName + "Stars"); }
	public void setStars(int star){
		PlayerPrefs.SetInt(levelName+"Stars", star);
        print("Logging stars for " + levelName + "Stars" + " as " + star);
	}
}
