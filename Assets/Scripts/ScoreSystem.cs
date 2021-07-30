using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreSystem : MonoBehaviour
{
    private Text _scoreText;
    private float _score;
    private Ship _ship;

    [Inject]
    private void Construct(Ship ship)
    {
        _ship = ship;
    }
    private void Start()
    {
        _scoreText = GetComponent<Text>();
    }
    private void Update()
    {
        if(_ship.GetShipAlive())
        {
            _score += Time.deltaTime;
            _scoreText.text = "SCORE : " + ((int)_score).ToString() + "\nCOINS : " + _ship.GetCoins();
        }
        
    }
}
