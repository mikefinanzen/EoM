using UnityEngine;
using UnityEngine.UI;

//Class for updating text & some images
public class GUIController : GameController
{

    public static GUIController instance = null;

    //Points
    public Text pointsText;

    //Level
    public Slider sliderPoints;
    public Image sliderBackground;
    public Text ageText;
    public Text sliderText;
    public Text shopAgeText;
    public Text nextLevelInfoText;

    //Gems
    public Text[] gemTexts;

    //Chest
    public Animator chestReadyAnimator;
    public Button bronzeChest;
    public Button bronzeChestButton1;
    public Button bronzeChestButton2;
    public Button bronzeGemButton;
    public Button silverChest;
    public Button silverChestButton1;
    public Button silverChestButton2;
    public Button silverGemButton;
    public Button goldChest;
    public Button goldChestButton1;
    public Button goldChestButton2;
    public Button goldGemButton;
    public Text bronzeChestTimeText1;
    public Text bronzeChestTimeText2;
    public Text silverChestTimeText1;
    public Text silverChestTimeText2;
    public Text goldChestTimeText1;
    public Text goldChestTimeText2;
    public Text bronzeChestAmountText;
    public Text silverChestAmountText;
    public Text goldChestAmountText;

    //Weapon&Armor
    public Image weaponUpgradeImage;
    public Image armorUpgradeImage;
    public Button weaponUpgradeButton1;
    public Button armorUpgradeButton1;
    public Button weaponUpgradeButton2;
    public Button armorUpgradeButton2;
    public Image weaponBigImage;
    public Image weaponSmallImage;
    public Image armorBigImage;
    public Image armorSmallImage;
    public Text weaponPriceText;
    public Text armorPriceText;
    public Image[] weaponUpgradeStates;
    public Image[] weaponUpgradeNextStates;
    public Image[] armorUpgradeStates;
    public Image[] armorUpgradeNextStates;
    public Text weaponCurrentBonus;
    public Text armorCurrentBonus;

    //Upgrades
    public Image passivemovementUpgradeImage;
    public Button passivemovementUpgradeButton1;
    public Button passivemovementUpgradeButton2;
    public Image passivemovementBigImage;
    public Image passivemovementSmallImage;
    public Text passivemovementPriceText;
    public Image[] passivemovementUpgradeStates;
    public Image[] passivemovementUpgradeNextStates;
    public Text passivemovementCurrentBonus;

    //Boni
    public Text pointsMultiplierText;
    public Text gemMultiplierText;
    public Text chestReductionText;
    public Text braveText;
    public Text awesomeText;
    public Text wisdomText;

    //Settings
    public Button soundButton;
    public Button notificationButton;
    public Sprite[] settingsSprites;

    //MISC
    public Text settingsHeader;
    public Button settingsLanguageButton;
    public Text settingsLanguageText;
    public Sprite[] languageSprites;
    public Text settingsDelete;
    public Text storageHeader;
    public Text storageBronzeHeader;
    public Text storageBronzeText;
    public Text storageSilverHeader;
    public Text storageSilverText;
    public Text storageGoldHeader;
    public Text storageGoldText;
    public Text storageWeaponHeader;
    public Text storageWeaponText;
    public Text storageArmorHeader;
    public Text storageArmorText;
    public Text storagePassivemovementHeader;
    public Text storagePassivemovementText;
    public Text statusPoint;
    public Text statusGem;
    public Text statusChesttime;
    public Text statusBrave;
    public Text statusAwesome;
    public Text statusWisdom;
    public Text booster0;
    public Text booster1;
    public Text booster2;
    public Text booster3;
    public Text notificationOK;
    public Text notificationYES;
    public Text notificationNO;
    public Text apertureText;

