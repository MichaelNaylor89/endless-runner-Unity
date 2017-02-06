using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour
{

    public GameObject MainMenu;
    public Text HIGHSCORE;
    public int HighScoreScore;
	void Start ()
    {
        MainMenu.SetActive(true);
        Time.timeScale = 0.0f;

        HighScoreScore = PlayerPrefs.GetInt("Highscore", 0);
	}
	
	
	void Update ()
    {
        HIGHSCORE.text = "Highscore: " + HighScoreScore;
	}

    public void ClickedStart()
    {
        MainMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ClickedQuit()
    {
        Application.Quit();
    }
}
