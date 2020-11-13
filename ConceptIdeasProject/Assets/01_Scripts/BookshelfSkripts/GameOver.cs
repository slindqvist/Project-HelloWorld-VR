using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    Score _scoreManager;

    public void Start()
    {
        _scoreManager = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _scoreManager.StartCoroutine("GameOverCoroutine");
            Debug.Log("GameOver");
        } 
    }
}
