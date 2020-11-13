using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mål08 : MonoBehaviour
{
    private Score _scoreManager;
    public int _points = 10;

    public UnityEvent _cubeOnRightPlace;
    public Material _changeToMaterial;
    public Renderer _cube08;
    public GameObject _collider08;
    public GameObject _light08;
    public GameObject _image08;
    public AudioSource _scoreSound;
    public AudioSource _knaggleSound;

    public Transform _transformCube08;
    public Transform _respawnPoint;

    private void Start() {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light08.activeSelf)
        {
            if (other.gameObject.tag == "Mål08")
            {

                if (!_scoreSound.isPlaying)
                {
                    _scoreSound.Play();
                }

                _cube08.material.color = _changeToMaterial.color;
                _collider08.SetActive(false);
                _image08.SetActive(true);

                _scoreManager.AddPointsToScoreboard(_points);

                if (_cubeOnRightPlace != null)
                {
                    _cubeOnRightPlace.Invoke();
                }
            }
        }

        if (other.CompareTag("RespawnArea"))
        {
            _transformCube08.transform.position = _respawnPoint.transform.position;

            if (!_knaggleSound.isPlaying)
            {
                _knaggleSound.Play();
            }

        }
    }
}



           
