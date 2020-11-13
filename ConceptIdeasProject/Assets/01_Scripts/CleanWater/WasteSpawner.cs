using System.Collections;
using UnityEngine;

public class WasteSpawner : MonoBehaviour {
    public GameObject[] _wastePrefab;
    public bool debugMode;
    public float _maxTime = 10f;
    public float _minTime = 5f;

    private GameObject _spawnObject;
    //private float _time;
    private float _spawnTime;

    private Coroutine SpawnWaste;

    private void Start() {
        SpawnWaste = StartCoroutine(SpawnWasteCoroutine());
    }

    private void SetRandomTime() {
        _spawnTime = Random.Range(_minTime, _maxTime);
        Debug.Log("Next object spawn in " + _spawnTime + " seconds.");
    }

    public IEnumerator SpawnWasteCoroutine() {
        while (true) {
            Vector3 randomVector = Random.insideUnitSphere;
            Vector3 randomOffset = new Vector3(randomVector.x * transform.lossyScale.x,
                                               randomVector.y * transform.lossyScale.y,
                                               randomVector.z * transform.lossyScale.z);

            GameObject randomFromArray = _wastePrefab[Random.Range(0, _wastePrefab.Length)];
            _spawnObject = Instantiate(randomFromArray, transform.position + randomOffset * 0.5f, transform.rotation);

            SetRandomTime();
            yield return new WaitForSeconds(_spawnTime);
        }
    }

    public void StopSpawnWaste() {
        if (SpawnWaste != null) {
            StopCoroutine(SpawnWaste);
            Debug.Log("Spawner stopped");
        }
    }
}
