using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    static protected bool _isAlive = true;
    static protected bool _isEngineOn = false;
    static protected int _coins;

    public void RestartValues()
    {
        _isAlive = true;
        _isEngineOn = false;
        _coins = 0;
    }
    public bool GetShipAlive()
    {
        return _isAlive;
    }
    public int GetCoins()
    {
        return _coins;
    }
}
