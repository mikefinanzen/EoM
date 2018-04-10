//Constants
public static class CONSTANTS {

    #region Screen
    public static int SCREEN_HEIGHT = 1200;
    public static int SCREEN_WIDTH = 800;
    #endregion

    #region Game
    //Constants
    public static int MAX_LEVEL = 9;
    public static int LEVELS_PER_AGE = 3;
    public static readonly int[] NEEDED_POINTS = { 2400, 4800, 7200, 9600, 12000, 14400, 16800, 19200 }; //Always MAX_LEVEL - 1
    public static string[] AGE_NAMES = LANGUAGE.AGE_NAMES[LANGUAGE.CUR_LANG];

    public static void SET_AGE_NAMES(int LANG) {
      AGE_NAMES = LANGUAGE.AGE_NAMES[LANG];
    }

    public static int MAX_WEAPON_LEVEL = 5;
    public static int MAX_ARMOR_LEVEL = 5;
    public static int MAX_PASSIVEMOVEMENT_LEVEL = 3;
    public static int UPGRADES_PER_LEVEL = 3;

    public static readonly int[] WEAPON_PRICE = { 25, 50, 100, 150, 200}; //gems
    public static readonly int[] ARMOR_PRICE = { 25, 50, 100, 150, 200 }; //gems
    public static readonly int[] WEAPON_PRICE_SMALL = { 5, 10, 10, 10, 20 }; //gems
    public static readonly int[] ARMOR_PRICE_SMALL = { 5, 10, 10, 10, 20 }; //gems
    public static readonly int[] PASSIVEMOVEMENT_PRICE = { 25, 50, 100, 150, 200 }; //gems
    public static readonly int[] PASSIVEMOVEMENT_PRICE_SMALL = { 5, 10, 10, 10, 20 }; //gems

    public static float POINTS_MULTIPLIER_PERCENT = 0.1f; //percent
    public static float GEM_MULTIPLIER_PERCENT = 0.05f; //percent

    public static int BRONZE_CHEST_NEEDED_TIME = 10800; //3 hours
    public static int SILVER_CHEST_NEEDED_TIME = 43200; //12 hours
    public static int GOLD_CHEST_NEEDED_TIME = 259200; //3 days
    public static int MAX_CHEST_SLEEP_TIME = 43200; //12 hours

    public static int BRONZE_CHEST_PRICE = 10; //gems
    public static int SILVER_CHEST_PRICE = 20; //gems
    public static int GOLD_CHEST_PRICE = 50; //gems

    public enum CHEST : int { BRONZE = 1, SILVER = 2, GOLD = 5 }; //Multiplier
    public static int CHEST_POINT_BASE = 50; //points
    public static int CHEST_POINT_BONUS_MIN = 5; //points
    public static int CHEST_POINT_BONUS_MAX = 15; //points
    public static float CHEST_POINT_BONUS_RANDOM = 0.1f; //percent
    public static int CHEST_GEM_BASE = 2; //gems
    public static int CHEST_GEM_BONUS_MIN = 0; //gems
    public static int CHEST_GEM_BONUS_MAX = 2; //gems
    public static float CHEST_GEM_BONUS_RANDOM = 0.02f; //percent
    public static float CHEST_REDUCTION_MAX = 0.75f; //percent
    public static float CHEST_REDUCTION_BONUS_RANDOM = 0.01f; //percent
    public enum BONI : int { BRAVE = 1, AWESOME = 2, WISDOM = 3 };
    public static float CHEST_GOLD_EXTRA_BONUS = 0.01f; //percent

    public static float RANDOM_TIME = 10.0f; //seconds
    public static float CHEST_RANDOM = 30.0f; //seconds
    public static float GEM_RANDOM = 120.0f; //seconds

    public static float AUTOSAVE_TIME = 30.0f; //seconds
    public static float UPDATE_LEADERBOARD_TIME = 30.0f; //seconds
    public static float UPDATE_LASTPLAYED_TIME = 30.0f; //seconds
    public static float UPDATE_CHESTTIME_TIME = 1.0f; //seconds
    public static float UPDATE_AD_TIME = 20.0f; //seconds

    public static int AD_GEM_MIN = 5; //gems
    public static int AD_GEM_MAX = 15; //gems
    public static int AD_CHEST_REDUCTION = 10800; //3 hours

    public static readonly int[] BOOSTER_PRICE = { 15, 30, 75, 150 };
    #endregion

    #region Google
    public static readonly string[] LEVEL_ACHIEVEMENTS = { GPGSIds.achievement_stone_age, GPGSIds.achievement_copper_age };
    #endregion

    #region Functions
    public static string SECONDS_TO_STRING(int seconds) {
        System.TimeSpan time = System.TimeSpan.FromSeconds(seconds);
        string timeText = "";

        timeText = string.Format("{0:D2}h {1:D2}m {2:D2}s", time.Hours + time.Days * 24, time.Minutes, time.Seconds);
        if (time.Hours > 1) {
            return timeText;
        }
        if (time.Hours == 1) {
            return timeText;
        }

        timeText = string.Format("{0:D2}m {1:D2}s", time.Minutes, time.Seconds);
        if (time.Minutes > 1) {
            return timeText;
        }
        if (time.Minutes == 1) {
            return timeText;
        }

        timeText = string.Format("{0:D2}s", time.Seconds);
        if (time.Seconds > 1) {
            return timeText;
        }
        return timeText;
    }
    #endregion
}
