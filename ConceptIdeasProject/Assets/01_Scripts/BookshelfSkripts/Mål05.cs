using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mål05 : MonoBehaviour
{
    private Score _scoreManager;
    public int _points = 10;

    public UnityEvent _cubeOnRightPlace;
    public Material _changeToMaterial;
    public Renderer _cube05;
    public GameObject _collider05;
    public GameObject _light05;
    public GameObject _image05;
    public AudioSource _scoreSound;
    public AudioSource _knaggleSound;

    public Transform _transformCube05;
    public Transform _respawnPoint;

    private void Start() {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light05.activeSelf)
        {
            if (other.gameObject.tag == "Mål05")
            {
                if (!_scoreSound.isPlaying)
                {
                    _scoreSound.Play();
                }

                _cube05.material.color = _changeToMaterial.color;
                _collider05.SetActive(false);
                _image05.SetActive(true);

                _scoreManager.AddPointsToScoreboard(_points);

                if (_cubeOnRightPlace != null)
                {
                    _cubeOnRightPlace.Invoke();
                }
            }
        }

        if (other.CompareTag("RespawnArea"))
        {
            _transformCube05.transform.position = _respawnPoint.transform.position;

            if (!_knaggleSound.isPlaying)
            {
                _knaggleSound.Play();
            }

        }
    }
}


          

