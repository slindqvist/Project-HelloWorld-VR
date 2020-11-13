using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mål10 : MonoBehaviour
{
    private Score _scoreManager;
    public int _points = 10;

    public UnityEvent _cubeOnRightPlace;
    public Material _changeToMaterial;
    public Renderer _cube10;
    public GameObject _collider10;
    public GameObject _light10;
    public GameObject _image10;
    public AudioSource _scoreSound;
    public AudioSource _knaggleSound;

    public Transform _transformCube10;
    public Transform _respawnPoint;

    private void Start() {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light10.activeSelf)
        {
            if (other.gameObject.tag == "Mål10")
            {
                if (!_scoreSound.isPlaying)
                {
                    _scoreSound.Play();
                }

                _cube10.material.color = _changeToMaterial.color;
                _collider10.SetActive(false);
                _image10.SetActive(true);

                _scoreManager.AddPointsToScoreboard(_points);

                if (_cubeOnRightPlace != null)
                {
                    _cubeOnRightPlace.Invoke();
                }
            }
        }

        if (other.CompareTag("RespawnArea"))
        {
            _transformCube10.transform.position = _respawnPoint.transform.position;

            if (!_knaggleSound.isPlaying)
            {
                _knaggleSound.Play();
            }

        }
    }
}


          

