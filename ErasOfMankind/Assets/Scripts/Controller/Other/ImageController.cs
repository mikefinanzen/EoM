using UnityEngine.UI;
using UnityEngine;

public class ImageController : MonoBehaviour {

    private int speed = 10;
    private int spritesPerLayer = 0;
    private float height = 1420.0f;
    private float width = 2048.0f;
    private float scale = 1.0f;
    private bool withOffset = false;
    private int offset = 0;
    private bool movingEnabled = false;
    private Vector2 move = new Vector2(0, 0);

    public void init(Sprite image, int speed, int spritesPerLayer, int spriteInLayer, bool withOffset) {
        this.speed = speed;
        this.spritesPerLayer = spritesPerLayer;
        this.withOffset = withOffset;

        width = image.rect.width;
        height = image.rect.height;
        scale = gameObject.transform.parent.GetComponent<RectTransform>().rect.height / height * 1.005f;
        if (withOffset) {
            offset = spriteInLayer;
        }

        gameObject.GetComponent<Image>().sprite = image;
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(scale * width * spriteInLayer - offset, 0);
        //need to scalescale * width * spriteInLayer
        gameObject.GetComponent<RectTransform>().localScale = new Vector3(scale, scale, scale);
        gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(width, height);
    }

    void Update() {
        if (movingEnabled) {
            gameObject.GetComponent<RectTransform>().anchoredPosition += move * Time.deltaTime;
            if (gameObject.GetComponent<RectTransform>().anchoredPosition.x <= -scale * width) {
                if (withOffset) {
                    offset += spritesPerLayer;
                }
                gameObject.GetComponent<RectTransform>().anchoredPosition += new Vector2(spritesPerLayer * scale * width - offset, 0);
            }
        }
    }

    public void setMovingEnabled(bool movingEnabled) {
        this.movingEnabled = movingEnabled;
    }

    public void setMovingSpeed(float movingSpeed) {
        move = new Vector2(-speed * movingSpeed * scale, 0);
    }
}
