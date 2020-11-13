using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Mål01 : MonoBehaviour
{
    private Score _scoreManager;
    public int _points = 10;

    public UnityEvent _cubeOnRightPlace;
    public Material _changeToMaterial;
    public Renderer _cube01;
    public GameObject _collider01;
    public GameObject _light01;
    public GameObject _image01;
    public AudioSource _scoreSound;
    public AudioSource _knaggleSound;

    public Transform _transformCube01;
    public Transform _respawnPoint;

    private void Start() {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_light01.activeSelf)
        {
            if (other.gameObject.tag == "Mål01")
            {
                if (!_scoreSound.isPlaying)
                {
                    _scoreSound.Play();
                }
                
                _cube01.material.color = _changeToMaterial.color;
                _collider01.SetActive(false);
                _image01.SetActive(true);

                _scoreManager.AddPointsToScoreboard(_points);


                if (_cubeOnRightPlace != null)
                {
                    _cubeOnRightPlace.Invoke();
                }
            }
        }

        if (other.CompareTag("RespawnArea"))
        {
            _transformCube01.transform.position = _respawnPoint.transform.position;
            
            if (!_knaggleSound.isPlaying)
            {
                _knaggleSound.Play();
            }
          
        }
    }
}
        
       
           


   
    

   









