using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : Ship
{
    private Rigidbody _rigidbody;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private AudioSource _fireAudio;
    
    private bool _isAudioPlay = false;

    private float _rotationAngle = 14f;

    private bool _isGameStarted = false;

    private enum RotateSide
    {
        Right = 1,
        Left = 2,
    }
    private RotateSide _rotateSide;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if(_isAlive)
        {
            if (Input.GetMouseButton(0) || Input.touchCount > 0)
            {
                if(!_isGameStarted)
                {
                    _isGameStarted = true;
                    _rigidbody.isKinematic = false;
                }
                if (!_isAudioPlay)
                {
                    _fireAudio.Play();
                    _isAudioPlay = true;
                }
                _isEngineOn = true;
                MoveShip();
            }
            else
            {
                _fireAudio.Stop();
                _isEngineOn = false;
                _isAudioPlay = false;

                switch(_rotateSide)
                {
                    case RotateSide.Right:
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 30),  Time.deltaTime);
                        break;
                    case RotateSide.Left:
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -30),  Time.deltaTime);
                        break;
                    default:
                        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0),  Time.deltaTime);
                        break;
                }
                
            }
        }
        else
        {
            _fireAudio.Stop();
        }
    }

    private void MoveShip()
    {
        _rigidbody.velocity = Vector3.up * _speed;

        Vector3 touchDeltaPosition = (Vector3)Input.GetTouch(0).deltaPosition;

        if (touchDeltaPosition.x > 4)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _rotationAngle * -1), _speed * Time.deltaTime);
            transform.Translate(Vector3.right * _speed * Time.fixedDeltaTime);
        }
        else if (touchDeltaPosition.x < -4)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _rotationAngle), _speed * Time.deltaTime);
            transform.Translate(Vector3.right * -1 * _speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), _speed * Time.deltaTime);
        }

        //if (Input.GetAxis("Mouse X") > 0)
        //{
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _rotationAngle * -1), _speed * Time.deltaTime);
        //    transform.Translate(Vector3.right * _speed * Time.fixedDeltaTime);
        //}
        //else if (Input.GetAxis("Mouse X") < 0)
        //{
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, _rotationAngle), _speed * Time.deltaTime);
        //    transform.Translate(Vector3.right * -1 * _speed * Time.fixedDeltaTime);
        //}
        //else
        //{
        //    transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), _speed * Time.deltaTime);
        //}

        _rotateSide = Random.Range(1, 3) == 1 ? RotateSide.Right : RotateSide.Left;
    }
}
