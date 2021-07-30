using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 7;

    private Ship _ship;

    [Inject]
    private void Construct(Ship ship)
    {
        _ship = ship;
        
    }
    void FixedUpdate()
    {
        if(_ship.GetShipAlive() )
        {
            transform.Translate(Vector3.up * Time.fixedDeltaTime * _speed);
        }
    }
}
