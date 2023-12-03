using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance {  get; private set; }
    public AudioSource source;
    private AudioClip clip;
    public GameObject player;

    public float goalTimer;
    private float currentTimer = 0.0f;

    public GameMode gameMode;

    private int life;
    public TextMeshProUGUI lifeText;

    public Level level;
    public GameObject endLevelPannel;
    public TextMeshProUGUI levelWin;
    public TextMeshProUGUI time;

    private bool winned = false;


    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        clip = source.clip;
        if(goalTimer == 0)
            goalTimer = clip.length;

        gameMode = level.mode;
        SetLife();
        lifeText.text = life.ToString();

    }

    private void FixedUpdate()
    {
        currentTimer += Time.deltaTime;

        if (currentTimer >= goalTimer && !winned)
        {
            winned = true;
            EndLevel(true);

        }
    }

    private void SetLife()
    {
        switch (gameMode)
        {
            case GameMode.OneShot:
                life = 1;
                break;
            case GameMode.ThreeShot:
                life = 3;
                break;
            case GameMode.NeverDie:
                life = 0;
                break;
        }
    }

    public void TakeBullet()
    {
        switch (gameMode)
        {
            case GameMode.OneShot:
                life--;
                break;
            case GameMode.ThreeShot:
                life--;
                break;
            case GameMode.NeverDie:
                life++;
                break;
        }

        if (gameMode != GameMode.NeverDie && life <= 0)
        {
            EndLevel(false);
        }

        lifeText.text = life.ToString();
    }

    public void EndLevel(bool win)
    {
        player.SetActive(false);
        endLevelPannel.SetActive(true);

        if(gameMode != GameMode.NeverDie)
            level.levelWin = win;

        if (win)
            levelWin.text = "Level win";
        else
            levelWin.text = "Level lost";

        string currentMinute = ((int)currentTimer / 60).ToString();
        string currentSecond = ((int)currentTimer % 60).ToString("00");

        time.text = "time : " + currentMinute + ":" + currentSecond + " / " +
            ((int)goalTimer / 60).ToString() + ":" + ((int)goalTimer % 60).ToString("00");
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

public enum GameMode
{
    NeverDie,
    OneShot,
    ThreeShot,
}
