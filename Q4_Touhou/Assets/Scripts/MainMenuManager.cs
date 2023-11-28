using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public List<Level> allLevels;

    public TextMeshProUGUI levelNumber;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI maxTime;
    public TextMeshProUGUI levelWin;

    public Color winColor;
    public Color looseColor;

    public string sceneToLoad = "";

    public GameObject pannel;

    private void Start()
    {
        pannel.SetActive(false);
    }

    public void OnClick(int level)
    {
        pannel.SetActive(true);
        levelNumber.text = "Level " + allLevels[level].level;
        highScore.text = "high score : " + allLevels[level].highScore.ToString("000000000");
        maxTime.text = "Best time : " + allLevels[level].bestTime;
        sceneToLoad = allLevels[level].sceneName;

        if (allLevels[level].levelWin)
        {
            levelWin.text = "Win";
            levelWin.color = winColor;
        }
        else
        {
            levelWin.text = "not win";
            levelWin.color = looseColor;
        }

    }

    public void PlayButton()
    {
        if(sceneToLoad != "")
            SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

