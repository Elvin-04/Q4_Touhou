using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance {  get; private set; }

    public TextMeshProUGUI fpsText;
    public TextMeshProUGUI canShootText;
    private float fps;

    public Color canShootColor;
    public Color cantShootColor;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        InvokeRepeating("GetFps", 0, 0.8f);
    }

    private void GetFps()
    {
        fps = (int)(1f / Time.unscaledDeltaTime);
        fpsText.text = "FPS : " + fps;
    }

    public void SetCanShootText(bool canShoot)
    {
        if(canShoot)
        {
            canShootText.text = "Can shoot";
            canShootText.color = canShootColor;
        }
        else
        {
            canShootText.text = "Can't shoot";
            canShootText.color = cantShootColor;
        }
    }
}
