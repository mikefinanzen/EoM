using UnityEngine;
using UnityEngine.UI;
using Assets.SimpleAndroidNotifications;

//Class for Notifications
public class NotificationController : MonoBehaviour {

    public static NotificationController instance = null;

    public enum Action { NoGems, BronzeChest, SilverChest, GoldChest, DeleteGame, Weapon, Armor, PassiveMovement, Ad, Booster, BoosterNoGems };

    public Animator notificationAnimator;
    public GameObject notifications;
    public Text notificationText;
    public Button normalButton;
    public Button acceptButton;
    public Button declineButton;

    private string notification = "";
    private bool acceptDecline = false;
    private float hideTime = 0.0f;
    private float addTime = 1.25f;

    #region Start&Update
    void Awake() {
        instance = this;
    }
    #endregion

    private void softReset() {
        notification = "";
        acceptDecline = false;
        hideTime = 0.0f;
    }

    private void hardReset() {
        acceptButton.GetComponent<Button>().onClick.RemoveAllListeners();
        softReset();
    }

    private void setNotification() {
        acceptButton.gameObject.SetActive(acceptDecline);
        declineButton.gameObject.SetActive(acceptDecline);
        normalButton.gameObject.SetActive(!acceptDecline);
        notificationText.text = notification;
    }

    public void moreTime() {
        hideTime += 2 * addTime;
    }

    public void setAcceptDecline(bool acceptDecline) {
        this.acceptDecline = acceptDecline;
    }

    public void addAction(Action action) {
        acceptButton.GetComponent<Button>().onClick.RemoveAllListeners();
        switch (action) {
            case Action.NoGems:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    AnimationController.instance.hideAll();
                    AnimationController.instance.shopShow();
                    hideNotification();
                });
                break;
            case Action.BronzeChest:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    StorageController.instance.buyBronzeChest();
                    setAcceptDecline(false);
                    moreTime();
                    switchNotification();
                });
                break;
            case Action.SilverChest:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    StorageController.instance.buySilverChest();
                    setAcceptDecline(false);
                    moreTime();
                    switchNotification();
                });
                break;
            case Action.GoldChest:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    StorageController.instance.buyGoldChest();
                    setAcceptDecline(false);
                    moreTime();
                    switchNotification();
                });
                break;
            case Action.DeleteGame:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    SaveGameController.instance.delete();
                });
                break;
            case Action.Weapon:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    StorageController.instance.buyWeapon();
                    setAcceptDecline(false);
                    moreTime();
                    switchNotification();
                });
                break;
            case Action.Armor:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    StorageController.instance.buyArmor();
                    setAcceptDecline(false);
                    moreTime();
                    switchNotification();
                });
                break;
            case Action.PassiveMovement:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    StorageController.instance.buyPassiveMovement();
                    setAcceptDecline(false);
                    moreTime();
                    switchNotification();
                });
                break;
            case Action.Ad:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    Ads.instance.ShowRewardedAd();
                });
                break;
            case Action.Booster:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    StoreController.instance.buyBooster();
                    setAcceptDecline(false);
                    moreTime();
                    switchNotification();
                });
                break;
            case Action.BoosterNoGems:
                acceptButton.GetComponent<Button>().onClick.AddListener(() => {
                    StoreController.instance.switchToNormal();
                    hideNotification();
                });
                break;
            default:
                Debug.Log("Undefined Action!");
                break;
        }
    }

    public void addNotification(string notification) {
        if (this.notification != "") {
            this.notification += "\n" + notification;
        } else {
            this.notification += notification;
        }
        hideTime += addTime;
    }

    public void showNotification() {
        notifications.SetActive(true);
        setNotification();
        notificationAnimator.SetBool("Notification", true);
        if (!acceptDecline) {
            Invoke("hideNotification", hideTime);
        }
        softReset();
    }

    public void hideNotification() {
        CancelInvoke("hideNotification");
        notificationAnimator.SetBool("Notification", false);
        hardReset();
    }

    public void hideNotificationComplete() {
        notifications.SetActive(false);
    }

    public void switchNotification() {
        setNotification();
        if (!acceptDecline) {
            Invoke("hideNotification", hideTime);
        }
        softReset();
    }

    public void toogleNotifications() {
        Data.Notification = !Data.Notification;
        if (!Data.Notification) {
            NotificationManager.CancelAll();
        }
    }

}
