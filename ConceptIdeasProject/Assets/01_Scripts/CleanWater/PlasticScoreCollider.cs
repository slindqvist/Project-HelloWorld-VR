using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticScoreCollider : MonoBehaviour
{
    ScoreManager _scoreManager;
    AudioManager _audioManager;

    private int _targetHitValue = 10;
    private bool _sccoreAdded = false;

    private void Start() {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Plastic") && !_sccoreAdded) {
            _audioManager.PlayScorePoint();
            _scoreManager.AddPointsToScoreboard(_targetHitValue);
            _sccoreAdded = true;
        }
    }
}
