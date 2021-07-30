using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _bombSpawners;
    [SerializeField] private GameObject _bombPrefab;
    private List<GameObject> _allBombs = new List<GameObject>();
    [SerializeField] private Transform _deathPoint;

    private void Update()
    {
        CheckForSpawn();
        CheckDorDestroy();
    }

    private void CheckDorDestroy()
    {
        _allBombs = _allBombs.Where(i => i != null).ToList();
        foreach (GameObject bomb in _allBombs.ToList())
        {
            if (bomb.transform.position.y < _deathPoint.position.y)
            {
                _allBombs.Remove(bomb);
                Destroy(bomb);
            }
        }
    }

    private void CheckForSpawn()
    {
        if (Random.Range(0, 300) == 1)
        {
            GameObject bomb;
            bomb = Instantiate(_bombPrefab, _bombSpawners[Random.Range(0, _bombSpawners.Length)].position, Quaternion.identity, null);

            _allBombs.Add(bomb);
        }
    }

  
}
