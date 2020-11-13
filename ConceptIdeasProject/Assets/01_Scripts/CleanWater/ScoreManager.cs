using UnityEngine;
using System.Collections;
using TMPro;

public class ScoreManager : MonoBehaviour {
    private PlasticWasteManager _plasticManager;
    private MetalWasteManager _metalManager;
    private ElectronicWasteManager _electronicManager;
    private WasteSpawner _wasteSpawner;
    private WinSceneAnimControl _winSceneAnimControl;
    private CleanWaterTimer _cleanWaterTimer;
    private Highscores _highscores;

    public bool _firstLevelComplete;
    private float _score = 0f;

    public TextMeshProUGUI _scoreboardText;
    public int _points;

    public GameObject _placeHolder;
    public float waitTime = 10f;

    // Score based on timer
    private float _timeElapsed;
    private float _maxTime = 180f;
    private float _bonusScore = 1;
    private float _timerScore;

    // Username
    public string username = "";
    public TextMeshProUGUI _usernameText;

    private int _totScore;

    void Start() {
        _plasticManager = FindObjectOfType<PlasticWasteManager>();
        _metalManager = FindObjectOfType<MetalWasteManager>();
        _electronicManager = FindObjectOfType<ElectronicWasteManager>();
        _wasteSpawner = FindObjectOfType<WasteSpawner>();
        _winSceneAnimControl = FindObjectOfType<WinSceneAnimControl>();
        _cleanWaterTimer = FindObjectOfType<CleanWaterTimer>();
        _highscores = FindObjectOfType<Highscores>();

        _firstLevelComplete = false;
        _cleanWaterTimer._timerIsRunning = true;

        _points = 0;
        _scoreboardText.text = "Bonus: " + _points + "p";

        GenerateUsername();
    }

    void Update() {
        if (!_firstLevelComplete) {
            if (_plasticManager._plasticCount == _score) {
                if (_metalManager._metalCount == _score) {
                    if (_electronicManager._electronicCount == _score) {
                        _cleanWaterTimer._timerIsRunning = false;
                        AssignBonusPoints();
                        _wasteSpawner.StopSpawnWaste();
                        _winSceneAnimControl.PlayWinScene();
                        _firstLevelComplete = true;
                        _highscores.AddNewHighscore(username, _totScore);
                        StartCoroutine("GameOverCoroutine");
                        Debug.Log("Level 1 Complete");
                    }
                }
            }
        }
    }

    private void AssignBonusPoints() {
        _timerScore = Mathf.Max(0, _maxTime - _timeElapsed) * _bonusScore;
        _totScore = _points + (int)_timerScore;
        Debug.Log("Bonus " + _timerScore);
    }

    public void AddPointsToScoreboard(int amount) {
        _points = _points + amount;
        _scoreboardText.text = "Bonus: " + _points + "p";
    }

    public void SubtractPointsToScoreboard(int amount) {
        _points = _points - amount;
        _scoreboardText.text = "Bonus: " + _points + "p";
    }

    public void GenerateUsername() {
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        for (int i = 0; i < 3; i++) {
            username += alphabet[Random.Range(0, alphabet.Length)];
        }

        _usernameText.text = username;
    }

    public IEnumerator GameOverCoroutine() {
        yield return new WaitForSeconds(waitTime);
        _placeHolder.SetActive(true);
        Debug.Log("Returning to Start scene...");
    }
}
