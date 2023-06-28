using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    //[SerializeField] private int _minDistance;
    //[SerializeField] private int _maxDistance;
    [SerializeField] private float _rotationSpeed;

    private float _moveSpeed;

    private float _rotateSpeedUP = 3f;
    private float _timeBeforeSpeedUp = 5f;
    private float _elapsedTime;

    public void Init(float moveSpeed)
    {
        _moveSpeed = moveSpeed;
    }
    private void Update()
    {
        transform.Translate(Vector3.left * _moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(new Vector3(0, 0, _rotationSpeed * Time.deltaTime));

        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _timeBeforeSpeedUp)
        {
            _elapsedTime = 0;

            _rotationSpeed += _rotateSpeedUP;
        }
    }
}
