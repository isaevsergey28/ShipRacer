using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    private Ship _ship;
    [SerializeField] private float _speed = 7;

    [Inject]
    private void Construct(Ship ship)
    {
        _ship = ship;
    }
    void FixedUpdate()
    {
        if(_ship.GetShipAlive())
        {
            transform.Translate(Vector3.up * Time.fixedDeltaTime * _speed);
        }
    }
}
