using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleAndroidNotifications;

//Mainclass, runs the game, keeps controll of the variables
public class GameController : MonoBehaviour {

    public static GameController instance = null;

    public Button chestRand;
    public Button gemRand;
    public Button ad;
    public Button nextLevelButton;
    public Image nextLevelInfo;
    public GameObject Aperture;

	private GameObject ArmorAgeOne;
    private GameObject ArmorAgeTwo;
    private GameObject ArmorAgeThree;
    private GameObject ArmorAgeFour;
    private GameObject ArmorAgeFive;
    private GameObject ArmorAgeSix;
    private GameObject ArmorAgeSeven;
    private GameObject ArmorAgeEight;
	
	public Text AchievementText;

	[HideInInspector]
    public bool AchievementSuccess_Age = false;
	[HideInInspector]
    public bool AchievementSuccess_Armor = false;
	[HideInInspector]
    public bool AchievementSuccess_Chest = false;

    private bool starting = true;
	private bool levelSwitch = false;

    #region Start&Update
    void Awake() {
        instance = this;
    }

    void Start()
    {
        initVariables();
        GUIController.instance.setLanguage();

        InvokeRepeating("saveGame", CONSTANTS.AUTOSAVE_TIME, CONSTANTS.AUTOSAVE_TIME);
        InvokeRepeating("updateLeaderboard", CONSTANTS.UPDATE_LEADERBOARD_TIME, CONSTANTS.UPDATE_LEADERBOARD_TIME);
        InvokeRepeating("updateLastPlayed", CONSTANTS.UPDATE_LASTPLAYED_TIME, CONSTANTS.UPDATE_LASTPLAYED_TIME);
        InvokeRepeating("randomBonus", CONSTANTS.RANDOM_TIME, CONSTANTS.RANDOM_TIME);
        InvokeRepeating("updateAd", CONSTANTS.UPDATE_AD_TIME, CONSTANTS.UPDATE_AD_TIME);

        startGame();

        NotificationManager.CancelAll();
        starting = false;
        EncryptedPlayerPrefs.SetInt(Application.version.ToString(), 1);
    }

    void Update() 
	{
		
		AchievementController();

        //Points
        Data.Points += Data.TapsPerSec * Time.deltaTime * Data.PointsMultiplier;

     /*   //Animation
        bool walking = Data.TapsPerSec != 0;
        bool running = Data.TapsPerSecRatio >= 0.7;
       // AnimationController.instance.setWalking(walking);
        //AnimationController.instance.setRunning(running);
        if (walking) {
            AnimationController.instance.setSpeed(Data.TapsPerSecRatio * 2);
        } else  if (running) {
            AnimationController.instance.setSpeed(Data.TapsPerSecRatio * 2.5f);
        } else {
            AnimationController.instance.setSpeed(1);
        }
        */
        //Next Level
        if (Data.Points >= Data.NeededPoints) {
            AnimationController.instance.setNextLevel(true);
            nextLevelButton.gameObject.SetActive(true);
            nextLevelInfo.gameObject.SetActive(false);
        }
    }

    void OnApplicationQuit() {
        updateLastPlayed();
        saveGame();
    }

