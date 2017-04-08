using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {
    public Button[] buttons;
    public Text scoreText;
    public Text highScore;
    int highscore;
    int score;
    bool gameOver;
    float delay;
    float timer;
	// Use this for initialization
	void Start () {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate", 1.0f, 0.5f);
        highscore = PlayerPrefs.GetInt("HighScore :", highscore);
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score :" + score;
        highScore.text = "HighScore :" + highscore;   
    }

    void scoreUpdate()
    {
        if (gameOver == false)
        {
            score += 1;
        }
        if (score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore :", highscore);
        }

    }
   public void Play()
    {
        Application.LoadLevel("level87");
        

    }
    public void gameOverActivated()
    {
        gameOver = true;
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
    
    public void menu()
    {
        Application.LoadLevel("MenuScene");
    }
    public void exit()
    {
        Application.Quit();
    }
    public void levelup()
    {
        if(score > highscore)
        {
            delay -= 0.4f;
            timer = delay;
        }
        
    }
}
// jancok