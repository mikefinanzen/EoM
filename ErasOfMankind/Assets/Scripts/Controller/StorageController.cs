using System;
using UnityEngine;
using UnityEngine.UI;

//Class for handling Storage Menu
public class StorageController : MonoBehaviour
{

    public static StorageController instance = null;

    public Button chestRand;

    #region Start&Update
    void Awake() {
        instance = this;

        Data.OnLastPlayedDifferenceChange += OnLastPlayedDifferenceChangeHandler;

        Data.OnWeaponLevelChange += OnWeaponLevelChangeHandler;
        Data.OnArmorLevelChange += OnArmorLevelChangeHandler;
        Data.OnPassiveMovementLevelChange += OnPassivemovementChangeHandler;
    }

    void Start() {
        InvokeRepeating("updateChestTime", CONSTANTS.UPDATE_CHESTTIME_TIME, CONSTANTS.UPDATE_CHESTTIME_TIME);
    }
    #endregion

    public void addTime() {
        Data.BronzeChestAmount += 1;
        Data.SilverChestAmount += 1;
        Data.GoldChestAmount += 1;
        Data.BronzeChestTime = Mathf.RoundToInt(CONSTANTS.BRONZE_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
        Data.SilverChestTime = Mathf.RoundToInt(CONSTANTS.SILVER_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
        Data.GoldChestTime = Mathf.RoundToInt(CONSTANTS.GOLD_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
    }

    public void addStats() {
        Data.ChestReduction += 0.01f;
        Data.Brave += 1;
        Data.Awesome += 1;
        Data.Wisdom += 1;
    }

    #region Handler
    //LastPlayedDifference
    private void OnLastPlayedDifferenceChangeHandler(int lastPlayedDifference) {
        if (Data.BronzeChestAmount >= 1) {
            if (Data.BronzeChestTime > 0) {
                Data.BronzeChestTime = Math.Max(Data.BronzeChestTime - Math.Min(CONSTANTS.MAX_CHEST_SLEEP_TIME, Data.LastPlayedDifference), 0);
            }
        }
        if (Data.SilverChestAmount >= 1) {
            if (Data.SilverChestTime > 0) {
                Data.SilverChestTime = Math.Max(Data.SilverChestTime - Math.Min(CONSTANTS.MAX_CHEST_SLEEP_TIME, Data.LastPlayedDifference), 0);
            }
        }
        if (Data.GoldChestAmount >= 1) {
            if (Data.GoldChestTime > 0) {
                Data.GoldChestTime = Math.Max(Data.GoldChestTime - Math.Min(CONSTANTS.MAX_CHEST_SLEEP_TIME, Data.LastPlayedDifference), 0);
            }
        }
    }

    //Weapon&Armor&Passivemovement
    private void OnWeaponLevelChangeHandler(int weaponLevel)
    {
        Data.PointsMultiplier = CONSTANTS.POINTS_MULTIPLIER_PERCENT * weaponLevel + 1;
    }
    private void OnArmorLevelChangeHandler(int armorLevel)
    {
        Data.GemMultiplier = CONSTANTS.GEM_MULTIPLIER_PERCENT * armorLevel + 1;
    }
    private void OnPassivemovementChangeHandler(int passivemovementLevel)
    {
        Data.GemMultiplier = CONSTANTS.GEM_MULTIPLIER_PERCENT * passivemovementLevel + 1;
    }
    #endregion

    private void updateChestTime() {
        if (Data.BronzeChestAmount >= 1) {
            if (Data.BronzeChestTime > 0) {
                Data.BronzeChestTime = Math.Max(Data.BronzeChestTime - Mathf.RoundToInt(CONSTANTS.UPDATE_CHESTTIME_TIME), 0);
            }
        }
        if (Data.SilverChestAmount >= 1) {
            if (Data.SilverChestTime > 0) {
                Data.SilverChestTime = Math.Max(Data.SilverChestTime - Mathf.RoundToInt(CONSTANTS.UPDATE_CHESTTIME_TIME), 0);
            }
        }
        if (Data.GoldChestAmount >= 1) {
            if (Data.GoldChestTime > 0) {
                Data.GoldChestTime = Math.Max(Data.GoldChestTime - Mathf.RoundToInt(CONSTANTS.UPDATE_CHESTTIME_TIME), 0);
            }
        }
    }

    #region Rewards
    private int pointReward(CONSTANTS.CHEST chestMultiplier) {
        int points = CONSTANTS.CHEST_POINT_BASE * (int)chestMultiplier + UnityEngine.Random.Range(CONSTANTS.CHEST_POINT_BONUS_MIN * (int)chestMultiplier, CONSTANTS.CHEST_POINT_BONUS_MAX * (int)chestMultiplier);
        while ((CONSTANTS.CHEST_POINT_BONUS_RANDOM * (int)chestMultiplier) >= UnityEngine.Random.value) {
            Debug.Log("Point Bonus!");
            points += UnityEngine.Random.Range(CONSTANTS.CHEST_POINT_BONUS_MIN * (int)chestMultiplier, CONSTANTS.CHEST_POINT_BONUS_MAX * (int)chestMultiplier);
        }
        return Mathf.RoundToInt(points * Data.PointsMultiplier * (Mathf.Log(Data.CurrentLevel) + 1));
    }

    private int gemReward(CONSTANTS.CHEST chestMultiplier) {
        int gems = CONSTANTS.CHEST_GEM_BASE * (int)chestMultiplier + UnityEngine.Random.Range(CONSTANTS.CHEST_GEM_BONUS_MIN * (int)chestMultiplier, CONSTANTS.CHEST_GEM_BONUS_MAX * (int)chestMultiplier);
        while ((CONSTANTS.CHEST_GEM_BONUS_RANDOM * (int)chestMultiplier) >= UnityEngine.Random.value) {
            Debug.Log("Gem Bonus!");
            gems += UnityEngine.Random.Range(CONSTANTS.CHEST_GEM_BONUS_MIN * (int)chestMultiplier, CONSTANTS.CHEST_GEM_BONUS_MAX * (int)chestMultiplier);
        }
        return Mathf.RoundToInt(gems * Data.GemMultiplier);
    }

    private bool chestReductionReward() {
        if (Data.ChestReduction >= 0.5f) {
            return false;
        }
        return (CONSTANTS.CHEST_REDUCTION_BONUS_RANDOM >= UnityEngine.Random.value);
    }

    private void chestReward(CONSTANTS.CHEST chest) {
        int gems = gemReward(chest);
        int points = pointReward(chest);
        bool chestReduction = chestReductionReward();

        Data.Gems += gems;
        NotificationController.instance.addNotification(string.Format(LANGUAGE.SC_GEM[LANGUAGE.CUR_LANG] , gems));


        Data.Points += points;
        NotificationController.instance.addNotification(string.Format(LANGUAGE.SC_POINTS[LANGUAGE.CUR_LANG], points));

        if (chestReduction) {
            Data.ChestReduction += 0.01f;
            NotificationController.instance.addNotification(LANGUAGE.SC_CHESTREDUCTION[LANGUAGE.CUR_LANG]);
        }

        switch (UnityEngine.Random.Range(1, 4)) {
            case ((int)CONSTANTS.BONI.BRAVE):
                Data.Brave += 1;
                NotificationController.instance.addNotification(LANGUAGE.SC_BRAVE[LANGUAGE.CUR_LANG]);
                break;
            case ((int)CONSTANTS.BONI.AWESOME):
                Data.Awesome += 1;
                NotificationController.instance.addNotification(LANGUAGE.SC_AWESOME[LANGUAGE.CUR_LANG]);
                break;
            case ((int)CONSTANTS.BONI.WISDOM):
                Data.Wisdom += 1;
                NotificationController.instance.addNotification(LANGUAGE.SC_WISDOM[LANGUAGE.CUR_LANG]);
                break;
            default:
                break;
        }
        GooglePlayController.instance.achievements();

        if (chest == CONSTANTS.CHEST.GOLD) {
            if (CONSTANTS.CHEST_GOLD_EXTRA_BONUS >= UnityEngine.Random.value) {
                if (UnityEngine.Random.value >= 0.5f) {
                    if (Data.WeaponLevel <= CONSTANTS.MAX_WEAPON_LEVEL * CONSTANTS.UPGRADES_PER_LEVEL - 1) {
                        int index = Math.Min(Mathf.CeilToInt((float)(Data.WeaponLevel + 2) / CONSTANTS.UPGRADES_PER_LEVEL) - 1, CONSTANTS.MAX_WEAPON_LEVEL - 1);
                        Data.WeaponPrice = CONSTANTS.WEAPON_PRICE[index] + ((Data.WeaponLevel + 1) % CONSTANTS.UPGRADES_PER_LEVEL) * CONSTANTS.WEAPON_PRICE_SMALL[index];
                        Data.WeaponLevel += 1;
                        NotificationController.instance.addNotification(LANGUAGE.SC_WEAPON[LANGUAGE.CUR_LANG]);
                    }
                } else {
                    if (Data.ArmorLevel <= CONSTANTS.MAX_ARMOR_LEVEL * CONSTANTS.UPGRADES_PER_LEVEL - 1) {
                        int index = Math.Min(Mathf.CeilToInt((float)(Data.ArmorLevel + 2) / CONSTANTS.UPGRADES_PER_LEVEL) - 1, CONSTANTS.MAX_ARMOR_LEVEL - 1);
                        Data.ArmorPrice = CONSTANTS.ARMOR_PRICE[index] + ((Data.ArmorLevel + 1) % CONSTANTS.UPGRADES_PER_LEVEL) * CONSTANTS.ARMOR_PRICE_SMALL[index];
                        Data.ArmorLevel += 1;
                        NotificationController.instance.addNotification(LANGUAGE.SC_ARMOR[LANGUAGE.CUR_LANG]);
                    }
                }
            }
        }
    }
    #endregion

    #region OpenChest
    public void openBronzeChest() {
        if (Data.BronzeChestTime <= 0) {
            AnimationController.instance.ChestBronzeHide();
            Data.BronzeChestAmount--;
            if (Data.BronzeChestAmount >= 1) {
                Data.BronzeChestTime = Mathf.RoundToInt(CONSTANTS.BRONZE_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
            }

            //Reward
            chestReward(CONSTANTS.CHEST.BRONZE);
            NotificationController.instance.setAcceptDecline(false);
            NotificationController.instance.showNotification();

            GUIController.instance.OnChestTimeChangeHandler(0);
        }
    }
    public void openSilverChest() {
        if (Data.SilverChestTime <= 0) {
            AnimationController.instance.ChestSilverHide();
            Data.SilverChestAmount--;
            if (Data.SilverChestAmount >= 1) {
                Data.SilverChestTime = Mathf.RoundToInt(CONSTANTS.SILVER_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
            }

            //Reward
            chestReward(CONSTANTS.CHEST.SILVER);
            NotificationController.instance.setAcceptDecline(false);
            NotificationController.instance.showNotification();

            GUIController.instance.OnChestTimeChangeHandler(0);
        }
    }
    public void openGoldChest() {
        if (Data.GoldChestTime <= 0) {
            AnimationController.instance.ChestGoldHide();
            Data.GoldChestAmount--;
            if (Data.GoldChestAmount >= 1) {
                Data.GoldChestTime = Mathf.RoundToInt(CONSTANTS.GOLD_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
            }

            //Reward
            chestReward(CONSTANTS.CHEST.GOLD);

            NotificationController.instance.setAcceptDecline(false);
            NotificationController.instance.showNotification();

            GUIController.instance.OnChestTimeChangeHandler(0);
        }
    }
    #endregion

    #region GetChest
    public void getBronzeChest() {
        chestRand.gameObject.SetActive(false);
        if (Data.BronzeChestAmount == 0) {
            Data.BronzeChestTime = Mathf.RoundToInt(CONSTANTS.BRONZE_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
        }
        Data.BronzeChestAmount++;
        Debug.Log("BronzeChest collected!");

        NotificationController.instance.addNotification(LANGUAGE.SC_BRONZE_FOUND[LANGUAGE.CUR_LANG]);
        NotificationController.instance.setAcceptDecline(false);
        NotificationController.instance.showNotification();
    }

    public void getSilverGoldChest() {
        //Silver
        if (Data.SilverChestAmount == 0) {
            Data.SilverChestTime = Mathf.RoundToInt(CONSTANTS.SILVER_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
        }
        Data.SilverChestAmount++;
        NotificationController.instance.addNotification(LANGUAGE.SC_SILVER_FOUND[LANGUAGE.CUR_LANG]);
        if ((Data.CurrentLevel - 1) % CONSTANTS.LEVELS_PER_AGE == 0) {
            if (Data.GoldChestAmount == 0) {
                Data.GoldChestTime = Mathf.RoundToInt(CONSTANTS.GOLD_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
            }
            Data.GoldChestAmount++;
            NotificationController.instance.addNotification(LANGUAGE.SC_GOLD_FOUND[LANGUAGE.CUR_LANG]);
        }
        NotificationController.instance.setAcceptDecline(false);
        NotificationController.instance.showNotification();
    }
    #endregion

    #region BuyChest

    public void tryBuyBronzeChest() {
        if (Data.Gems >= Mathf.RoundToInt(Data.GemMultiplier * CONSTANTS.BRONZE_CHEST_PRICE)) {
            NotificationController.instance.addAction(NotificationController.Action.BronzeChest);
            NotificationController.instance.addNotification(LANGUAGE.SC_BRONZE_BUY[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        } else {
            NotificationController.instance.addAction(NotificationController.Action.NoGems);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_1[LANGUAGE.CUR_LANG]);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_2[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        }
    }

    public void buyBronzeChest() {
        Data.Gems -= Mathf.RoundToInt(Data.GemMultiplier * CONSTANTS.BRONZE_CHEST_PRICE);
        AnimationController.instance.ChestBronzeHide();
        Data.BronzeChestAmount--;
        if (Data.BronzeChestAmount >= 1) {
            Data.BronzeChestTime = Mathf.RoundToInt(CONSTANTS.BRONZE_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
        }

        chestReward(CONSTANTS.CHEST.BRONZE);

        GUIController.instance.OnChestTimeChangeHandler(0);
    }

    public void tryBuySilverChest() {
        if (Data.Gems >= Mathf.RoundToInt(Data.GemMultiplier * CONSTANTS.SILVER_CHEST_PRICE)) {
            NotificationController.instance.addAction(NotificationController.Action.SilverChest);
            NotificationController.instance.addNotification(LANGUAGE.SC_SILVER_BUY[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        } else {
            NotificationController.instance.addAction(NotificationController.Action.NoGems);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_1[LANGUAGE.CUR_LANG]);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_2[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        }
    }

    public void buySilverChest() {
        Data.Gems -= Mathf.RoundToInt(Data.GemMultiplier * CONSTANTS.SILVER_CHEST_PRICE);
        AnimationController.instance.ChestSilverHide();
        Data.SilverChestAmount--;
        if (Data.SilverChestAmount >= 1) {
            Data.SilverChestTime = Mathf.RoundToInt(CONSTANTS.SILVER_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
        }

        //Reward
        chestReward(CONSTANTS.CHEST.SILVER);

        GUIController.instance.OnChestTimeChangeHandler(0);
    }

    public void tryBuyGoldChest() {
        if (Data.Gems >= Mathf.RoundToInt(Data.GemMultiplier * CONSTANTS.GOLD_CHEST_PRICE)) {
            NotificationController.instance.addAction(NotificationController.Action.GoldChest);
            NotificationController.instance.addNotification(LANGUAGE.SC_GOLD_BUY[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        } else {
            NotificationController.instance.addAction(NotificationController.Action.NoGems);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_1[LANGUAGE.CUR_LANG]);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_2[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        }
    }

    public void buyGoldChest() {
        Data.Gems -= Mathf.RoundToInt(Data.GemMultiplier * CONSTANTS.GOLD_CHEST_PRICE);
        AnimationController.instance.ChestGoldHide();
        Data.GoldChestAmount--;
        if (Data.GoldChestAmount >= 1) {
            Data.GoldChestTime = Mathf.RoundToInt(CONSTANTS.GOLD_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
        }

        //Reward
        chestReward(CONSTANTS.CHEST.GOLD);

        GUIController.instance.OnChestTimeChangeHandler(0);
    }

    #endregion

    #region Weapons&Armor
    public void tryBuyWeapon() {
        if (Data.Gems >= Data.WeaponPrice) {
            NotificationController.instance.addAction(NotificationController.Action.Weapon);
            NotificationController.instance.addNotification(LANGUAGE.SC_WEAPON_UPGRADE[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        } else {
            NotificationController.instance.addAction(NotificationController.Action.NoGems);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_1[LANGUAGE.CUR_LANG]);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_2[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        }
    }

    public void buyWeapon() {
        Data.Gems -= Data.WeaponPrice;

        int index = Math.Min(Mathf.CeilToInt((float)(Data.WeaponLevel + 2) / CONSTANTS.UPGRADES_PER_LEVEL) - 1, CONSTANTS.MAX_WEAPON_LEVEL - 1);
        Data.WeaponPrice = CONSTANTS.WEAPON_PRICE[index] + ((Data.WeaponLevel + 1) % CONSTANTS.UPGRADES_PER_LEVEL) * CONSTANTS.WEAPON_PRICE_SMALL[index];
        Data.WeaponLevel += 1;

        AnimationController.instance.WeaponHide();
        NotificationController.instance.addNotification(string.Format(LANGUAGE.SC_WEAPON_BONUS[LANGUAGE.CUR_LANG], Mathf.RoundToInt((Data.PointsMultiplier - 1) * 100)));
    }

    public void tryBuyArmor() {
        if (Data.Gems >= Data.ArmorPrice) {
            NotificationController.instance.addAction(NotificationController.Action.Armor);
            NotificationController.instance.addNotification(LANGUAGE.SC_ARMOR_UPGRADE[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        } else {
            NotificationController.instance.addAction(NotificationController.Action.NoGems);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_1[LANGUAGE.CUR_LANG]);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_2[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        }
    }

    public void buyArmor() {
        Data.Gems -= Data.ArmorPrice;

        int index = Math.Min(Mathf.CeilToInt((float)(Data.ArmorLevel + 2) / CONSTANTS.UPGRADES_PER_LEVEL) - 1, CONSTANTS.MAX_ARMOR_LEVEL - 1);
        Data.ArmorPrice = CONSTANTS.ARMOR_PRICE[index] + ((Data.ArmorLevel + 1) % CONSTANTS.UPGRADES_PER_LEVEL) * CONSTANTS.ARMOR_PRICE_SMALL[index];
        Data.ArmorLevel += 1;

        AnimationController.instance.ArmorHide();
        NotificationController.instance.addNotification(string.Format(LANGUAGE.SC_WEAPON_BONUS[LANGUAGE.CUR_LANG], Mathf.RoundToInt((Data.GemMultiplier - 1) * 100)));
    }
    #endregion

    #region Upgrades
    public void tryBuyPassiveMovement()
    {
        if (Data.Gems >= Data.PassiveMovementPrice)
        {
            NotificationController.instance.addAction(NotificationController.Action.PassiveMovement);
            NotificationController.instance.addNotification(LANGUAGE.SC_PASSIVEMOVEMENT_UPGRADE[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        }
        else
        {
            NotificationController.instance.addAction(NotificationController.Action.NoGems);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_1[LANGUAGE.CUR_LANG]);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_2[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        }
    }

    public void buyPassiveMovement()
    {
        Data.Gems -= Data.PassiveMovementPrice;

        int index = Math.Min(Mathf.CeilToInt((float)(Data.PassiveMovementLevel + 2) / CONSTANTS.UPGRADES_PER_LEVEL) - 1, CONSTANTS.MAX_PASSIVEMOVEMENT_LEVEL - 1);
        Data.PassiveMovementPrice = CONSTANTS.PASSIVEMOVEMENT_PRICE[index] + ((Data.PassiveMovementLevel + 1) % CONSTANTS.UPGRADES_PER_LEVEL) * CONSTANTS.PASSIVEMOVEMENT_PRICE_SMALL[index];
        Data.PassiveMovementLevel += 1;

        AnimationController.instance.PassiveMovementHide();
        NotificationController.instance.addNotification(string.Format(LANGUAGE.SC_PASSIVEMOVEMENT_BONUS[LANGUAGE.CUR_LANG], Mathf.RoundToInt((Data.GemMultiplier - 1) * 100)));
    }
    #endregion 
}