    void OnApplicationPause(bool pauseStatus) {
        if (pauseStatus) {
            if (Data.Notification) {
                if ((Data.BronzeChestAmount >= 1) && (Data.BronzeChestTime >= 1)) {
                    NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(Data.BronzeChestTime), LANGUAGE.GC_NOTIFICATION_BRONZE[LANGUAGE.CUR_LANG],
                        LANGUAGE.GC_NOTIFICATION_BRONZE_LONG[LANGUAGE.CUR_LANG], new Color32(0xCC, 0x5E, 0x0D, 0xFF), NotificationIcon.Star);
                }
                if ((Data.SilverChestAmount >= 1) && (Data.SilverChestTime >= 1)) {
                    NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(Data.SilverChestTime), LANGUAGE.GC_NOTIFICATION_SILVER[LANGUAGE.CUR_LANG],
                        LANGUAGE.GC_NOTIFICATION_SILVER_LONG[LANGUAGE.CUR_LANG], new Color32(0xB9, 0xD4, 0xD6, 0xFF), NotificationIcon.Star);
                }
                if ((Data.GoldChestAmount >= 1) && (Data.GoldChestTime >= 1)) {
                    NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(Data.GoldChestTime), LANGUAGE.GC_NOTIFICATION_GOLD[LANGUAGE.CUR_LANG],
                        LANGUAGE.GC_NOTIFICATION_GOLD_LONG[LANGUAGE.CUR_LANG], new Color32(0xD4, 0xAF, 0x37, 0xFF), NotificationIcon.Star);
                }
                Debug.Log("Notifications placed");
            }
            updateLastPlayed();
            saveGame();
        } else {
            if (!starting) {
                Data.LastPlayedDifference = Math.Min((int)(DateTime.Now.Ticks / 10000000 - long.Parse(Data.LastPlayed)), CONSTANTS.MAX_CHEST_SLEEP_TIME);
                Debug.Log("Last Played: " + Data.LastPlayedDifference + " seconds ago");
                NotificationManager.CancelAll();
            }
        }
    }
    #endregion

    #region Init
    private void initVariables() {
        //LoadGame
        SaveGameController.instance.loadGame();

        //Taps
        Data.TapsPerSec = 0;
        Data.TapsPerSecRatio = 0;
        //Points
        if (Data.CurrentLevel < CONSTANTS.MAX_LEVEL) {
            Data.NeededPoints = CONSTANTS.NEEDED_POINTS[Data.CurrentLevel - 1];
        } else {
            Data.NeededPoints = Mathf.Infinity;
        }
        Data.SliderValue = Data.Points / Data.NeededPoints;
        //TimeLog
        Data.LastPlayedDifference = Math.Min((int)(DateTime.Now.Ticks / 10000000 - long.Parse(Data.LastPlayed)), CONSTANTS.MAX_CHEST_SLEEP_TIME);
        Debug.Log("Last Played: " + Data.LastPlayedDifference + " seconds ago");
    }
    #endregion

    private void startGame() {
        BackgroundController.instance.setMovingEnabled(true);
        RunController.instance.setTappingEnabled(true);
    }

    public void nextLevel() 
	{
        levelSwitch = true;
        Aperture.SetActive(true);
        GUIController.instance.setApertureText();
        AnimationController.instance.aperture();
        checkAge();

        //Because of animation time
        Invoke("nextLevel1", 1.0f);
        Invoke("nextLevel2", 2.0f);
    }

    #region InvokeFunctions
    private void saveGame() {
        SaveGameController.instance.saveGame();
    }

    private void updateLeaderboard() {
        long points = 0;
        points = Convert.ToInt64(Data.CurrentLevel - 1) * 100 + Convert.ToInt64(Data.SliderValue * 100);
        Debug.Log(points.ToString() + "pushed to Leaderboard");
        GooglePlayController.instance.updateLeaderboard(points, GPGSIds.leaderboard_leaderboard);
    }

    private void updateLastPlayed() {
        Data.LastPlayed = (DateTime.Now.Ticks / 10000000).ToString();
    }

    public void randomBonus() {
        if ((CONSTANTS.RANDOM_TIME / Mathf.Pow(CONSTANTS.CHEST_RANDOM, (Data.BronzeChestAmount + 1))) >= UnityEngine.Random.value) {
            chestRand.gameObject.SetActive(true);
            Debug.Log("BronzeChest triggered!");
        }

        if (((CONSTANTS.RANDOM_TIME * Data.GemMultiplier) / CONSTANTS.GEM_RANDOM) >= UnityEngine.Random.value) {
            gemRand.gameObject.SetActive(true);
            Debug.Log("Gem triggered!");
        }
    }

    private void updateAd() {
        if (Ads.instance.isRewardedAdReady()) {
            Debug.Log("Ad triggered!");
            ad.gameObject.SetActive(true);
        } else {
            ad.gameObject.SetActive(false);
        }
    }

    private void nextLevel1() {
        AnimationController.instance.setNextLevel(false);
        nextLevelButton.gameObject.SetActive(false);
        nextLevelInfo.gameObject.SetActive(true);

        Data.CurrentLevel++;

        Data.Points -= Data.NeededPoints;
        if (Data.CurrentLevel < CONSTANTS.MAX_LEVEL) {
            Data.NeededPoints = CONSTANTS.NEEDED_POINTS[Data.CurrentLevel - 1];
        } else {
            Data.NeededPoints = Mathf.Infinity;
        }
        Data.SliderValue = Data.Points / Data.NeededPoints;
        BackgroundController.instance.setMovingEnabled(true);
        
    }

    private void nextLevel2() {
        StorageController.instance.getSilverGoldChest();
        GooglePlayController.instance.achievements();
    }
    #endregion

    public void changeLanguage() {
        if (LANGUAGE.CUR_LANG == 0) {
            LANGUAGE.SET_LANGUAGE(1);
        } else {
            LANGUAGE.SET_LANGUAGE(0);
        }

    }

    public void nextLevelComplete()
    {
        Aperture.SetActive(false);
        checkAge();
    }
	    public void checkAge()
    {
		if(Data.CurrentLevel == 1)
		{
			if(levelSwitch == true)
			{
                Debug.Log(1);
				ArmorAgeOne.active = false;
				levelSwitch = false;
			}
		}
        else if (Data.CurrentLevel == 2)
        {
		    ArmorAgeTwo.active = true;

			if(levelSwitch == true)
            {
                Debug.Log(2);
                ArmorAgeTwo.active = false;
				levelSwitch = false;
			}
        }

        else if (Data.CurrentLevel == 3)
        {
			ArmorAgeThree.active = true;
			if(levelSwitch == true)
            {
                Debug.Log(3);
                ArmorAgeThree.active = false;
				levelSwitch = false;
			}

        }

        else if (Data.CurrentLevel == 4)
        {
            if (levelSwitch == true)
			{
            Debug.Log(4);
				ArmorAgeFour.active = false;
			}
			ArmorAgeFour.active = true;
			levelSwitch = false;
        }

        else if (Data.CurrentLevel == 5)
        {
			if(levelSwitch == true)
			{
				ArmorAgeFive.active = false;
			}
			ArmorAgeFive.active = true;
			levelSwitch = false;
        }

        else if (Data.CurrentLevel == 6)
        {
			if(levelSwitch == true)
			{
				ArmorAgeSix.active = false;
			}
			ArmorAgeSix.active = true;
			levelSwitch = false;
        }

        else if (Data.CurrentLevel == 7)
        {
			if(levelSwitch == true)
			{
				ArmorAgeSeven.active = false;
			}
			ArmorAgeSeven.active = true;
			levelSwitch = false;
        }

        else if (Data.CurrentLevel == 8)
        {
			if(levelSwitch == true)
			{
				ArmorAgeEight.active = false;
			}
			ArmorAgeEight.active = true;
			levelSwitch = false;
        }
    }

	  public void AchievementController()
    {
        if (Data.CurrentLevel >= 2 && AchievementSuccess_Age != true)
        {
            AchievementText.text = "Weiterentwicklung";
            AchievementSuccess_Age = true;
            StartCoroutine(disableAchievement());
        }

        else if (Data.ArmorLevel >= 3 && AchievementSuccess_Armor != true)
        {
            AchievementText.text = "Rüstungsheld";
            AchievementSuccess_Armor = true;
            StartCoroutine(disableAchievement());
        }

        else if (Data.BronzeChestAmount >= 2 && AchievementSuccess_Chest != true)
        {
            AchievementText.text = "Kistenheld";
            AchievementSuccess_Chest = true;
            StartCoroutine(disableAchievement());
        }
    }

    IEnumerator disableAchievement()
    {
        yield return new WaitForSeconds(3);
        AchievementText.text = "";
    }
}
