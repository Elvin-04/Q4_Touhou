using System.Security.Principal;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int maxFramerate = 120;
    public bool levelWin = false;
    public static GameManager instance {  get; private set; } 

    [Header("Level")]
    public Level level;

    [Header("Game")]
    public int timeToWin = 10;

    [Header("References")]
    public TextMeshProUGUI timer;
    public GameObject winText;
    public Image timerImage;
    public GameObject player;

    [Header("End Level")]
    public GameObject endLevelCanva;
    public GameObject uiCanva;
    public GameObject win;
    public GameObject loose;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI score;
    public TextMeshProUGUI bestTime;
    public TextMeshProUGUI time;

    private float currentTimer = 0.0f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Application.targetFrameRate = maxFramerate;
        timerImage.fillAmount = 0;
    }

    private void FixedUpdate()
    {
        currentTimer += Time.deltaTime;
        
        SetTimerText();

        if(currentTimer >= timeToWin)
        {
            Win();
        }
    }

    private void SetTimerText()
    {
        if ((int)currentTimer % 60 < 10)
            timer.text = (int)currentTimer / 60 + ":0" + (int)currentTimer % 60;
        else
            timer.text = (int)currentTimer / 60 + ":" + (int)currentTimer % 60;


        timerImage.fillAmount = currentTimer / timeToWin;
    }

    public void Win()
    {
        winText.SetActive(true);
        levelWin = true;
    }

    public void PlayerDeath()
    {
        endLevelCanva.SetActive(true);
        uiCanva.SetActive(false);
        player.GetComponent<Collider2D>().enabled = false;
        if (levelWin)
        {
            level.levelWin = true;
            win.SetActive(true);
        }
        else
        {
            loose.SetActive(true);
        }

        if (currentTimer > level.bestTimeSeconds)
        {
            level.bestTimeSeconds = currentTimer;

            if ((int)currentTimer % 60 < 10)
                level.bestTime = (int)currentTimer / 60 + ":0" + (int)currentTimer % 60;
            else
                level.bestTime = (int)currentTimer / 60 + ":" + (int)currentTimer % 60;
        }

        if(ScoreManager.instance.actualScore > level.highScore)
        {
            level.highScore = ScoreManager.instance.actualScore;
        }

        highScore.text = "high score : " + level.highScore.ToString("00000000000");
        score.text = "score : " + ScoreManager.instance.actualScore.ToString("00000000000");

        bestTime.text = "best time : " + level.bestTime;

        if ((int)currentTimer % 60 < 10)
            time.text = "time : " + (int)currentTimer / 60 + ":0" + (int)currentTimer % 60;
        else
            time.text = "time : " + (int)currentTimer / 60 + ":" + (int)currentTimer % 60;

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
