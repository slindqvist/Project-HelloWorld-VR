using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mål17 : MonoBehaviour
{
    private Score _scoreManager;
    public int _points = 10;

    public UnityEvent _cubeOnRightPlace;
    public Material _changeToMaterial;
    public Renderer _cube17;
    public GameObject _collider17;
    public GameObject _light17;
    public GameObject _image17;
    public AudioSource _scoreSound;
    public AudioSource _knaggleSound;

    public Transform _transformCube17;
    public Transform _respawnPoint;

    private void Start() {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light17.activeSelf)
        {
            if (other.gameObject.tag == "Mål17")
            {
                if (!_scoreSound.isPlaying)
                {
                    _scoreSound.Play();
                }
                
                _cube17.material.color = _changeToMaterial.color;
                _collider17.SetActive(false);
                _image17.SetActive(true);

                _scoreManager.AddPointsToScoreboard(_points);

                if (_cubeOnRightPlace != null)
                {
                    _cubeOnRightPlace.Invoke();
                }
            }
        }

        if (other.CompareTag("RespawnArea"))
        {
            _transformCube17.transform.position = _respawnPoint.transform.position;

            if (!_knaggleSound.isPlaying)
            {
                _knaggleSound.Play();
            }

        }
    }
}



            