    #region Start&Update
    void Awake() {
        instance = this;

        Data.OnPointsChange += OnPointsChangeHandler;
        Data.OnSliderValueChange += OnSliderValueChangeHanlder;
        Data.OnCurrentLevelChange += OnCurrentLevelChangeHandler;
        Data.OnGemsChange += OnGemsChangeHandler;
        //Chest
        Data.OnBronzeChestAmountChange += OnBronzeChestAmountChangeHandler;
        Data.OnSilverChestAmountChange += OnSilverChestAmountChangeHandler;
        Data.OnGoldChestAmountChange += OnGoldChestAmountChangeHandler;
        Data.OnBronzeChestTimeChange += OnBronzeChestTimeChangeHandler;
        Data.OnBronzeChestTimeChange += OnChestTimeChangeHandler;
        Data.OnSilverChestTimeChange += OnSilverChestTimeChangeHandler;
        Data.OnSilverChestTimeChange += OnChestTimeChangeHandler;
        Data.OnGoldChestTimeChange += OnGoldChestTimeChangeHandler;
        Data.OnGoldChestTimeChange += OnChestTimeChangeHandler;
        //Weapon&Armor
        Data.OnWeaponLevelChange += OnWeaponLevelChangeHandler;
        Data.OnArmorLevelChange += OnArmorLevelChangeHandler;
        //Boni
        Data.OnPointsMultiplierChange += OnPointsMultiplierChangeHandler;
        Data.OnGemMultiplierChange += OnGemMultiplierChangeHandler;
        Data.OnBraveChange += OnBraveChangeHandler;
        Data.OnAwesomeChange += OnAwesomeChangeHandler;
        Data.OnWisdomChange += OnWisdomChangeHandler;
        Data.OnChestReductionChange += OnChestReductionChangeHandler;
        //Settings
        Data.OnSoundChange += OnSoundChangeHandler;
        Data.OnNoitificationChange += OnNotificationChangeHandler;
    }
    #endregion

    #region Handler
    private void OnCurrentLevelChangeHandler(int currentLevel) {
        ageText.text = CONSTANTS.AGE_NAMES[currentLevel - 1];
        shopAgeText.text = string.Format(LANGUAGE.GUI_SHOP[LANGUAGE.CUR_LANG], (((currentLevel - 1) / CONSTANTS.LEVELS_PER_AGE) + 1), (((currentLevel - 1) % CONSTANTS.LEVELS_PER_AGE) + 1));
        if (currentLevel == CONSTANTS.MAX_LEVEL) {
            sliderBackground.color = new Color32(0xA8, 0x1D, 0x1D, 0xFF);
            sliderText.enabled = false;
            nextLevelInfoText.text = LANGUAGE.GUI_NEXTLEVEL_NO[LANGUAGE.CUR_LANG];
        } else {
            nextLevelInfoText.text = string.Format(LANGUAGE.GUI_NEXTLEVEL_YES[LANGUAGE.CUR_LANG], CONSTANTS.AGE_NAMES[currentLevel]);
        }
    }

    private void OnPointsChangeHandler(float points) {
        pointsText.text = Mathf.Floor(points).ToString();
    }

    private void OnSliderValueChangeHanlder(float sliderValue) {
        sliderPoints.value = sliderValue;
        sliderText.text = string.Format("{0:###.00}%", (sliderValue * 100).ToString("F2"));
    }

    private void OnGemsChangeHandler(int gems) {
        foreach (Text gemText in gemTexts) {
            gemText.text = gems.ToString();
        }
    }

    //Chest
    private void OnBronzeChestAmountChangeHandler(int bronzeChestAmount) {
        if (bronzeChestAmount >= 1) {
            bronzeChest.interactable = true;
            bronzeChest.image.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
            bronzeChestButton1.gameObject.SetActive(true);
            bronzeChestAmountText.text = bronzeChestAmount.ToString();
        } else {
            bronzeChest.interactable = false;
            bronzeChest.image.color = new Color32(0x0, 0x0, 0x0, 0x80);
            bronzeChestButton1.gameObject.SetActive(false);
            bronzeChestAmountText.text = "";
        }
    }

