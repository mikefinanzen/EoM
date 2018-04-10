using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : GameController
{

    public static Ads instance = null;

    public UnityEngine.UI.Button ad;

    private bool isShowing = false;

    #region Start&Update
    void Awake() {
        instance = this;
    }
    #endregion

    public void triggerAd() {
        NotificationController.instance.addAction(NotificationController.Action.Ad);
        NotificationController.instance.addNotification(LANGUAGE.AD_TRIGGER[LANGUAGE.CUR_LANG]);
        NotificationController.instance.setAcceptDecline(true);
        NotificationController.instance.showNotification();
    }

    public bool isRewardedAdReady() {
        return Advertisement.IsReady("rewardedVideo");
    }

    public void ShowRewardedAd() {
        ad.gameObject.SetActive(false);
        if (Advertisement.IsReady("rewardedVideo")) {
            if (!isShowing) {
                isShowing = true;
                var options = new ShowOptions { resultCallback = HandleShowResult };
                Advertisement.Show("rewardedVideo", options);
            }
        } else {
            NotificationController.instance.setAcceptDecline(false);
            NotificationController.instance.hideNotification();
            isShowing = false;
        }
    }

    public void giveChest() {
        switch (Random.Range(1, 11)) {
            case 1:
                if (Data.GoldChestAmount == 0) {
                    Data.GoldChestTime = Mathf.RoundToInt(CONSTANTS.GOLD_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
                }
                Data.GoldChestAmount++;
                NotificationController.instance.addNotification(LANGUAGE.AD_GOLDCHEST[LANGUAGE.CUR_LANG]);
                break;
            case 2:
            case 3:
            case 4:
                if (Data.SilverChestAmount == 0) {
                    Data.SilverChestTime = Mathf.RoundToInt(CONSTANTS.SILVER_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
                }
                Data.SilverChestAmount++;
                NotificationController.instance.addNotification(LANGUAGE.AD_SILVERCHEST[LANGUAGE.CUR_LANG]);
                break;
            default:
                if (Data.BronzeChestAmount == 0) {
                    Data.BronzeChestTime = Mathf.RoundToInt(CONSTANTS.BRONZE_CHEST_NEEDED_TIME * (1.0f - Data.ChestReduction));
                }
                Data.BronzeChestAmount++;
                NotificationController.instance.addNotification(LANGUAGE.AD_BRONZECHEST[LANGUAGE.CUR_LANG]);
                break;
        }
    }

    private void HandleShowResult(ShowResult result) {
        switch (result) {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                NotificationController.instance.addNotification(LANGUAGE.AD_BONUS[LANGUAGE.CUR_LANG]);
                switch (Random.Range(1, 11)) {
                    case 1:
                    case 2:
                        giveChest();
                        break;
                    case 3:
                    case 4:
                    case 5:
                        int gems = Mathf.RoundToInt(Random.Range(CONSTANTS.AD_GEM_MIN, CONSTANTS.AD_GEM_MAX) * Data.GemMultiplier);
                        Data.Gems += gems;
                        NotificationController.instance.addNotification(string.Format(LANGUAGE.MISC_GEM[LANGUAGE.CUR_LANG], gems));
                        break;
                    default:
                        bool reductionDone = false;
                        if (Data.BronzeChestAmount >= 1) {
                            if (Data.BronzeChestTime > 0) {
                                Data.BronzeChestTime = System.Math.Max(Data.BronzeChestTime - CONSTANTS.AD_CHEST_REDUCTION, 0);
                                reductionDone = true;
                            }
                        }
                        if (Data.SilverChestAmount >= 1) {
                            if (Data.SilverChestTime > 0) {
                                Data.SilverChestTime = System.Math.Max(Data.SilverChestTime - CONSTANTS.AD_CHEST_REDUCTION, 0);
                                reductionDone = true;
                            }
                        }
                        if (Data.GoldChestAmount >= 1) {
                            if (Data.GoldChestTime > 0) {
                                Data.GoldChestTime = System.Math.Max(Data.GoldChestTime - CONSTANTS.AD_CHEST_REDUCTION, 0);
                                reductionDone = true;
                            }
                        }
                        if (!reductionDone) {
                            giveChest();
                        } else {
                            NotificationController.instance.addNotification(LANGUAGE.AD_CHESTTIME[LANGUAGE.CUR_LANG]);
                        }
                        break;
                }

                NotificationController.instance.setAcceptDecline(false);
                NotificationController.instance.moreTime();
                NotificationController.instance.switchNotification();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                NotificationController.instance.setAcceptDecline(false);
                NotificationController.instance.hideNotification();
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                NotificationController.instance.setAcceptDecline(false);
                NotificationController.instance.hideNotification();
                break;
        }
        isShowing = false;
    }
}
