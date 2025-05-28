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
    [SerializeField] private TextMeshProUGUI winHighScore;
    [SerializeField] private TextMeshProUGUI winDistanceText;

    [SerializeField] private GameObject _winScreenCanvas;
    [SerializeField] private float winDistance = 850;

    private bool hasWon = false;
    private bool canCheckWin = false;


    private void Start()
    {
        StartCoroutine(EnableWinCheckAfterDelay());
    }

    private void Update()
    {
        if (!hasWon && DisplayDistance.instance.distance.x >= winDistance)
        {
            WinGame();
        }
    }

    private IEnumerator EnableWinCheckAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); 
        canCheckWin = true;
    }

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        Time.timeScale = 1f;
    }

    public void WinGame()
    {
        hasWon = true;
        Time.timeScale = 0f;
        _winScreenCanvas.SetActive(true);
        winDistanceText.text = DisplayDistance.instance._distanceText.text;
        DisplayDistance.instance.GetHighScore();
        score = DisplayDistance.instance._highScore;
        winHighScore.text = "High Score: " + score.ToString("F0") + "m";
    }

    public void GameOver()
    {
        if (hasWon) return;

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
