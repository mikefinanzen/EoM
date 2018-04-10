//Current data of the game
public static class Data {

    #region Level
    //CurrentLevel
    private static int currentLevel = -1;
    public static int CurrentLevel {
        get {
            return currentLevel;
        }
        set {
            if (currentLevel == value) return;
            currentLevel = value;
            if (OnCurrentLevelChange != null)
                OnCurrentLevelChange(currentLevel);
        }
    }
    public delegate void OnCurrentLevelChangeDelegate(int currentLevel);
    public static event OnCurrentLevelChangeDelegate OnCurrentLevelChange;
    #endregion

    #region Taps
    //TapsPerSec
    private static int tapsPerSec = -1;
    public static int TapsPerSec {
        get {
            return tapsPerSec;
        }
        set {
            if (tapsPerSec == value) return;
            tapsPerSec = value;
            if (OnTapsPerSecChange != null)
                OnTapsPerSecChange(tapsPerSec);
        }
    }
    public delegate void OnTapsPerSecChangeDelegate(int tapsPerSec);
    public static event OnTapsPerSecChangeDelegate OnTapsPerSecChange;

    //TapsPerSecRatio
    private static float tapsPerSecRatio = -1;
    public static float TapsPerSecRatio {
        get {
            return tapsPerSecRatio;
        }
        set {
            if (tapsPerSecRatio == value) return;
            tapsPerSecRatio = value;
            if (OnTapsPerSecRatioChange != null)
                OnTapsPerSecRatioChange(tapsPerSecRatio);
        }
    }
    public delegate void OnTapsPerSecRatioChangeDelegate(float tapsPerSecRatio);
    public static event OnTapsPerSecRatioChangeDelegate OnTapsPerSecRatioChange;
    #endregion

    #region Points
    //Points
    private static float points = -1;
    public static float Points {
        get {
            return points;
        }
        set {
            if (points == value) return;
            points = value;
            SliderValue = points / neededPoints;
            if (OnPointsChange != null)
                OnPointsChange(points);
        }
    }
    public delegate void OnPointsChangeDelegate(float points);
    public static event OnPointsChangeDelegate OnPointsChange;

    //NeededPoints
    private static float neededPoints = -1;
    public static float NeededPoints {
        get {
            return neededPoints;
        }
        set {
            if (neededPoints == value) return;
            neededPoints = value;
            if (OnNeededPointsChange != null)
                OnNeededPointsChange(neededPoints);
        }
    }
    public delegate void OnNeededPointsDelegate(float neededPoints);
    public static event OnNeededPointsDelegate OnNeededPointsChange;

    //PointsMultiplier
    private static float pointsMultiplier = -1;
    public static float PointsMultiplier {
        get {
            return pointsMultiplier;
        }
        set {
            if (pointsMultiplier == value) return;
            pointsMultiplier = value;
            if (OnPointsMultiplierChange != null)
                OnPointsMultiplierChange(pointsMultiplier);
        }
    }
    public delegate void OnPointsMultiplierDelegate(float pointsMultiplier);
    public static event OnPointsMultiplierDelegate OnPointsMultiplierChange;

    //GemMultiplier
    private static float gemMultiplier = -1;
    public static float GemMultiplier {
        get {
            return gemMultiplier;
        }
        set {
            if (gemMultiplier == value) return;
            gemMultiplier = value;
            if (OnGemMultiplierChange != null)
                OnGemMultiplierChange(gemMultiplier);
        }
    }
    public delegate void OnGemMultiplierDelegate(float gemMultiplier);
    public static event OnGemMultiplierDelegate OnGemMultiplierChange;
    #endregion

    #region UI
    //SliderValue
    private static float sliderValue = -1;
    public static float SliderValue {
        get {
            return sliderValue;
        }
        set {
            if (sliderValue == value) return;
            if  (value > 1.0f) {
                sliderValue = 1.0f;
            } else {
                sliderValue = value;
            }
            if (OnSliderValueChange != null)
                OnSliderValueChange(sliderValue);
        }
    }
    public delegate void OnSliderValueChangeDelegate(float sliderValue);
    public static event OnSliderValueChangeDelegate OnSliderValueChange;
    #endregion

