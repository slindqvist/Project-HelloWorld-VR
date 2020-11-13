using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mål09 : MonoBehaviour
{
    private Score _scoreManager;
    public int _points = 10;

    public UnityEvent _cubeOnRightPlace;
    public Material _changeToMaterial;
    public Renderer _cube09;
    public GameObject _collider09;
    public GameObject _light09;
    public GameObject _image09;
    public AudioSource _scoreSound;
    public AudioSource _knaggleSound;

    public Transform _transformCube09;
    public Transform _respawnPoint;

    private void Start() {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light09.activeSelf)
        {
            if (other.gameObject.tag == "Mål09")
            {
                if (!_scoreSound.isPlaying)
                {
                    _scoreSound.Play();
                }

                _cube09.material.color = _changeToMaterial.color;
                _collider09.SetActive(false);
                _image09.SetActive(true);

                _scoreManager.AddPointsToScoreboard(_points);

                if (_cubeOnRightPlace != null)
                {
                    _cubeOnRightPlace.Invoke();
                }
            }
        }

        if (other.CompareTag("RespawnArea"))
        {
            _transformCube09.transform.position = _respawnPoint.transform.position;

            if (!_knaggleSound.isPlaying)
            {
                _knaggleSound.Play();
            }

        }
    }
}



           
