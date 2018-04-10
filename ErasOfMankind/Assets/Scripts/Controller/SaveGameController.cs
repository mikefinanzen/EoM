using UnityEngine;

//Class for loading & saving game
public class SaveGameController : MonoBehaviour {

    public static SaveGameController instance = null;

    #region Start&Update
    void Awake() {
        instance = this;

        Data.OnCurrentLevelChange += OnCurrentLevelChangeHandler;
        Data.OnPointsChange += OnPointsChangeHandler;

        Data.OnBronzeChestAmountChange += OnBronzeChestAmountChangeHandler;
        Data.OnBronzeChestTimeChange += OnBronzeChestTimeChangeHandler;
        Data.OnSilverChestAmountChange += OnSilverChestAmountChangeHandler;
        Data.OnSilverChestTimeChange += OnSilverChestTimeChangeHandler;
        Data.OnGoldChestAmountChange += OnGoldChestAmountChangeHandler;
        Data.OnGoldChestTimeChange += OnGoldChestTimeChangeHandler;

        Data.OnWeaponLevelChange += OnWeaponLevelChangeHandler;
        Data.OnArmorLevelChange += OnArmorLevelChangeHandler;

        Data.OnLastPlayedChange += OnLastPlayedChangeHandler;

        Data.OnGemsChange += OnGemsChangeHandler;

        Data.OnBraveChange += OnBraveChangeHandler;
        Data.OnAwesomeChange += OnAwesomeChangeHandler;
        Data.OnWisdomChange += OnWisdomChangeHandler;
        Data.OnChestReductionChange += OnChestReductionChangeHandler;

        Data.OnSoundChange += OnSoundChangeHandler;
        Data.OnNoitificationChange += OnNotificationChangeHandler;
    }
    #endregion

    #region Handler
    #region Points
    private void OnCurrentLevelChangeHandler(int currentLevel) {
        EncryptedPlayerPrefs.SetInt("currentLevel", currentLevel);
    }
    private void OnPointsChangeHandler(float points) {
        EncryptedPlayerPrefs.SetFloat("points", points);
    }
    #endregion

    #region Storage
    private void OnBronzeChestAmountChangeHandler(int bronzeChestAmount) {
        EncryptedPlayerPrefs.SetInt("bronzeChestAmount", bronzeChestAmount);
    }
    private void OnBronzeChestTimeChangeHandler(int bronzeChestTime) {
        EncryptedPlayerPrefs.SetInt("bronzeChestTime", bronzeChestTime);
    }
    private void OnSilverChestAmountChangeHandler(int silverChestAmount) {
        EncryptedPlayerPrefs.SetInt("silverChestAmount", silverChestAmount);
    }
    private void OnSilverChestTimeChangeHandler(int silverChestTime) {
        EncryptedPlayerPrefs.SetInt("silverChestTime", silverChestTime);
    }
    private void OnGoldChestAmountChangeHandler(int goldChestAmount) {
        EncryptedPlayerPrefs.SetInt("goldChestAmount", goldChestAmount);
    }
    private void OnGoldChestTimeChangeHandler(int goldChestTime) {
        EncryptedPlayerPrefs.SetInt("goldChestTime", goldChestTime);
    }
    private void OnWeaponLevelChangeHandler(int weaponLevel) {
        EncryptedPlayerPrefs.SetInt("weaponLevel", weaponLevel);
    }
    private void OnArmorLevelChangeHandler(int armorLevel) {
        EncryptedPlayerPrefs.SetInt("armorLevel", armorLevel);
    }
    #endregion

    #region Misc
    private void OnLastPlayedChangeHandler(string lastPlayed) {
        EncryptedPlayerPrefs.SetString("lastPlayed", lastPlayed);
    }
    private void OnSoundChangeHandler(bool sound) {
        EncryptedPlayerPrefs.SetInt("sound", (sound) ? 1 : 0);
    }
    private void OnNotificationChangeHandler(bool notification) {
        EncryptedPlayerPrefs.SetInt("notification", (notification) ? 1 : 0);
    }
    #endregion

    #region Gems
    private void OnGemsChangeHandler(int gems) {
        EncryptedPlayerPrefs.SetInt("gems", gems);
    }
    #endregion

    #region Boni
    private void OnBraveChangeHandler(int brave) {
        EncryptedPlayerPrefs.SetInt("brave", brave);
    }
    private void OnAwesomeChangeHandler(int awesome) {
        EncryptedPlayerPrefs.SetInt("awesome", awesome);
    }
    private void OnWisdomChangeHandler(int wisdom) {
        EncryptedPlayerPrefs.SetInt("wisdom", wisdom);
    }
    private void OnChestReductionChangeHandler(float chestReduction) {
        EncryptedPlayerPrefs.SetFloat("chestReduction", chestReduction);
    }
    #endregion

    #endregion

    public void saveGame() {
        Debug.Log("Saving Savegame...");
        EncryptedPlayerPrefs.Save();
        Debug.Log("Saved Savegame!");
    }