    private void OnSilverChestAmountChangeHandler(int silverChestAmount) {
        if (silverChestAmount >= 1) {
            silverChest.interactable = true;
            silverChest.image.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
            silverChestButton1.gameObject.SetActive(true);
            silverChestAmountText.text = silverChestAmount.ToString();
        } else {
            silverChest.interactable = false;
            silverChest.image.color = new Color32(0x0, 0x0, 0x0, 0x80);
            silverChestButton1.gameObject.SetActive(false);
            silverChestAmountText.text = "";
        }
    }

    private void OnGoldChestAmountChangeHandler(int goldChestAmount) {
        if (goldChestAmount >= 1) {
            goldChest.interactable = true;
            goldChest.image.color = new Color32(0xFF, 0xFF, 0xFF, 0xFF);
            goldChestButton1.gameObject.SetActive(true);
            goldChestAmountText.text = goldChestAmount.ToString();
        } else {
            goldChest.interactable = false;
            goldChest.image.color = new Color32(0x0, 0x0, 0x0, 0x80);
            goldChestButton1.gameObject.SetActive(false);
            goldChestAmountText.text = "";
        }
    }

    private void OnBronzeChestTimeChangeHandler(int bronzeChestTime) {
        if (bronzeChestTime > 0) {
            bronzeChestTimeText1.text = CONSTANTS.SECONDS_TO_STRING(bronzeChestTime);
            bronzeChestTimeText2.text = CONSTANTS.SECONDS_TO_STRING(bronzeChestTime);
            bronzeChestButton1.image.color = new Color32(0xC6, 0x1E, 0x1E, 0xFF);
            bronzeChestButton2.image.color = new Color32(0xC6, 0x1E, 0x1E, 0xFF);
            bronzeGemButton.gameObject.SetActive(true);
        } else {
            bronzeChestTimeText1.text = LANGUAGE.GUI_CHEST_OPEN[LANGUAGE.CUR_LANG];
            bronzeChestTimeText2.text = LANGUAGE.GUI_CHEST_OPEN[LANGUAGE.CUR_LANG];
            bronzeChestButton1.image.color = new Color32(0x28, 0xC4, 0x20, 0xFF);
            bronzeChestButton2.image.color = new Color32(0x28, 0xC4, 0x20, 0xFF);
            bronzeGemButton.gameObject.SetActive(false);
        }
    }

    private void OnSilverChestTimeChangeHandler(int silverChestTime) {
        if (silverChestTime > 0) {
            silverChestTimeText1.text = CONSTANTS.SECONDS_TO_STRING(silverChestTime);
            silverChestTimeText2.text = CONSTANTS.SECONDS_TO_STRING(silverChestTime);
            silverChestButton1.image.color = new Color32(0xC6, 0x1E, 0x1E, 0xFF);
            silverChestButton2.image.color = new Color32(0xC6, 0x1E, 0x1E, 0xFF);
            silverGemButton.gameObject.SetActive(true);
        } else {
            silverChestTimeText1.text = LANGUAGE.GUI_CHEST_OPEN[LANGUAGE.CUR_LANG];
            silverChestTimeText2.text = LANGUAGE.GUI_CHEST_OPEN[LANGUAGE.CUR_LANG];
            silverChestButton1.image.color = new Color32(0x28, 0xC4, 0x20, 0xFF);
            silverChestButton2.image.color = new Color32(0x28, 0xC4, 0x20, 0xFF);
            silverGemButton.gameObject.SetActive(false);
        }
    }

    private void OnGoldChestTimeChangeHandler(int goldChestTime) {
        if (goldChestTime > 0) {
            goldChestTimeText1.text = CONSTANTS.SECONDS_TO_STRING(goldChestTime);
            goldChestTimeText2.text = CONSTANTS.SECONDS_TO_STRING(goldChestTime);
            goldChestButton1.image.color = new Color32(0xC6, 0x1E, 0x1E, 0xFF);
            goldChestButton2.image.color = new Color32(0xC6, 0x1E, 0x1E, 0xFF);
            goldGemButton.gameObject.SetActive(true);
        } else {
            goldChestTimeText1.text = LANGUAGE.GUI_CHEST_OPEN[LANGUAGE.CUR_LANG];
            goldChestTimeText2.text = LANGUAGE.GUI_CHEST_OPEN[LANGUAGE.CUR_LANG];
            goldChestButton1.image.color = new Color32(0x28, 0xC4, 0x20, 0xFF);
            goldChestButton2.image.color = new Color32(0x28, 0xC4, 0x20, 0xFF);
            goldGemButton.gameObject.SetActive(false);
        }
    }

