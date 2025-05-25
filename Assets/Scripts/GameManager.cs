using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private TextMeshProUGUI distance = DisplayDistance.distanceText._distanceText;
    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private TextMeshProUGUI distanceText;

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
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    } 
}
