using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunController : MonoBehaviour
{

    public static RunController instance = null;

    [Range(5, 25)]
    public int maxTapsPerSec = 8;
    public int pressedTaps = 0;
    public float pressedTimer = 0;
    public float comboPointsMultiplier = Data.PointsMultiplier;
    public bool comboActive = false;
    public bool firstStart = false;

    public GameObject floatingPoints;
    public GameObject floatingPointPrefab;
    public Text ComboText;

    private bool tappingEnabled = false;
    private int tapsPerSecond;
    private List<float> taps = new List<float>();

    #region Start&Update
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        firstStart = true;
    }

    void Update()
    {
        for (int i = 0; i < taps.Count; i++)
        {
            if (taps[i] <= Time.timeSinceLevelLoad - 1)
            {
                taps.RemoveAt(i);
            }
        }
        tapsPerSecond = taps.Count;
        Data.TapsPerSec = tapsPerSecond;
        Data.TapsPerSecRatio = (float)tapsPerSecond / maxTapsPerSec;

        pressedTimer += Time.deltaTime;

        if (pressedTimer > 0.5)
        {
            pressedTaps = 0;
            ComboText.text = "";
            comboActive = false;
            comboPointsMultiplier = Data.PointsMultiplier;
            firstStart = false;
        }
    }
    #endregion

    public void tap()
    {
        if ((tappingEnabled) && (tapsPerSecond < maxTapsPerSec))
        {
            pressedTimer = 0;
            taps.Add(Time.timeSinceLevelLoad);
            showPoint();
            pressedTaps++;

            //Combo
            if(pressedTaps >= 10)
            {
               comboActive = true;
               comboPointsMultiplier += Data.PointsMultiplier / 70;
               ComboText.text = "Combo: " + pressedTaps + "x";
            }
        }
    }

    public void setTappingEnabled(bool tappingEnabled)
    {
        this.tappingEnabled = tappingEnabled;
    }

    private void showPoint()
    {
        GameObject floatingPoint = Instantiate(floatingPointPrefab) as GameObject;
        floatingPoint.transform.SetParent(floatingPoints.transform);
        int xPos = Random.Range(0, 151) - 75;
        int yPos = Random.Range(0, 101) - 25;
        floatingPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos, yPos);
        floatingPoint.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        if (comboActive == false)
        {
            floatingPoint.GetComponent<FloatingPointController>().setText(Data.PointsMultiplier);
        }

        else if(comboActive == true && firstStart == true)
        {
            floatingPoint.GetComponent<FloatingPointController>().setText(comboPointsMultiplier + Data.PointsMultiplier);
        }

        else if (comboActive == true && firstStart == false)
        {
            floatingPoint.GetComponent<FloatingPointController>().setText(comboPointsMultiplier);
        }
    }
}