    public void loadGame() {
        Debug.Log("Loading Savegame...");
        Data.CurrentLevel = EncryptedPlayerPrefs.GetInt("currentLevel", 1);
        Data.Points = EncryptedPlayerPrefs.GetFloat("points", 0.0f);
        
        Data.BronzeChestAmount = EncryptedPlayerPrefs.GetInt("bronzeChestAmount", 0);
        Data.BronzeChestTime = EncryptedPlayerPrefs.GetInt("bronzeChestTime", 0);
        Data.SilverChestAmount = EncryptedPlayerPrefs.GetInt("silverChestAmount", 0);
        Data.SilverChestTime = EncryptedPlayerPrefs.GetInt("silverChestTime", 0);
        Data.GoldChestAmount = EncryptedPlayerPrefs.GetInt("goldChestAmount", 0);
        Data.GoldChestTime = EncryptedPlayerPrefs.GetInt("goldChestTime", 0);

        int weaponLevel = EncryptedPlayerPrefs.GetInt("weaponLevel", 0);
        int index = System.Math.Min(Mathf.CeilToInt((float)(weaponLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL) - 1, CONSTANTS.MAX_WEAPON_LEVEL - 1);
        Data.WeaponPrice = CONSTANTS.WEAPON_PRICE[index] + (weaponLevel % CONSTANTS.UPGRADES_PER_LEVEL) * CONSTANTS.WEAPON_PRICE_SMALL[index];
        Data.WeaponLevel = weaponLevel;

        int armorLevel = EncryptedPlayerPrefs.GetInt("armorLevel", 0);
        index = System.Math.Min(Mathf.CeilToInt((float)(armorLevel + 1) / CONSTANTS.UPGRADES_PER_LEVEL) - 1, CONSTANTS.MAX_ARMOR_LEVEL - 1);
        Data.ArmorPrice = CONSTANTS.ARMOR_PRICE[index] + (armorLevel % CONSTANTS.UPGRADES_PER_LEVEL) * CONSTANTS.ARMOR_PRICE_SMALL[index];
        Data.ArmorLevel = armorLevel;

        Data.LastPlayed = EncryptedPlayerPrefs.GetString("lastPlayed", (System.DateTime.Now.Ticks / 10000000).ToString());

        Data.Gems = EncryptedPlayerPrefs.GetInt("gems", 50);

        Data.Brave = EncryptedPlayerPrefs.GetInt("brave", 0);
        Data.Awesome = EncryptedPlayerPrefs.GetInt("awesome", 0);
        Data.Wisdom = EncryptedPlayerPrefs.GetInt("wisdom", 0);
        Data.ChestReduction = EncryptedPlayerPrefs.GetFloat("chestReduction", 0.0f);

        Data.Sound = (EncryptedPlayerPrefs.GetInt("sound", 1) == 1);
        Data.Notification = (EncryptedPlayerPrefs.GetInt("notification", 1) == 1);

        Debug.Log("Loaded Savegame!");
    }

    public void deleteQuestion() {
        NotificationController.instance.addAction(NotificationController.Action.DeleteGame);
        NotificationController.instance.addNotification(LANGUAGE.SGC_DELETE_1[LANGUAGE.CUR_LANG]);
        NotificationController.instance.addNotification(LANGUAGE.SGC_DELETE_2[LANGUAGE.CUR_LANG]);
        NotificationController.instance.setAcceptDecline(true);
        NotificationController.instance.showNotification();
    }

    public void delete() {
        Debug.Log("Deleting Savegame...");
        EncryptedPlayerPrefs.SetInt("currentLevel", 1);
        EncryptedPlayerPrefs.SetFloat("points", 0.0f);
   
        EncryptedPlayerPrefs.SetInt("bronzeChestAmount", 0);
        EncryptedPlayerPrefs.SetInt("bronzeChestTime", 0);
        EncryptedPlayerPrefs.SetInt("silverChestAmount", 0);
        EncryptedPlayerPrefs.SetInt("silverChestTime", 0);
        EncryptedPlayerPrefs.SetInt("goldChestAmount", 0);
        EncryptedPlayerPrefs.SetInt("goldChestTime", 0);

        EncryptedPlayerPrefs.SetInt("weaponLevel", 0);
        EncryptedPlayerPrefs.SetInt("armorLevel", 0);

        EncryptedPlayerPrefs.SetString("lastPlayed", (System.DateTime.Now.Ticks / 10000000).ToString());

        EncryptedPlayerPrefs.SetInt("gems", 50);

        EncryptedPlayerPrefs.SetInt("brave", 0);
        EncryptedPlayerPrefs.SetInt("awesome", 0);
        EncryptedPlayerPrefs.SetInt("wisdom", 0);
        EncryptedPlayerPrefs.SetFloat("chestReduction", 0.0f);

        EncryptedPlayerPrefs.SetInt("sound", 1);
        EncryptedPlayerPrefs.SetInt("notification", 1);

        EncryptedPlayerPrefs.SetInt(Application.version.ToString(), 0);
        EncryptedPlayerPrefs.SetInt("language", 0);

        saveGame();
        Debug.Log("Deleted Savegame!");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