    public void OnChestTimeChangeHandler(int chestTime) {
        if (((Data.BronzeChestTime == 0) && (Data.BronzeChestAmount >= 1)) || ((Data.SilverChestTime == 0) && (Data.SilverChestAmount >= 1)) || ((Data.GoldChestTime == 0) && (Data.GoldChestAmount >= 1))) {
            chestReadyAnimator.SetBool("chestReady", true);
        } else {
            chestReadyAnimator.SetBool("chestReady", false);
        }
    }

    //Weapon&Armor
    private void OnWeaponLevelChangeHandler(int weaponLevel) {
        Texture2D texture;
        Rect rec;
        Sprite sprite;

        weaponPriceText.text = string.Format("{0} Kyanit", Data.WeaponPrice);
        weaponCurrentBonus.text = string.Format(LANGUAGE.GUI_WEAPON_CURRENT[LANGUAGE.CUR_LANG], (weaponLevel * Mathf.RoundToInt(CONSTANTS.POINTS_MULTIPLIER_PERCENT * 100)));

        if (weaponLevel == CONSTANTS.MAX_WEAPON_LEVEL * CONSTANTS.UPGRADES_PER_LEVEL) {
            weaponUpgradeImage.gameObject.SetActive(false);
            weaponUpgradeButton1.gameObject.SetActive(false);
            weaponUpgradeButton2.enabled = false;
        }
        if (weaponLevel > 0) {
            texture = Resources.Load("weapons/" + Mathf.CeilToInt((float)weaponLevel / CONSTANTS.UPGRADES_PER_LEVEL)) as Texture2D;
            rec = new Rect(0, 0, texture.width, texture.height);
            sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);

            weaponBigImage.sprite = sprite;

            foreach (Image weaponUpgradeState in weaponUpgradeStates) {
                weaponUpgradeState.color = new Color32(0x5E, 0x5E, 0x5E, 0xFF);
            }
            foreach (Image weaponUpgradeNextState in weaponUpgradeNextStates) {
                weaponUpgradeNextState.color = new Color32(0x5E, 0x5E, 0x5E, 0xFF);
            }
            for (int i = 0; i < ((weaponLevel - 1) % CONSTANTS.UPGRADES_PER_LEVEL + 1); i++) {
                weaponUpgradeStates[i].color = new Color32(0xD4, 0xAF, 0x37, 0xFF);
            }
            for (int i = 0; i < (weaponLevel % CONSTANTS.UPGRADES_PER_LEVEL + 1); i++) {
                weaponUpgradeNextStates[i].color = new Color32(0xD4, 0xAF, 0x37, 0xFF);
            }
        }
        if (weaponLevel <= CONSTANTS.MAX_WEAPON_LEVEL * CONSTANTS.UPGRADES_PER_LEVEL - 1) {
            texture = Resources.Load("weapons/" + Mathf.CeilToInt((float)(weaponLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL)) as Texture2D;
            rec = new Rect(0, 0, texture.width, texture.height);
            sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);

            storageWeaponText.text = LANGUAGE.SC_WEAPON_TEXT[LANGUAGE.CUR_LANG][Mathf.CeilToInt((float)(weaponLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL) - 1];

            weaponSmallImage.sprite = sprite;
        }
    }

