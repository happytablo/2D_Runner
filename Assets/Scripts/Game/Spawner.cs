using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _timeBetweenSpawns;
    [SerializeField] private float _minTimeBetweenSpawns = 0.5f;
    [SerializeField] private float _timeSpawnUp;

    [SerializeField] private float _slowSpeed = 3f;
    [SerializeField] private float _fastSpeed = 6f;

    [SerializeField] private SpeedControl _speedControl;

    private float _elapsedTime;
    private int _previousPos;

    private void Start()
    {
        Initialize(_prefabs);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _timeBetweenSpawns)
        {
            GetObjectInPool();
        }
    }

    private void GetObjectInPool()
    {
        if (TryGetObject(out GameObject prefab))
            _elapsedTime = 0;

        int _spawnPointNumber = SetSpawnPoint();

        SetPosition(prefab, _spawnPoints[_spawnPointNumber].gameObject.transform.position);

        SetSpeedUp(prefab);
    }

    private void SetSpeedUp(GameObject prefab)
    {
        float enemySpeed = _speedControl.GetCurrentSpeed(_slowSpeed, _fastSpeed);
        EnemyMover enemyMover = prefab.GetComponent<EnemyMover>();
        enemyMover.Init(enemySpeed);

        if (_timeBetweenSpawns > _minTimeBetweenSpawns)
            _timeBetweenSpawns -= _timeSpawnUp;
    }

    private void SetPosition(GameObject prefab, Vector3 position)
    {
        prefab.SetActive(true);
        prefab.transform.position = position;
    }

    private int SetSpawnPoint()
    {
        int randomPosition;

        do
            randomPosition = Random.Range(0, 3);
        while (randomPosition == _previousPos);

        _previousPos = randomPosition;
        return _previousPos;
    }
}
