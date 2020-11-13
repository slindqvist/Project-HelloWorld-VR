using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSpawner : MonoBehaviour
{
    public GameObject[] _prefabsToSpawn;
    public Transform _randomSpawnerOne;
    public Transform _randomSpawnerTwo;
    public Transform _randomSpawnerThree;

    private GameObject _spawnObject;

    void Awake()
    {
        FirstRandomSpawner();
        SecondRandomSpawner();
        ThirdRandomSpawner();
    }

    private void FirstRandomSpawner() {
        //int spawnpointIndex = Random.Range(0, _spawnPoints.Length);
        GameObject randomFromArray = _prefabsToSpawn[Random.Range(0, _prefabsToSpawn.Length)];

        _spawnObject = Instantiate(randomFromArray, _randomSpawnerOne);
    }

    private void SecondRandomSpawner() {
        //int spawnpointIndex = Random.Range(0, _spawnPoints.Length);
        GameObject randomFromArray = _prefabsToSpawn[Random.Range(0, _prefabsToSpawn.Length)];

        _spawnObject = Instantiate(randomFromArray, _randomSpawnerTwo);
    }

    private void ThirdRandomSpawner() {
        //int spawnpointIndex = Random.Range(0, _spawnPoints.Length);
        GameObject randomFromArray = _prefabsToSpawn[Random.Range(0, _prefabsToSpawn.Length)];

        _spawnObject = Instantiate(randomFromArray, _randomSpawnerThree);
    }
}