    private void OnArmorLevelChangeHandler(int armorLevel)
    {
        Texture2D texture;
        Rect rec;
        Sprite sprite;

        armorPriceText.text = string.Format("{0} Kyanit", Data.ArmorPrice);
        armorCurrentBonus.text = string.Format(LANGUAGE.GUI_ARMOR_CURRENT[LANGUAGE.CUR_LANG], (armorLevel * Mathf.RoundToInt(CONSTANTS.GEM_MULTIPLIER_PERCENT * 100)));

        if (armorLevel == CONSTANTS.MAX_ARMOR_LEVEL * CONSTANTS.UPGRADES_PER_LEVEL) {
            armorUpgradeImage.gameObject.SetActive(false);
            armorUpgradeButton1.gameObject.SetActive(false);
            armorUpgradeButton2.enabled = false;
        }
        if (armorLevel > 0) {
            texture = Resources.Load("armors/" + Mathf.CeilToInt((float)armorLevel / CONSTANTS.UPGRADES_PER_LEVEL)) as Texture2D;
            rec = new Rect(0, 0, texture.width, texture.height);
            sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);

            armorBigImage.sprite = sprite;

            foreach (Image armorUpgradeState in armorUpgradeStates) {
                armorUpgradeState.color = new Color32(0x5E, 0x5E, 0x5E, 0xFF);
            }
            foreach (Image armorUpgradeNextState in armorUpgradeNextStates) {
                armorUpgradeNextState.color = new Color32(0x5E, 0x5E, 0x5E, 0xFF);
            }
            for (int i = 0; i < ((armorLevel - 1) % CONSTANTS.UPGRADES_PER_LEVEL + 1); i++) {
                armorUpgradeStates[i].color = new Color32(0xD4, 0xAF, 0x37, 0xFF);
            }
            for (int i = 0; i < (armorLevel % CONSTANTS.UPGRADES_PER_LEVEL + 1); i++) {
                armorUpgradeNextStates[i].color = new Color32(0xD4, 0xAF, 0x37, 0xFF);
            }
        }
        if (armorLevel <= CONSTANTS.MAX_ARMOR_LEVEL * CONSTANTS.UPGRADES_PER_LEVEL - 1) {
            texture = Resources.Load("armors/" + Mathf.CeilToInt((float)(armorLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL)) as Texture2D;
            rec = new Rect(0, 0, texture.width, texture.height);
            sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);

            storageArmorText.text = LANGUAGE.SC_ARMOR_TEXT[LANGUAGE.CUR_LANG][Mathf.CeilToInt((float)(armorLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL) - 1];

            armorSmallImage.sprite = sprite;
        }
    }

    //Upgrades

    private void OnPassiveMovementLevelChangeHandler(int passivemovementLevel)
    {
        Texture2D texture;
        Rect rec;
        Sprite sprite;

        passivemovementPriceText.text = string.Format("{0} Kyanit", Data.PassiveMovementPrice);
        passivemovementCurrentBonus.text = string.Format(LANGUAGE.GUI_PASSIVEMOVEMENT_CURRENT[LANGUAGE.CUR_LANG], (passivemovementLevel * Mathf.RoundToInt(CONSTANTS.POINTS_MULTIPLIER_PERCENT * 100)));

        if (passivemovementLevel == CONSTANTS.MAX_PASSIVEMOVEMENT_LEVEL * CONSTANTS.UPGRADES_PER_LEVEL)
        {
            passivemovementUpgradeImage.gameObject.SetActive(false);
            passivemovementUpgradeButton1.gameObject.SetActive(false);
            passivemovementUpgradeButton2.enabled = false;
        }
        if (passivemovementLevel > 0)
        {
            texture = Resources.Load("passivemovement/" + Mathf.CeilToInt((float)passivemovementLevel / CONSTANTS.UPGRADES_PER_LEVEL)) as Texture2D;
            rec = new Rect(0, 0, texture.width, texture.height);
            sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);

            passivemovementBigImage.sprite = sprite;

            foreach (Image passivemovementUpgradeState in passivemovementUpgradeStates)
            {
                passivemovementUpgradeState.color = new Color32(0x5E, 0x5E, 0x5E, 0xFF);
                Debug.Log("Gelb");
            }
            foreach (Image passivemovementUpgradeNextState in passivemovementUpgradeNextStates)
            {
                passivemovementUpgradeNextState.color = new Color32(0x5E, 0x5E, 0x5E, 0xFF);
            }
            for (int i = 0; i < ((passivemovementLevel - 1) % CONSTANTS.UPGRADES_PER_LEVEL + 1); i++)
            {
                passivemovementUpgradeStates[i].color = new Color32(0xD4, 0xAF, 0x37, 0xFF);
            }
            for (int i = 0; i < (passivemovementLevel % CONSTANTS.UPGRADES_PER_LEVEL + 1); i++)
            {
                passivemovementUpgradeNextStates[i].color = new Color32(0xD4, 0xAF, 0x37, 0xFF);
            }
        }
        if (passivemovementLevel <= CONSTANTS.MAX_PASSIVEMOVEMENT_LEVEL * CONSTANTS.UPGRADES_PER_LEVEL - 1)
        {
            texture = Resources.Load("passivemovement/" + Mathf.CeilToInt((float)(passivemovementLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL)) as Texture2D;
            rec = new Rect(0, 0, texture.width, texture.height);
            sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);

            storagePassivemovementText.text = LANGUAGE.SC_PASSIVEMOVEMENT_TEXT[LANGUAGE.CUR_LANG][Mathf.CeilToInt((float)(passivemovementLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL) - 1];

            passivemovementSmallImage.sprite = sprite;
        }
    }