    #region Storage
    #region Bronze
    //BronzeChestAmount
    private static int bronzeChestAmount = -1;
    public static int BronzeChestAmount {
        get {
            return bronzeChestAmount;
        }
        set {
            if (bronzeChestAmount == value) return;
            bronzeChestAmount = value;
            if (OnBronzeChestAmountChange != null)
                OnBronzeChestAmountChange(bronzeChestAmount);
        }
    }
    public delegate void OnBronzeChestAmountChangeDelegate(int bronzeChestAmount);
    public static event OnBronzeChestAmountChangeDelegate OnBronzeChestAmountChange;

    //BronzeChestTime
    private static int bronzeChestTime = -1;
    public static int BronzeChestTime {
        get {
            return bronzeChestTime;
        }
        set {
            if (bronzeChestTime == value) return;
            bronzeChestTime = value;
            if (OnBronzeChestTimeChange != null)
                OnBronzeChestTimeChange(bronzeChestTime);
        }
    }
    public delegate void OnBronzeChestTimeChangeDelegate(int bronzeChestTime);
    public static event OnBronzeChestTimeChangeDelegate OnBronzeChestTimeChange;
    #endregion

    #region Silver
    //SilverChestAmount
    private static int silverChestAmount = -1;
    public static int SilverChestAmount {
        get {
            return silverChestAmount;
        }
        set {
            if (silverChestAmount == value) return;
            silverChestAmount = value;
            if (OnSilverChestAmountChange != null)
                OnSilverChestAmountChange(silverChestAmount);
        }
    }
    public delegate void OnSilverChestAmountChangeDelegate(int silverChestAmount);
    public static event OnSilverChestAmountChangeDelegate OnSilverChestAmountChange;

    //SilverChestTime
    private static int silverChestTime = -1;
    public static int SilverChestTime {
        get {
            return silverChestTime;
        }
        set {
            if (silverChestTime == value) return;
            silverChestTime = value;
            if (OnSilverChestTimeChange != null)
                OnSilverChestTimeChange(silverChestTime);
        }
    }
    public delegate void OnSilverChestTimeChangeDelegate(int silverChestTime);
    public static event OnSilverChestTimeChangeDelegate OnSilverChestTimeChange;
    #endregion

    #region Gold
    //GoldChestAmount
    private static int goldChestAmount = -1;
    public static int GoldChestAmount {
        get {
            return goldChestAmount;
        }
        set {
            if (goldChestAmount == value) return;
            goldChestAmount = value;
            if (OnGoldChestAmountChange != null)
                OnGoldChestAmountChange(goldChestAmount);
        }
    }
    public delegate void OnGoldChestAmountChangeDelegate(int goldChestAmount);
    public static event OnGoldChestAmountChangeDelegate OnGoldChestAmountChange;

    //GoldChestTime
    private static int goldChestTime = -1;
    public static int GoldChestTime {
        get {
            return goldChestTime;
        }
        set {
            if (goldChestTime == value) return;
            goldChestTime = value;
            if (OnGoldChestTimeChange != null)
                OnGoldChestTimeChange(goldChestTime);
        }
    }
    public delegate void OnGoldChestTimeChangeDelegate(int goldChestTime);
    public static event OnGoldChestTimeChangeDelegate OnGoldChestTimeChange;
    #endregion

    #region Weapon
    //WeaponLevel
    private static int weaponLevel = -1;
    public static int WeaponLevel {
        get {
            return weaponLevel;
        }
        set {
            if (weaponLevel == value) return;
            weaponLevel = value;
            if (OnWeaponLevelChange != null)
                OnWeaponLevelChange(weaponLevel);
        }
    }
    public delegate void OnWeaponLevelChangeDelegate(int weaponLevel);
    public static event OnWeaponLevelChangeDelegate OnWeaponLevelChange;

    //WeaponPrice
    private static int weaponPrice = 0;
    public static int WeaponPrice {
        get {
            return weaponPrice;
        }
        set {
            if (weaponPrice == value) return;
            weaponPrice = value;
            if (OnWeaponPriceChange != null)
                OnWeaponPriceChange(weaponPrice);
        }
    }
    public delegate void OnWeaponPriceChangeDelegate(int weaponPrice);
    public static event OnWeaponPriceChangeDelegate OnWeaponPriceChange;
    #endregion

