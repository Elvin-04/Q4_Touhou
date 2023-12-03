using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    private AudioSource audioSource;
    private int levelSelected = -1;

    public List<Level> levels;

    public TextMeshProUGUI musicName;
    public TextMeshProUGUI musicTime;
    public TextMeshProUGUI levelWin;

    public string sceneToLoad = "";

    public GameObject pannel;

    public  TMP_Dropdown dropdownGameMode;

    private void Start()
    {
        levelSelected = 1000;
        audioSource = GetComponent<AudioSource>();
        pannel.SetActive(false);
    }

    public void OnClick(int levelSelected)
    {
        audioSource.clip = levels[levelSelected].clip;
        if (this.levelSelected != levelSelected)
        {
            audioSource.time = 15f;
            audioSource.Play();
        }

        this.levelSelected = levelSelected;
        pannel.SetActive(true);
        
        
        
        sceneToLoad = levels[levelSelected].sceneName;

        if (levels[levelSelected].levelWin)
        {
            levelWin.text = "won : yes";
        }
        else
        {
            levelWin.text = "won : no";
        }

        musicName.text = "music : " + levels[levelSelected].clip.name;

        float minutes = levels[levelSelected].clip.length / 60;
        int seconds = (int)levels[levelSelected].clip.length % 60;
        string secondsText;
        if (seconds < 10)
        {
            secondsText = "0" + seconds;
        }
        else
        {
            secondsText = seconds.ToString();
        }

        musicTime.text = "music time : " + (int)minutes + ":" + secondsText;
    }

    public void PlayButton()
    {

        switch(dropdownGameMode.value)
        {
            case 0:
                levels[levelSelected].mode = GameMode.NeverDie;
                break;
            case 1:
                levels[levelSelected].mode = GameMode.OneShot;
                break;
            case 2:
                levels[levelSelected].mode = GameMode.ThreeShot;
                break;
        }

        if(sceneToLoad != "")
            SceneManager.LoadScene(sceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