    //Boni
    private void OnPointsMultiplierChangeHandler(float pointsMultiplier) {
        pointsMultiplierText.text = string.Format("{0}%", Mathf.RoundToInt((pointsMultiplier - 1) * 100));
    }

    private void OnGemMultiplierChangeHandler(float gemMultiplier) {
        gemMultiplierText.text = string.Format("{0}%", Mathf.RoundToInt((gemMultiplier - 1) * 100));
        bronzeGemButton.GetComponentInChildren<Text>().text = string.Format("{0} Kyanit", Mathf.RoundToInt(CONSTANTS.BRONZE_CHEST_PRICE * gemMultiplier));
        silverGemButton.GetComponentInChildren<Text>().text = string.Format("{0} Kyanit", Mathf.RoundToInt(CONSTANTS.SILVER_CHEST_PRICE * gemMultiplier));
        goldGemButton.GetComponentInChildren<Text>().text = string.Format("{0} Kyanit", Mathf.RoundToInt(CONSTANTS.GOLD_CHEST_PRICE * gemMultiplier));
    }

    private void OnBraveChangeHandler(int brave) {
        braveText.text = string.Format("{0}%", brave);
    }

    private void OnAwesomeChangeHandler(int awesome) {
        awesomeText.text = string.Format("{0}%", awesome);
    }

    private void OnWisdomChangeHandler(int wisdom) {
        wisdomText.text = string.Format("{0}%", wisdom);
    }

    private void OnChestReductionChangeHandler(float chestReduction) {
        chestReductionText.text = string.Format("{0}%", Mathf.RoundToInt(chestReduction * 100));
    }

    //Settings
    private void OnSoundChangeHandler(bool sound) {
        if (sound) {
            soundButton.GetComponent<Image>().sprite = settingsSprites[0];
        } else {
            soundButton.GetComponent<Image>().sprite = settingsSprites[1];
        }
    }

    private void OnNotificationChangeHandler(bool notification) {
        if (notification) {
            notificationButton.GetComponent<Image>().sprite = settingsSprites[2];
        } else {
            notificationButton.GetComponent<Image>().sprite = settingsSprites[3];
        }
    }
    #endregion