    #region passiveMovement
    //passiveMovementLevel
    private static int passiveMovementLevel = -1;
    public static int PassiveMovementLevel
    {
        get
        {
            return passiveMovementLevel;
        }
        set
        {
            if (passiveMovementLevel == value) return;
            passiveMovementLevel = value;
            if (OnWeaponLevelChange != null)
                OnWeaponLevelChange(weaponLevel);
        }
    }
    public delegate void OnPassiveMovementLevelChangeDelegate(int passiveMovementLevel);
    public static event OnPassiveMovementLevelChangeDelegate OnPassiveMovementLevelChange;

    //WeaponPrice
    private static int passiveMovementPrice = 0;
    public static int PassiveMovementPrice
    {
        get
        {
            return passiveMovementPrice;
        }
        set
        {
            if (passiveMovementPrice == value) return;
            weaponPrice = value;
            if (OnPassiveMovementPriceChange != null)
                OnPassiveMovementPriceChange(weaponPrice);
        }

    }
    public delegate void OnPassiveMovementPriceChangeDelegate(int passiveMovementPrice);
    public static event OnPassiveMovementPriceChangeDelegate OnPassiveMovementPriceChange;
    #endregion


    #region Armor
    //ArmorLevel
    private static int armorLevel = -1;
    public static int ArmorLevel {
        get {
            return armorLevel;
        }
        set {
            if (armorLevel == value) return;
            armorLevel = value;
            if (OnArmorLevelChange != null)
                OnArmorLevelChange(armorLevel);
        }
    }
    public delegate void OnArmorLevelChangeDelegate(int armorLevel);
    public static event OnArmorLevelChangeDelegate OnArmorLevelChange;

    //ArmorPrice
    private static int armorPrice = 0;
    public static int ArmorPrice {
        get {
            return armorPrice;
        }
        set {
            if (armorPrice == value) return;
            armorPrice = value;
            if (OnArmorPriceChange != null)
                OnArmorPriceChange(armorPrice);
        }
    }
    public delegate void OnArmorPriceChangeDelegate(int armorPrice);
    public static event OnArmorPriceChangeDelegate OnArmorPriceChange;
    #endregion
    #endregion

    #region Misc
    //LastPlayed
    private static string lastPlayed = "-1";
    public static string LastPlayed {
        get {
            return lastPlayed;
        }
        set {
            if (lastPlayed == value) return;
            lastPlayed = value;
            if (OnLastPlayedChange != null)
                OnLastPlayedChange(lastPlayed);
        }
    }
    public delegate void OnLastPlayedChangeDelegate(string lastPlayed);
    public static event OnLastPlayedChangeDelegate OnLastPlayedChange;
    
    //LastPlayedDifference
    private static int lastPlayedDifference = 0;
    public static int LastPlayedDifference {
        get {
            return lastPlayedDifference;
        }
        set {
            if (lastPlayedDifference == value) return;
            lastPlayedDifference = value;
            if (OnLastPlayedDifferenceChange != null)
                OnLastPlayedDifferenceChange(lastPlayedDifference);
        }
    }
    public delegate void OnLastPlayedDifferenceChangeDelegate(int lastPlayedDifference);
    public static event OnLastPlayedDifferenceChangeDelegate OnLastPlayedDifferenceChange;

    //Sound
    private static bool sound = true;
    public static bool Sound {
        get {
            return sound;
        }
        set {
            if (sound == value) return;
            sound = value;
            if (OnSoundChange != null)
                OnSoundChange(sound);
        }
    }
    public delegate void OnSoundChangeDelegate(bool sound);
    public static event OnSoundChangeDelegate OnSoundChange;

    //Notification
    private static bool notification = true;
    public static bool Notification {
        get {
            return notification;
        }
        set {
            if (notification == value) return;
            notification = value;
            if (OnNoitificationChange != null)
                OnNoitificationChange(notification);
        }
    }
    public delegate void OnNotificationChangeDelegate(bool notification);
    public static event OnNotificationChangeDelegate OnNoitificationChange;
    #endregion

