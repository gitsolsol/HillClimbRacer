using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class DisplayDistance : MonoBehaviour
{
    public static DisplayDistance instance;

    [SerializeField] public TextMeshProUGUI _distanceText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private Transform _playerTrans;


    private Vector2 _startPosition;
    public float _highScore;
    public Vector2 distance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _startPosition = _playerTrans.position;
        //_highScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    public void Update()
    { 
        distance = (Vector2)_playerTrans.position - _startPosition;
        distance.y = 0f; 

        if(distance.x< 0)
        {
           distance.x = 0;
        }
        _distanceText.text = distance.x.ToString("F0") + "m";
        DisplayDistance.instance.GetHighScore();
        highScoreText.text = "High Score: " + _highScore.ToString("F0") + "m";
    }

    public void GetHighScore()
    {       
       if(distance.x > _highScore)
        {
            _highScore = distance.x;
            //PlayerPrefs.SetFloat("HighScore", _highScore); // Save new high score
            //PlayerPrefs.Save();
        }
    }
    
}
