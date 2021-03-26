using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject _ship { get; private set; }
    [SerializeField] private GameObject _shipPrefab;

    private void Awake()
    {
        _ship = Instantiate(_shipPrefab, transform.position, Quaternion.identity, transform);
    }
}