    public void setLanguage()
    {
        settingsHeader.text = LANGUAGE.GUI_SETTINGS_HEADER[LANGUAGE.CUR_LANG];
        settingsLanguageButton.GetComponent<Image>().sprite = languageSprites[LANGUAGE.CUR_LANG];
        settingsLanguageText.text = LANGUAGE.GUI_SETTINGS_LANGUAGE[LANGUAGE.CUR_LANG];
        settingsDelete.text = LANGUAGE.GUI_SETTINGS_DELETE[LANGUAGE.CUR_LANG];
        storageHeader.text = LANGUAGE.GUI_STORAGE_HEADER[LANGUAGE.CUR_LANG];
        storageBronzeHeader.text = LANGUAGE.GUI_BRONZE_HEADER[LANGUAGE.CUR_LANG];
        storageBronzeText.text = LANGUAGE.GUI_BRONZE_TEXT[LANGUAGE.CUR_LANG];
        storageSilverHeader.text = LANGUAGE.GUI_SILVER_HEADER[LANGUAGE.CUR_LANG];
        storageSilverText.text = LANGUAGE.GUI_SILVER_TEXT[LANGUAGE.CUR_LANG];
        storageGoldHeader.text = LANGUAGE.GUI_GOLD_HEADER[LANGUAGE.CUR_LANG];
        storageGoldText.text = LANGUAGE.GUI_GOLD_TEXT[LANGUAGE.CUR_LANG];
        storageWeaponHeader.text = LANGUAGE.GUI_WEAPON_HEADER[LANGUAGE.CUR_LANG];
        int index = ((Mathf.CeilToInt((float)(Data.WeaponLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL) - 1) < CONSTANTS.MAX_WEAPON_LEVEL) ? (Mathf.CeilToInt((float)(Data.WeaponLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL) - 1) : (CONSTANTS.MAX_WEAPON_LEVEL - 1);
        storageWeaponText.text = LANGUAGE.SC_WEAPON_TEXT[LANGUAGE.CUR_LANG][index];
        storageArmorHeader.text = LANGUAGE.GUI_ARMOR_HEADER[LANGUAGE.CUR_LANG];
        index = ((Mathf.CeilToInt((float)(Data.ArmorLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL) - 1) < CONSTANTS.MAX_ARMOR_LEVEL) ? (Mathf.CeilToInt((float)(Data.ArmorLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL) - 1) : (CONSTANTS.MAX_ARMOR_LEVEL - 1);
        storageArmorText.text = LANGUAGE.SC_ARMOR_TEXT[LANGUAGE.CUR_LANG][index];
        statusPoint.text = LANGUAGE.GUI_STATUS_POINT[LANGUAGE.CUR_LANG];
        statusGem.text = LANGUAGE.GUI_STATUS_GEM[LANGUAGE.CUR_LANG];
        statusChesttime.text = LANGUAGE.GUI_STATUS_CHESTTIME[LANGUAGE.CUR_LANG];
        statusBrave.text = LANGUAGE.GUI_STATUS_BRAVE[LANGUAGE.CUR_LANG];
        statusAwesome.text = LANGUAGE.GUI_STATUS_AWESOME[LANGUAGE.CUR_LANG];
        statusWisdom.text = LANGUAGE.GUI_STATUS_WISDOM[LANGUAGE.CUR_LANG];
        booster0.text = LANGUAGE.GUI_BOOSTER_0[LANGUAGE.CUR_LANG];
        booster1.text = LANGUAGE.GUI_BOOSTER_1[LANGUAGE.CUR_LANG];
        booster2.text = LANGUAGE.GUI_BOOSTER_2[LANGUAGE.CUR_LANG];
        booster3.text = LANGUAGE.GUI_BOOSTER_3[LANGUAGE.CUR_LANG];
        notificationOK.text = LANGUAGE.GUI_NOTIFICATION_OK[LANGUAGE.CUR_LANG];
        notificationYES.text = LANGUAGE.GUI_NOTIFICATION_YES[LANGUAGE.CUR_LANG];
        notificationNO.text = LANGUAGE.GUI_NOTIFICATION_NO[LANGUAGE.CUR_LANG];
    }

    public void setApertureText() {
        apertureText.text = CONSTANTS.AGE_NAMES[Data.CurrentLevel].Replace(":", "\n");
    }
}
