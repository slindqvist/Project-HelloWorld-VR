using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mål03 : MonoBehaviour
{
    private Score _scoreManager;
    public int _points = 10;

    public UnityEvent _cubeOnRightPlace;
    public Material _changeToMaterial;
    public Renderer _cube03;
    public GameObject _collider03;
    public GameObject _light03;
    public GameObject _image03;
    public AudioSource _scoreSound;
    public AudioSource _knaggleSound;

    public Transform _transformCube03;
    public Transform _respawnPoint;

    private void Start() {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light03.activeSelf)
        {
            if (other.gameObject.tag == "Mål03")
            {

                if (!_scoreSound.isPlaying)
                {
                    _scoreSound.Play();
                }

                _cube03.material.color = _changeToMaterial.color;
                _collider03.SetActive(false);
                _image03.SetActive(true);

                _scoreManager.AddPointsToScoreboard(_points);

                if (_cubeOnRightPlace != null)
                {
                    _cubeOnRightPlace.Invoke();
                }
            }
        }

        if (other.CompareTag("RespawnArea"))
        {
            _transformCube03.transform.position = _respawnPoint.transform.position;

            if (!_knaggleSound.isPlaying)
            {
                _knaggleSound.Play();
            }


        }
    }
}



           
