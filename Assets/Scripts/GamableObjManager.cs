using System.Collections.Generic;
using UnityEngine;

public class GamableObjManager : MonoBehaviour
{
    // List of object types to instantiate
    [SerializeField] private List<GameObject> _objectTypes;
    private GameObject _objToSpawn;

    // Prefabs Pool Objects
    private List<GameObject> _prefabsPool;

    // Array of spawn points
    [SerializeField] private Transform[] _spawnPoints = new Transform[3];
    private Transform _spawnPoint;


    // Delay between object spawns
    [SerializeField] private float _spawnRate;

    // Time elapsed since the last instantiation
    private float _lastSpawnTime;

    // Amount of time to change position
    [SerializeField] private float _movementSpeed;

    private bool _canMove;


    private void Start()
    {
        _prefabsPool = new List<GameObject>();
        InitializePool();
    }

    private void Update()
    {
        // Check if the time elapsed since the last instantiation is greater than the spawn time
        if (Time.time - _lastSpawnTime >= _spawnRate)
        {
            SpawnObjectRandomly();
        }

        // Move spawned object

        if (_objToSpawn != null && _canMove)
        {
            MoveObjectTowardsPlayer(_objToSpawn);
        }
        else
        {
            _canMove = false;
        }

        // ScoreManager.InstanceScoreManager.DisplayScore();
    }

    private void OnTriggerEnter(Collider objSpawned)
    {
        _objToSpawn = objSpawned.gameObject;

        // Deactivate spawned object 
        if (objSpawned.CompareTag("DestroyableObj1") ||
            objSpawned.CompareTag("DestroyableObj2") ||
            objSpawned.CompareTag("DestroyableObj3") ||
            objSpawned.CompareTag("DestroyableObj4") ||
            objSpawned.CompareTag("AvoidableObj") ||
            objSpawned.CompareTag("OpposableObj"))
        {
            objSpawned.gameObject.SetActive(false);
        }
    }

    private void InitializePool()
    {
        for (int i = 0; i < _objectTypes.Count; i++)
        {
            GameObject obj = Instantiate(_objectTypes[i]);
            obj.SetActive(false);
            _prefabsPool.Add(obj);
        }
    }

    private GameObject GetOjectFromPool(Vector3 location)
    {
        Shuffle(_prefabsPool);

        for (int i = 0; i < _prefabsPool.Count; i++)
        {
            if (!_prefabsPool[i].activeInHierarchy)
            {
                _prefabsPool[i].transform.position = location;
                _prefabsPool[i].SetActive(true);
                return _prefabsPool[i];
            }
        }

        int randomIndex = Random.Range(0, 6);
        GameObject obj = Instantiate(_objectTypes[randomIndex], location, Quaternion.identity);
        _prefabsPool.Add(obj);
        return obj;
    }

    private void SpawnObjectRandomly()
    {
        // Get a random position
        int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);
        _spawnPoint = _spawnPoints[randomSpawnPointIndex];

        // Get a random type of object
        int randomObjectIndex = Random.Range(0, _objectTypes.Count);

        _objToSpawn = GetOjectFromPool(_spawnPoint.transform.position);

        _canMove = true;

        // Update the time of the last instantiation
        _lastSpawnTime = Time.time;
    }

    private void MoveObjectTowardsPlayer(GameObject objSpawned)
    {
        if (objSpawned.CompareTag("DestroyableObj1") ||
            objSpawned.CompareTag("DestroyableObj2") ||
            objSpawned.CompareTag("DestroyableObj3") ||
            objSpawned.CompareTag("DestroyableObj4") ||
            objSpawned.CompareTag("AvoidableObj") ||
            objSpawned.CompareTag("OpposableObj"))
        {
            objSpawned.transform.position += -objSpawned.transform.forward * _movementSpeed * Time.deltaTime;
        }
    }

    // Shuffle the lists of inactive objects every time GetObjectFromPool() is called
    private void Shuffle<T>(List<T> list)
    {
        int listNum = list.Count;
        for (int i = 0; i < listNum - 1; i++)
        {
            int random = Random.Range(i, listNum);
            T value = list[random];
            list[random] = list[i];
            list[i] = value;
        }
    }
}

