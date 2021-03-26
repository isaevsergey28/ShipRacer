using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBehaviour : Ship
{
    [SerializeField] private GameObject _explosionPrefab;
    [SerializeField] private ParticleSystem _fire;
    [SerializeField] private AudioSource _explosionAudio;
    private Transform _deathPoint;

    private void Awake()
    {
        _deathPoint = GameObject.Find("DeathPoint").transform;
    }
    private void Update()
    {
        if (_isAlive)
        {
            if (transform.position.y < _deathPoint.position.y)
            {
                _isAlive = false;
            }
            CheckEngine();
        }
    }

    private void CheckEngine()
    {
        _fire.enableEmission = _isEngineOn;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            _isAlive = false;
            DestroyShip();
        }
        else if (other.gameObject.tag == "coins")
        {
            CollectCoins(other);
        }
    }

    private void CollectCoins(Collider other)
    {
        _coins++;
        Destroy(other.gameObject);
    }

    private void DestroyShip()
    {
        GameObject explosion;
        float time;
        CreateExplosion(out explosion, out time);
        Destroy(gameObject, time);
        Destroy(explosion, time);
    }

    private void CreateExplosion(out GameObject explosion, out float time)
    {
        _explosionAudio.Play();
        explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity, null);
        gameObject.transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
        _fire.enableEmission = false;
        time = _explosionPrefab.GetComponent<ParticleSystem>().main.duration;
    }
}
