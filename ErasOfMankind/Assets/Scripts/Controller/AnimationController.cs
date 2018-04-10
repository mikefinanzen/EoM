using UnityEngine;

//Class for handling Animations
public class AnimationController : MonoBehaviour {

    public static AnimationController instance = null;

    public Animator menuAnimator;
    public Animator storageAnimator;
    public Animator playerAnimator;
    public Animator nextLevelAnimator;
    public Animator apertureAnimator;

    public GameObject Player;

    private string[] menuTriggers = { "SettingsIn", "SettingsOut", "StorageIn", "StorageOut", "ShopIn", "ShopOut" };
    private string[] storageTriggers = { "ChestBronzeIn", "ChestBronzeOut", "ChestSilverIn", "ChestSilverOut", "ChestGoldIn", "ChestGoldOut",
        "WeaponIn", "WeaponOut", "ArmorIn", "ArmorOut","PassiveMovementIn", "PassiveMovementOut", "StatsIn", "StatsOut" };

    #region Start&Update
    void Awake()
    {
        instance = this;
    }
    #endregion

    #region Menu&Storage(Show&Hide)
    #region Menu
    private void menuReset() {
        foreach (string trigger in menuTriggers) {
            menuAnimator.ResetTrigger(trigger);
        }
    }

    public void hideAll() {
        menuReset();
        menuAnimator.SetTrigger("SettingsOut");
        menuAnimator.SetTrigger("StorageOut");
        menuAnimator.SetTrigger("ShopOut");
    }

    public void settingsShow()
    {
        menuReset();
        menuAnimator.SetTrigger("SettingsIn");

        Debug.Log("Heia");

        Player.SetActive(false);
    }
    public void settingsHide() {
        menuReset();
        menuAnimator.SetTrigger("SettingsOut");

        Player.SetActive(true);
    }

    public void storageShow()
    {
        menuReset();
        menuAnimator.SetTrigger("StorageIn");

        Player.SetActive(false);
    }
    public void storageHide()
    {
        Player.SetActive(true);
        menuReset();
        menuAnimator.SetTrigger("StorageOut");
    }

    public void shopShow() {
        menuReset();
        menuAnimator.SetTrigger("ShopIn");

        Player.SetActive(false);
    }
    public void shopHide() {
        menuReset();
        menuAnimator.SetTrigger("ShopOut");

        Player.SetActive(true);
    }
    #endregion

    #region Storage
    private void storageReset() {
        foreach (string trigger in storageTriggers) {
            storageAnimator.ResetTrigger(trigger);
        }
    }

    public void ChestBronzeShow() {
        storageReset();
        storageAnimator.SetTrigger("ChestBronzeIn");
    }
    public void ChestBronzeHide() {
        storageReset();
        storageAnimator.SetTrigger("ChestBronzeOut");
    }

    public void ChestSilverShow() {
        storageReset();
        storageAnimator.SetTrigger("ChestSilverIn");
    }
    public void ChestSilverHide() {
        storageReset();
        storageAnimator.SetTrigger("ChestSilverOut");
    }

    public void ChestGoldShow() {
        storageReset();
        storageAnimator.SetTrigger("ChestGoldIn");
    }
    public void ChestGoldHide() {
        storageReset();
        storageAnimator.SetTrigger("ChestGoldOut");
    }

    public void ArmorShow() {
        storageReset();
        storageAnimator.SetTrigger("ArmorIn");
    }
    public void ArmorHide() {
        storageReset();
        storageAnimator.SetTrigger("ArmorOut");
    }

    public void WeaponShow() {
        storageReset();
        storageAnimator.SetTrigger("WeaponIn");
    }
    public void WeaponHide() {
        storageReset();
        storageAnimator.SetTrigger("WeaponOut");
    }
    public void PassiveMovementShow()
    {
        storageReset();
        storageAnimator.SetTrigger("PassiveMovementIn");
    }
    public void PassiveMovementHide()
    {
        storageReset();
        storageAnimator.SetTrigger("PassiveMovementOut");
    }

    public void StatsShow() {
        storageReset();
        storageAnimator.SetTrigger("StatsIn");

        Player.SetActive(false);
    }
    public void StatsHide() {
        storageReset();
        storageAnimator.SetTrigger("StatsOut");

        Player.SetActive(true);
    }
    #endregion
    #endregion

    #region Player
    public void setWalking(bool walking) {
        playerAnimator.SetBool("Walking", walking);
    }
    public void setRunning(bool running) {
        playerAnimator.SetBool("Running", running);
    }

    public void setSpeed(float speed) {
        playerAnimator.speed = speed;
    }
    #endregion

    #region Level
    public void setNextLevel(bool nextLevel) {
        nextLevelAnimator.SetBool("nextLevel", nextLevel);
    }
    public void aperture() {
        apertureAnimator.SetTrigger("Aperture");
    }
    #endregion
}
