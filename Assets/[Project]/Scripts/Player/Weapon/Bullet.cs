using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private float _bulletSpeed = 10;
    private float _damage = 1;

    void Start()
    {
        Destroy(gameObject, 10f);
    }

    public void Initialize(float damage, float bulletSpeed)
    {
        _damage = damage;
        _bulletSpeed = bulletSpeed;
    }

    void Update()
    {
        transform.Translate(Vector3.right * _bulletSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<PlayerControler>())
            return;
        
        Destroy(gameObject);
    }
}
