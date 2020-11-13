using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject _loadScenePlaceholder;

    public void PlayGame() {
        _loadScenePlaceholder.SetActive(true);
    }

    public void EndGame() {
        Application.Quit();
        Debug.Log("Quitting game");
    }
}
