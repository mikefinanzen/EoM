using UnityEngine;
using UnityEngine.UI;

public class OpeningController : MonoBehaviour {

    public Text openingText;
    public Text openingButtonText1;
    public Text openingButtonText2;
    public Button openingButton1;
    public Button openingButton2;
    public GameObject charles;
    public GameObject container;


    private const int steps = 13;
    private int cur_step = 0;

    void Awake() {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 30;

        Debug.Log(Application.version);
        if (EncryptedPlayerPrefs.GetInt(Application.version.ToString(), 0) == 1) {
            openingText.text = LANGUAGE.OPENING_WELCOME_BACK[LANGUAGE.CUR_LANG];
            openingButton1.gameObject.SetActive(false);
            openingButton2.gameObject.SetActive(false);
            container.SetActive(false);
            charles.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 0.0f);
            Invoke("loadGame", 2.0f);
        }
    }

    void Start() {
        if (EncryptedPlayerPrefs.GetInt(Application.version.ToString(), 0) == 0) {
            openingText.text = LANGUAGE.OPENING[LANGUAGE.CUR_LANG][cur_step];
            openingButtonText1.text = LANGUAGE.OPENING_CONTINUE_1[LANGUAGE.CUR_LANG][cur_step];
            openingButtonText2.text = LANGUAGE.OPENING_CONTINUE_2[LANGUAGE.CUR_LANG][cur_step];
        }
    }

    public void next() {
        cur_step++;

        switch (cur_step) {
            case steps:
                loadGame();
                break;
            default:
                openingText.text = LANGUAGE.OPENING[LANGUAGE.CUR_LANG][cur_step];
                openingButtonText1.text = LANGUAGE.OPENING_CONTINUE_1[LANGUAGE.CUR_LANG][cur_step];
                openingButtonText2.text = LANGUAGE.OPENING_CONTINUE_2[LANGUAGE.CUR_LANG][cur_step];
                break;
        }
    }

    public void loadGame() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1, UnityEngine.SceneManagement.LoadSceneMode.Single);
    }

    public void toEnglish() {
        LANGUAGE.SET_LANGUAGE_OPENING(0);
        if (EncryptedPlayerPrefs.GetInt(Application.version.ToString(), 0) == 0) {
            openingText.text = LANGUAGE.OPENING[LANGUAGE.CUR_LANG][cur_step];
            openingButtonText1.text = LANGUAGE.OPENING_CONTINUE_1[LANGUAGE.CUR_LANG][cur_step];
            openingButtonText2.text = LANGUAGE.OPENING_CONTINUE_2[LANGUAGE.CUR_LANG][cur_step];
        } else {
            openingText.text = LANGUAGE.OPENING_WELCOME_BACK[LANGUAGE.CUR_LANG];
        }
    }

    public void toGerman() {
        LANGUAGE.SET_LANGUAGE_OPENING(1);
        if (EncryptedPlayerPrefs.GetInt(Application.version.ToString(), 0) == 0) {
            openingText.text = LANGUAGE.OPENING[LANGUAGE.CUR_LANG][cur_step];
            openingButtonText1.text = LANGUAGE.OPENING_CONTINUE_1[LANGUAGE.CUR_LANG][cur_step];
            openingButtonText2.text = LANGUAGE.OPENING_CONTINUE_2[LANGUAGE.CUR_LANG][cur_step];
        } else {
            openingText.text = LANGUAGE.OPENING_WELCOME_BACK[LANGUAGE.CUR_LANG];
        }
    }
}
