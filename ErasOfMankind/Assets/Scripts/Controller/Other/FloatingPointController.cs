using UnityEngine;

public class FloatingPointController : MonoBehaviour
{

    public UnityEngine.UI.Text floatingPointText;

    public void setText(float text)
    {
        floatingPointText.text = text.ToString("F2");
    }
}
