using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI fpsText;
    private float fps;

    private void Start()
    {
        InvokeRepeating("GetFps", 0, 0.8f);
    }

    private void GetFps()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = "FPS : " + fps;
    }
}
