using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;


public class DisplayDistance : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _distanceText;
    [SerializeField] private Transform _playerTrans;
    public static DisplayDistance instance;

    private Vector2 _startPosition;
    public float _highScore = 0;
    public Vector2 distance;

    private void Start()
    {
        _startPosition = _playerTrans.position;
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
    }

    public void GetHighScore()
    {       
       if(distance.x > _highScore)
        {
            _highScore = distance.x;
        }
        print(_highScore);
    }
    
}