    #region Gems
    //Gems
    private static int gems = -1;
    public static int Gems {
        get {
            return gems;
        }
        set {
            if (gems == value) return;
            gems = value;
            if (OnGemsChange != null)
                OnGemsChange(gems);
        }
    }
    public delegate void OnGemsChangeDelegate(int gems);
    public static event OnGemsChangeDelegate OnGemsChange;
    #endregion

    #region Boni
    //Brave
    private static int brave = -1;
    public static int Brave {
        get {
            return brave;
        }
        set {
            if (brave == value) return;
            brave = value;
            if (OnBraveChange != null)
                OnBraveChange(brave);
        }
    }
    public delegate void OnBraveChangeDelegate(int brave);
    public static event OnBraveChangeDelegate OnBraveChange;

    //Wisdom
    private static int wisdom = -1;
    public static int Wisdom {
        get {
            return wisdom;
        }
        set {
            if (wisdom == value) return;
            wisdom = value;
            if (OnWisdomChange != null)
                OnWisdomChange(wisdom);
        }
    }
    public delegate void OnWisdomChangeDelegate(int wisdom);
    public static event OnWisdomChangeDelegate OnWisdomChange;

    //Awesome
    private static int awesome = -1;
    public static int Awesome {
        get {
            return awesome;
        }
        set {
            if (awesome == value) return;
            awesome = value;
            if (OnAwesomeChange != null)
                OnAwesomeChange(awesome);
        }
    }
    public delegate void OnAwesomeChangeDelegate(int awesome);
    public static event OnAwesomeChangeDelegate OnAwesomeChange;

    //ChestReduction
    private static float chestReduction = -1;
    public static float ChestReduction {
        get {
            return chestReduction;
        }
        set {
            if (chestReduction == value) return;
            chestReduction = value;
            if (OnChestReductionChange != null)
                OnChestReductionChange(chestReduction);
        }
    }
    public delegate void OnChestReductionChangeDelegate(float chestReduction);
    public static event OnChestReductionChangeDelegate OnChestReductionChange;
    #endregion

    public static void RESET() {
        OnCurrentLevelChange = null;
        OnTapsPerSecChange = null;
        OnTapsPerSecRatioChange = null;
        OnPointsChange = null;
        OnNeededPointsChange = null;
        OnPointsMultiplierChange = null;
        OnGemMultiplierChange = null;
        OnSliderValueChange = null;
        OnBronzeChestAmountChange = null;
        OnBronzeChestTimeChange = null;
        OnSilverChestAmountChange = null;
        OnSilverChestTimeChange = null;
        OnGoldChestAmountChange = null;
        OnGoldChestTimeChange = null;
        OnWeaponLevelChange = null;
        OnWeaponPriceChange = null;
        OnArmorLevelChange = null;
        OnArmorPriceChange = null;
        OnPassiveMovementLevelChange = null;
        OnPassiveMovementPriceChange = null;
        OnLastPlayedChange = null;
        OnLastPlayedDifferenceChange = null;
        OnSoundChange = null;
        OnNoitificationChange = null;
        OnGemsChange = null;
        OnBraveChange = null;
        OnWisdomChange = null;
        OnAwesomeChange = null;
        OnChestReductionChange = null;

        currentLevel = -1;
        tapsPerSec = -1;
        TapsPerSecRatio = -1;
        points = -1;
        neededPoints = -1;
        pointsMultiplier = -1;
        gemMultiplier = -1;
        sliderValue = -1;
        bronzeChestAmount = -1;
        bronzeChestTime = -1;
        silverChestAmount = -1;
        silverChestTime = -1;
        goldChestAmount = -1;
        goldChestTime = -1;
        weaponLevel = -1;
        weaponPrice = 0;
        armorLevel = -1;
        armorPrice = 0;
        passiveMovementLevel = -1;
        passiveMovementPrice = 0;
        lastPlayed = "-1";
        lastPlayedDifference = 0;
        sound = true;
        notification = true;
        gems = -1;
        brave = -1;
        wisdom = -1;
        awesome = -1;
        chestReduction = -1;
    }
}
