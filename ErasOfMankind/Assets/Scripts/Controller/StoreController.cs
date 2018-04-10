using UnityEngine;

public class StoreController : MonoBehaviour {

    public static StoreController instance = null;

    public UnityEngine.UI.Button gemRand;
    public UnityEngine.UI.Button normalShopButton;
    public UnityEngine.UI.Button boosterShopButton;
    public GameObject normalButtons;
    public GameObject boosterButtons;

    private int currentBoosterId = -1;

    #region Start&Update
    void Awake() {
        instance = this;
    }
    #endregion

    public void giveGems() {
        Data.Gems += 100;
    }

    public void buyGems(string id) {
        Purchaser.instance.BuyProductID(id);
    }

    public void getGem() {
        gemRand.gameObject.SetActive(false);
        int gems = Mathf.RoundToInt(Random.Range(1, 4) * Data.GemMultiplier);
        Data.Gems += gems;
        Debug.Log("Gem collected!");

        NotificationController.instance.addNotification(string.Format(LANGUAGE.MISC_GEM[LANGUAGE.CUR_LANG], gems));
        NotificationController.instance.setAcceptDecline(false);
        NotificationController.instance.showNotification();
    }

    public void switchToNormal() {
        normalShopButton.image.color = new Color32(0x28, 0xC4, 0x20, 0xFF);
        boosterShopButton.image.color = new Color32(0xC6, 0x1E, 0x1E, 0xFF);
        boosterButtons.SetActive(false);
        normalButtons.SetActive(true);
    }

    public void switchToBooster() {
        boosterShopButton.image.color = new Color32(0x28, 0xC4, 0x20, 0xFF);
        normalShopButton.image.color = new Color32(0xC6, 0x1E, 0x1E, 0xFF);
        normalButtons.SetActive(false);
        boosterButtons.SetActive(true);
    }

    public void tryBuyBooster(int id) {
        if (Data.Gems >= CONSTANTS.BOOSTER_PRICE[id]) {
            currentBoosterId = id;
            NotificationController.instance.addAction(NotificationController.Action.Booster);
            NotificationController.instance.addNotification(LANGUAGE.S_BOOSTER_BUY[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        } else {
            NotificationController.instance.addAction(NotificationController.Action.BoosterNoGems);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_1[LANGUAGE.CUR_LANG]);
            NotificationController.instance.addNotification(LANGUAGE.MISC_NO_GEM_2[LANGUAGE.CUR_LANG]);
            NotificationController.instance.setAcceptDecline(true);
            NotificationController.instance.showNotification();
        }
    }

    public void buyBooster() {
        switch (currentBoosterId) {
            case 0: //5%
                if (Data.NeededPoints != Mathf.Infinity) {
                    Data.Gems -= CONSTANTS.BOOSTER_PRICE[0];
                    Data.Points += Data.NeededPoints * 0.05f;
                    NotificationController.instance.addNotification(LANGUAGE.S_BOOSTER_0_YES[LANGUAGE.CUR_LANG]);
                } else {
                    NotificationController.instance.addNotification(LANGUAGE.S_BOOSTER_0_NO[LANGUAGE.CUR_LANG]);
                }
                break;
            case 1: //10%
                if (Data.NeededPoints != Mathf.Infinity) {
                    Data.Gems -= CONSTANTS.BOOSTER_PRICE[1];
                    Data.Points += Data.NeededPoints * 0.1f;
                    NotificationController.instance.addNotification(LANGUAGE.S_BOOSTER_1_YES[LANGUAGE.CUR_LANG]);
                } else {
                    NotificationController.instance.addNotification(LANGUAGE.S_BOOSTER_1_NO[LANGUAGE.CUR_LANG]);
                }
                break;
            case 2: //25%
                if (Data.NeededPoints != Mathf.Infinity) {
                    Data.Gems -= CONSTANTS.BOOSTER_PRICE[2];
                    Data.Points += Data.NeededPoints * 0.25f;
                    NotificationController.instance.addNotification(LANGUAGE.S_BOOSTER_2_YES[LANGUAGE.CUR_LANG]);
                } else {
                    NotificationController.instance.addNotification(LANGUAGE.S_BOOSTER_2_NO[LANGUAGE.CUR_LANG]);
                }
                break;
            case 3: //50%
                if (Data.NeededPoints != Mathf.Infinity) {
                    Data.Gems -= CONSTANTS.BOOSTER_PRICE[3];
                    Data.Points += Data.NeededPoints * 0.5f;
                    NotificationController.instance.addNotification(LANGUAGE.S_BOOSTER_3_YES[LANGUAGE.CUR_LANG]);
                } else {
                    NotificationController.instance.addNotification(LANGUAGE.S_BOOSTER_3_NO[LANGUAGE.CUR_LANG]);
                }
                break;
            default:
                Debug.Log("Booster not recognized!");
                break;
        }
    }
}
