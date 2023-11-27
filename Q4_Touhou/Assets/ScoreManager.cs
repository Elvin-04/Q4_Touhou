using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int actualScore {  get; private set; }

    public static ScoreManager instance { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoretext;

    public float addingScore = 0.1f;
    public int scoreToAddPerSecond = 250;

    private float currentTime = 0.0f;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        actualScore = 0;
        AddScore(0);

        string highScore = GameManager.instance.level.highScore.ToString("000000000000");

        highScoretext.text = highScore;
    }

    private void Update()
    {
        if(currentTime < addingScore)
        {
            currentTime += Time.deltaTime;
        }
        else
        {
            currentTime = 0.0f;
            AddScore(scoreToAddPerSecond);
        }
    }

    public void AddScore(int amount)
    {
        actualScore += amount;
        
        string score = actualScore.ToString("000000000000");

        scoreText.text = score;
    }
}
