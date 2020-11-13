using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mål11 : MonoBehaviour
{
    private Score _scoreManager;
    public int _points = 10;

    public UnityEvent _cubeOnRightPlace;
    public Material _changeToMaterial;
    public Renderer _cube11;
    public GameObject _collider11;
    public GameObject _light11;
    public GameObject _image11;
    public AudioSource _scoreSound;
    public AudioSource _knaggleSound;

    public Transform _transformCube11;
    public Transform _respawnPoint;

    private void Start() {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light11.activeSelf)
        {
            if (other.gameObject.tag == "Mål11")
            {

                if (!_scoreSound.isPlaying)
                {
                    _scoreSound.Play();
                }

                _cube11.material.color = _changeToMaterial.color;
                _collider11.SetActive(false);
                _image11.SetActive(true);

                _scoreManager.AddPointsToScoreboard(_points);

                if (_cubeOnRightPlace != null)
                {
                    _cubeOnRightPlace.Invoke();
                }
            }
        }

        if (other.CompareTag("RespawnArea"))
        {
            _transformCube11.transform.position = _respawnPoint.transform.position;

            if (!_knaggleSound.isPlaying)
            {
                _knaggleSound.Play();
            }

        }
    }
}



          
