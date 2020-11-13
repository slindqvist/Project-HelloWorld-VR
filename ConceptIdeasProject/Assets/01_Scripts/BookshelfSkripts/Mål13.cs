using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mål13 : MonoBehaviour
{
    private Score _scoreManager;
    public int _points = 10;

    public UnityEvent _cubeOnRightPlace;
    public Material _changeToMaterial;
    public Renderer _cube13;
    public GameObject _collider13;
    public GameObject _light13;
    public GameObject _image13;
    public AudioSource _scoreSound;
    public AudioSource _knaggleSound;

    public Transform _transformCube13;
    public Transform _respawnPoint;

    private void Start() {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light13.activeSelf)
        {
            if (other.gameObject.tag == "Mål13")
            {
                if (!_scoreSound.isPlaying)
                {
                    _scoreSound.Play();
                }

                _cube13.material.color = _changeToMaterial.color;
                _collider13.SetActive(false);
                _image13.SetActive(true);

                _scoreManager.AddPointsToScoreboard(_points);

                if (_cubeOnRightPlace != null)
                {
                    _cubeOnRightPlace.Invoke();
                }
            }
        }

        if (other.CompareTag("RespawnArea"))
        {
            _transformCube13.transform.position = _respawnPoint.transform.position;

            if (!_knaggleSound.isPlaying)
            {
                _knaggleSound.Play();
            }


        }
    }
}

           


