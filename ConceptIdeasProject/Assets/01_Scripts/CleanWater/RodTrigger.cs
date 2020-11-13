using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodTrigger : MonoBehaviour {
    ScoreManager _scoreManager;
    AudioManager _audioManager;

    public Transform _stand;
    public float _respawnTime = 2f;

    private Material[] _previousMaterial;
    private Renderer[] _rodRenderers;
    private bool _hasSpawned;

    private int _sharkBiteValue = 10;
    private bool _scoreSubtracted = false;
    
    private void Start() {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _audioManager = FindObjectOfType<AudioManager>();
        _rodRenderers = GetComponentsInChildren<Renderer>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Drop Zone")) {
            DestroyRod();
        }

        if (other.gameObject.CompareTag("Shark") && !_scoreSubtracted) {
            _audioManager.PlaySharkAttack();
            _scoreManager.SubtractPointsToScoreboard(_sharkBiteValue);
            _scoreSubtracted = true;
            DestroyRod();
            Debug.Log("Shark found");
        }

        if (other.gameObject.CompareTag("Waves")) {
            _audioManager.PlayRodSplash();
        }
    }

    private void DestroyRod() {
        foreach (Renderer renderer in _rodRenderers) {
            renderer.enabled = false;
        }

        Invoke("RespawnRod", _respawnTime);
        _hasSpawned = false;
        Debug.Log("Rod destroyed");
    }

    private void RespawnRod() {
        if (_hasSpawned == false) {
            transform.position = _stand.position;
            transform.rotation = _stand.rotation;

            foreach (Renderer renderer in _rodRenderers) {
                renderer.enabled = true;
            }
            _hasSpawned = true;
            Debug.Log("Rod respawned");
        }
    }
}
