﻿using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI gemsText;

    public Animator messageAnim;

    private void Start()
    {
        Time.timeScale = 1;
    }
    private void Update()
    {
       
        gemsText.text = PlayerPrefs.GetInt("TotalGems", 0).ToString();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
