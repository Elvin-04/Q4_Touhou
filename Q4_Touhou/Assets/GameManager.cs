using System.Security.Principal;
using TMPro;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxFramerate = 120;

    [Header("Game")]
    public int timeToWin = 10;

    [Header("References")]
    public TextMeshProUGUI timer;
    public GameObject winText;

    private float currentTimer = 0.0f;

    void Start()
    {
        Application.targetFrameRate = maxFramerate;
    }

    private void FixedUpdate()
    {
        currentTimer += Time.deltaTime;
        SetTimerText();

        if(currentTimer >= timeToWin)
        {
            winText.SetActive(true);
        }
    }

    private void SetTimerText()
    {
        if ((int)currentTimer % 60 < 10)
            timer.text = (int)currentTimer / 60 + ":0" + (int)currentTimer % 60;
        else
            timer.text = (int)currentTimer / 60 + ":" + (int)currentTimer % 60;
    }

}
