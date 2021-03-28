using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = -5f;
    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.parent.TryGetComponent(out ShipBehaviour shipBehaviour))
        {
            shipBehaviour.DestroyShip();
            Destroy(this.gameObject);
        }
    }
}
