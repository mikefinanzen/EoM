using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class backgroundArray {
    [Range(1, 1000)]
    public int[] speed;
    public int[] spritesPerLayer;
    public bool[] withOffset;
}

public class BackgroundController : MonoBehaviour {

    public static BackgroundController instance = null;

    public GameObject backgroundPrefab;
    public GameObject backgroundParent;
    public Image ageImage;
    public backgroundArray[] backgrounds;

    private List<GameObject> currentBackgrounds = new List<GameObject>();

    #region Start&Update
    void Awake() {
        instance = this;

        Data.OnCurrentLevelChange += OnCurrentLevelChangeHandler;
        Data.OnTapsPerSecRatioChange += OnTapsPerSecRatioChangeHandler;
    }
    #endregion

    #region Handler
    private void OnCurrentLevelChangeHandler(int currentLevel) {
        foreach (GameObject background in currentBackgrounds) {
            Destroy(background);
        }
        currentBackgrounds.Clear();

        Texture2D texture;
        Rect rec;
        Sprite sprite;

        
        for (int layer = 0; layer < backgrounds[currentLevel - 1].speed.Length; layer++) {
            for (int spriteInLayer = 0; spriteInLayer < backgrounds[currentLevel - 1].spritesPerLayer[layer]; spriteInLayer++) {
                texture = Resources.Load("levels/" + (currentLevel - 1) + "/" + layer + "/" + spriteInLayer) as Texture2D;
                rec = new Rect(0, 0, texture.width, texture.height);
                sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);

                GameObject newSprite = Instantiate(backgroundPrefab) as GameObject;
                newSprite.transform.SetParent(backgroundParent.transform);
                newSprite.GetComponent<ImageController>().init(sprite, backgrounds[currentLevel - 1].speed[layer],
                    backgrounds[currentLevel - 1].spritesPerLayer[layer], spriteInLayer, backgrounds[currentLevel - 1].withOffset[layer]);
                currentBackgrounds.Add(newSprite);
            }
        }
        #region old
        /*
        //for every sprite in level instantiate first and second image
        for (int layer = 0; layer < backgrounds[currentLevel - 1].speed.Length; layer++) {
            texture = Resources.Load("levels/" + currentLevel + "/" + layer) as Texture2D;
            rec = new Rect(0, 0, texture.width, texture.height);
            sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);

            GameObject newLayerFirst = Instantiate(backgroundPrefab) as GameObject;
            newLayerFirst.transform.SetParent(backgroundParent.transform);
            newLayerFirst.GetComponent<ImageController>().image = sprite;
            newLayerFirst.GetComponent<ImageController>().speed = backgrounds[currentLevel - 1].speed[layer];
            newLayerFirst.GetComponent<ImageController>().spritesPerLayer = 2;
            newLayerFirst.GetComponent<ImageController>().init(0);
            currentBackgrounds.Add(newLayerFirst);

            GameObject newLayerSecond = Instantiate(backgroundPrefab) as GameObject;
            newLayerSecond.transform.SetParent(backgroundParent.transform);
            newLayerSecond.GetComponent<ImageController>().image = sprite;
            newLayerSecond.GetComponent<ImageController>().speed = backgrounds[currentLevel - 1].speed[layer];
            newLayerSecond.GetComponent<ImageController>().spritesPerLayer = 2;
            newLayerSecond.GetComponent<ImageController>().init(1);
            currentBackgrounds.Add(newLayerSecond);
        }
        */
        #endregion
        texture = Resources.Load("levels/" + (currentLevel - 1) + "/Age") as Texture2D;
        rec = new Rect(0, 0, texture.width, texture.height);
        sprite = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);
        ageImage.GetComponent<Image>().overrideSprite = sprite;
    }

    private void OnTapsPerSecRatioChangeHandler(float tapsPerSecRatio) {
        foreach (GameObject background in currentBackgrounds) {
            background.GetComponent<ImageController>().setMovingSpeed(tapsPerSecRatio * 2);
        }
    }
    #endregion

    public void setMovingEnabled(bool movingEnabled) {
        foreach (GameObject background in currentBackgrounds) {
            background.GetComponent<ImageController>().setMovingEnabled(movingEnabled);
        }
    }

}