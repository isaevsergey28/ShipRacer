using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using UnityEngine.SceneManagement;

public class RestartSystem : MonoBehaviour
{
    [SerializeField] private GameObject _losingText;
    [SerializeField] private GameObject _restartButton;
    [SerializeField] private GameObject _startText;

    private bool _isGameOver = false;
    private Ship _ship;

    [Inject]
    private void Construct(Ship ship)
    {
        _ship = ship;
    }
    private void Start()
    {
        StartCoroutine(OffStartText());
    }
    private void Update()
    {
        if(!_isGameOver)
        {
            if (!_ship.GetShipAlive())
            {
                _isGameOver = true;
                _losingText.SetActive(true);
                _restartButton.SetActive(true);
            }
        }
    }
    public void RestartGame()
    {
        _ship.RestartValues();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
    private IEnumerator OffStartText()
    {
        yield return new WaitForSeconds(1f);
        _startText.SetActive(false);
    }
}
