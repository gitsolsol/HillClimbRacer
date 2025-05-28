using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI distance = DisplayDistance.instance._distanceText;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private TextMeshProUGUI distanceText;
    public float score = 0; 
    [SerializeField] private TextMeshProUGUI highScore;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        _gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        distanceText.text = distance.text;       
        DisplayDistance.instance.GetHighScore();
        score = DisplayDistance.instance._highScore;
        highScore.text = "High Score: " + score.ToString("F0") + "m";
        //DisplayDistance.instance.ResetHighScore();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
}
