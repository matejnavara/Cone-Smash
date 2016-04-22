using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

	//TODO abstract level implementation.
	public Level level;
    private int index;

    //Control Elements
	public GameObject controller;

    //UI Elements
    private Text countText;
    private Text timerText;
    private Text finalText;
	private Image star1;
	private Image star2;
	private Image star3;
    private GameObject gameoverPanel;
    private Button playagainButton;
    private Button mainmenuButton;

    //Game Logic Elements
    public bool countDown;
    public bool gameOver;
	private bool newHighscore;
    private float timer;
    private int coneCount;
    private int coneTotal;

    public AudioSource audioCone;
    public AudioClip soundCone;

    public AudioSource audioBG;
    public AudioClip soundBG;

    private static GameManager manager;

    public static GameManager Manager
    {
        get { return manager; }
    }

    void Awake()
    {
        GetThisGameManager();
        controllerCheck();
    }

    void GetThisGameManager()
    {
        if (manager != null && manager != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            manager = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {

        nullCheck();
        Reset();
        print("START again");
        print("Level name: " + level.getName());
        print("Level index: " + index);
        print("Highscore: " + level.getHighScore());
        print("Stars: " + level.getStars());
    }


    // Update is called once per frame
    void Update()
    {
        nullCheck();

        if (!audioBG.isPlaying)
        {
            audioBG.PlayOneShot(soundBG);
        }

        //Counts down from defined "timer" to reach Game Over.
        if (!gameOver && countDown)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F2");
            if (timer <= 0)
            {
                gameFinished();
                print("GAME OVER");
            }
        }
        
    }

    //Checks for chosen control scheme
	//TODO Make this work, currently issue with instantiating both control schemes at once. Perhaps need to instantiate one control dependant on choice.
    void controllerCheck()
    {
        if(!PlayerPrefs.HasKey("Control") || PlayerPrefs.GetString("Control") == "classic")
        {
            controller =  (GameObject) Instantiate(Resources.Load("Prefabs/ControlClassic"));

        } else
        {
            controller = (GameObject)Instantiate(Resources.Load("Prefabs/ControlTilt"));
        }

    }

    //SCORING METHODS
    //Initially counting total cones on startup
    int countCones()
    {
        int count = GameObject.FindGameObjectsWithTag("Cone").Length;
        print("TOTAL CONES: " + count.ToString());
        return count;
    }

    //Incrementing/decrementing score through calls from coneScript
    public void AddScore(int x, GameObject cone)
    {
        coneCount = coneCount + x;
        audioCone = cone.GetComponent<AudioSource>();
        soundCone = (AudioClip)Instantiate(Resources.Load("Audio/plastic_small_0" + Random.Range(1, 5).ToString()));

        if (x > 0 && !audioCone.isPlaying && !gameOver)
        {            
            audioCone.PlayOneShot(soundCone,0.1f);
            print("Playing: " + soundCone.name);
        } else
        {
            audioCone.Stop();
        }
        
        SetCountText();
    }

    //Updating score text
    public void SetCountText()
    {
        countText.text = coneCount.ToString() + " / " + coneTotal.ToString();
    }

    //GAME OVER METHODS
    //Called upon gameover, disable Player/HUD and display game over panel with final score/play again button/main menu button
    void gameFinished()
    {
        gameOver = true;
        countText.enabled = false;
        timerText.enabled = false;
        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        gameoverPanel.SetActive(true);

        checkStars ();
        checkHighScore();

        playagainButton.onClick.AddListener(delegate { Reset(); });
        mainmenuButton.onClick.AddListener(delegate { MainMenu(); });

    }

	void checkStars(){
		if (coneCount > (coneTotal * 0.6)) {
			star3.color = Color.yellow;
			if (level.getStars() == null || level.getStars() < 3) { level.setStars (3); }
        }
		if (coneCount > (coneTotal * 0.4)) {
			star2.color = Color.yellow;
			if(level.getStars() == null || level.getStars() < 2) { level.setStars(2); }
		}
		if (coneCount > (coneTotal * 0.2)) {
			star1.color = Color.yellow;
			if (level.getStars() == null || level.getStars() < 1) { level.setStars(1); }
        }
	}

    void checkHighScore()
    {
		if (level.getHighScore() == null || level.getHighScore() < coneCount)
        {
			level.setHighScore(coneCount);
            newHighscore = true;
        }
        if (newHighscore)
        {
            finalText.text = "NEW HIGHSCORE! Smashed " + coneCount + " out of " + coneTotal + " cones in 30 seconds!";
        }
        else {
			finalText.text = "High Score: " + level.getHighScore() + "  Smashed " + coneCount + " out of " + coneTotal + " cones in 30 seconds.";
        }
    }
    
    //Public bool to check for gameover condition
    public bool isGameOver()
    {
        return gameOver;
    }

    //Resets the game loop upon pressing play again
    public void Reset()
    {
        countDown = false;
        gameOver = false;
        newHighscore = false;
        index = level.getIndex();
        timer = level.getStartTime();
        coneCount = 0;
        coneTotal = countCones();
        gameoverPanel.SetActive(false);

        audioBG = gameObject.GetComponent<AudioSource>();
        soundBG = (AudioClip)Instantiate(Resources.Load("Audio/Plane_Town_LOOP"));

        star1.color = Color.grey;
        star2.color = Color.grey;
        star3.color = Color.grey;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Returns to main menu upon pressing main menu
    public void MainMenu()
    {
        gameOver = false;

        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }

    //Checks initilization of UI elements
    void nullCheck()
    {
        if (level == null) { level = GameObject.Find("levelID").GetComponent<Level>(); }
        if(controller == null) { controller = GameObject.FindGameObjectWithTag("GameController"); }
        if (countText == null){ countText = GameObject.Find("GameUI/Count Text").GetComponent<Text>();}
        if(timerText == null){ timerText = GameObject.Find("GameUI/Timer Text").GetComponent<Text>();}
        if (finalText == null){ finalText = GameObject.Find("GameUI/GameOver Panel/final Text").GetComponent<Text>();}
		if (star1 == null){ star1 = GameObject.Find("GameUI/GameOver Panel/star1").GetComponent<Image>();}
		if (star2 == null){ star2 = GameObject.Find("GameUI/GameOver Panel/star2").GetComponent<Image>();}
		if (star3 == null){ star3 = GameObject.Find("GameUI/GameOver Panel/star3").GetComponent<Image>();}
        if (gameoverPanel == null){ gameoverPanel = GameObject.Find("GameUI/GameOver Panel");}
        if (playagainButton == null){ playagainButton = GameObject.Find("GameUI/GameOver Panel/PlayAgain Button").GetComponent<Button>();}
        if (mainmenuButton == null) { mainmenuButton = GameObject.Find("GameUI/GameOver Panel/MainMenu Button").GetComponent<Button>(); }

        if (!gameOver && gameoverPanel.activeSelf){ gameoverPanel.SetActive(false);}
    }

}
