using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _maxHeight;
    [SerializeField] private float _minHeight;

    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _speedRotation;
    private AudioSource _moveSound;

    
    private Vector3 _targetPosition;
    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Quaternion _startRotation;

    private void Start()
    {
        _targetPosition = transform.position;
        _startRotation = Quaternion.Euler(Vector3.zero);
        _moveSound = GetComponent<AudioSource>();
        _minRotation = Quaternion.Euler(0, 0, -_maxRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);

    }

    private void Update()
    {
        if (_targetPosition != transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
        ResetRotate();
    }

    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
        {
            SetNextPosition(_stepSize);
            PlayMoveSound();
            SetNextRotation(_maxRotation);
        }
    }

    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeight)
        {
            SetNextPosition(-_stepSize);
            PlayMoveSound();
            SetNextRotation(_minRotation);
        }
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y + stepSize);
    }

    private void SetNextRotation(Quaternion rotationZ)
    {
        transform.rotation = rotationZ;
    }
    
    public void ResetRotate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _startRotation, _speedRotation * Time.deltaTime);
    }

    private void PlayMoveSound()
    {
        _moveSound.Play();
    }
}
