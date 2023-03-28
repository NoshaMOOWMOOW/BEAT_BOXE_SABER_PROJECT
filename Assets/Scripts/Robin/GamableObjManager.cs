using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamableObjManager : MonoBehaviour
{
    // List of object types to instantiate
    [SerializeField] private List<GameObject> _objectTypes;
    private GameObject _objectType;
    private GameObject _objToSpawn;

    // Prefabs Objects
    [SerializeField] private List<GameObject> _prefabs;

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
            MoveObjectTowardsPlayer(_objectType);
        }
        else
        {
            _canMove = false;
            print("Spawned Object is not initialized");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Deactivate spawned object 
        if (other.CompareTag("DestroyableObj1") ||
            other.CompareTag("DestroyableObj2") ||
            other.CompareTag("DestroyableObj3") ||
            other.CompareTag("DestroyableObj4") ||
            other.CompareTag("AvoidableObj") ||
            other.CompareTag("OpposableObj"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void InitializePool()
    {
        for (int i = 0; i < _objectTypes.Count; i++)
        {
            _objectTypes[i].SetActive(false);
            // _objectTypes.Add(_objectTypes[i]);
        }
    }

    private GameObject GetOjectFromPool(Vector3 location)
    {
        for (int i = 0; i < _objectTypes.Count; i++)
        {
            if (!_objectTypes[i].activeInHierarchy)
            {
                _objectTypes[i].transform.position = location;
                _objectTypes[i].SetActive(true);
                return _objectTypes[i];
            }
        }

        int randomIndex = Random.Range(0, 6);
        GameObject obj = Instantiate(_prefabs[randomIndex], location, Quaternion.identity);
        _objectTypes.Add(_prefabs[randomIndex]);
        return obj;
    }

    private void SpawnObjectRandomly()
    {
        // Get a random position
        int randomSpawnPointIndex = Random.Range(0, _spawnPoints.Length);
        _spawnPoint = _spawnPoints[randomSpawnPointIndex];

        // Get a random type of object
        int randomObjectIndex = Random.Range(0, _objectTypes.Count);
        _objectType = GetOjectFromPool(_spawnPoint.transform.position);

        // Instantier l'objet à la position générée
        // _objToSpawn = Instantiate(_objectType, _spawnPoint.position, Quaternion.identity);

        _canMove = true;

        // Mettre à jour le temps de dernière instantiation
        _lastSpawnTime = Time.time;
    }

    private void MoveObjectTowardsPlayer(GameObject gameObject)
    {
        gameObject.transform.position += -gameObject.transform.forward * _movementSpeed * Time.deltaTime;
    }
}