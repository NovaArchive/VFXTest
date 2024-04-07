using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Transform rootMesh;
    [SerializeField] private float dissolveTime;
    [SerializeField] private float spinSpeed;
    [SerializeField] private float moveSpeed;
    
    private Vector3 _direction;
    private float _time;
    private bool _initialized;

    private void Awake()
    {
        _initialized = false;
        _time = dissolveTime;
    }

    public void Init(Vector3 direction)
    {
        _direction = direction;

        _initialized = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_initialized) return;

        if (_time <= 0)
        {
            Destroy(gameObject);
            return;
        }
        
        _time -= Time.deltaTime;
        rootMesh.Rotate(0, spinSpeed * 360 * Time.deltaTime, 0, Space.Self);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, moveSpeed * Time.deltaTime);
    }
}
