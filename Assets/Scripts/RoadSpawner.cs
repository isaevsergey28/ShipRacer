using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class RoadSpawner : MonoBehaviour
{
    private Transform _player;

    [SerializeField] private GameObject[] _roadBlocks;

    private List<GameObject> _currentRoads = new List<GameObject>();

    private ShipSpawner _shipSpawner;
    
    [Inject]
    private void Construct(ShipSpawner shipSpawner)
    {
        _shipSpawner = shipSpawner;
        
    }
    private float _startRoadYPos = 0;
    private float _roadCount = 7;
    private float _roadLenght = 43f;
    private float _removeRoad;

    private void Start()
    {
        _player = _shipSpawner._ship.transform;
        for (int i = 0; i < _roadCount; i++)
        {
            SpawnRoad();
        }
    }

    private void LateUpdate()
    {
        CkeckForSpawn();
    }

    private void CkeckForSpawn()
    {
        if(_player)
        {
            _removeRoad = _player.position.y - _roadLenght * 1.5f;
            foreach (GameObject road in _currentRoads)
            {

                _currentRoads = _currentRoads.Where(i => i != null).ToList();
                if (_removeRoad > road.transform.position.y)
                {

                    SpawnRoad();
                    DestroyRoad();
                }
            }
        }
    }

    private void SpawnRoad()
    {
        GameObject road = Instantiate(_roadBlocks[Random.Range(0, _roadBlocks.Length)], transform);
        Vector3 roadYPos;
        if (_currentRoads.Count > 0)
        {
            roadYPos = _currentRoads[_currentRoads.Count - 1].transform.position + new Vector3(0f, _roadLenght, 0f);
        }
        else
        {
            roadYPos = new Vector3(0f, _startRoadYPos, 0f);
        }
        road.transform.position = roadYPos;
        _currentRoads.Add(road);
    }
    private void DestroyRoad()
    {
        Destroy(_currentRoads[0]);
        _currentRoads.RemoveAt(0);

    }

}
