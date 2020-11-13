using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour {
    private BookshelfHighscores _bookshelfHighscores;
    private Score _scoreManager;

    public List<GameObject> _floorPlateList = new List<GameObject>();
    public GameObject _lastFloorPlate;
    public GameObject _bokShelf;
    public Animator _floorAnimation;

    public float _totalTime = 210f;

    public Text _timerText;
    public Text _gameOverText;

    public bool _timerIsRunning;
    public bool _gameOver;

    public AudioSource _tickingSound;

    public void Start() {
        _bookshelfHighscores = FindObjectOfType<BookshelfHighscores>();
        _scoreManager = FindObjectOfType<Score>();

        StartCoroutine(FloorPanelOff());
        Shuffle(_floorPlateList);
        _gameOverText.enabled = false;

        _timerIsRunning = true;
        _gameOver = false;
    }

    public void Update() {
        CountDownTimer();
    }

    public void CountDownTimer() {
        if (_totalTime > 0) {
            _totalTime -= Time.deltaTime;
            DisplayTime(_totalTime);
        }
        else if (!_gameOver) {
            Debug.Log("Time has run out!");
            _totalTime = 0;

            _bookshelfHighscores.AddNewHighscore(_scoreManager.username, _scoreManager._score);

            _timerText.enabled = false;
            _gameOverText.enabled = true;

            _timerIsRunning = false;
            _tickingSound.Stop();

            _lastFloorPlate.GetComponent<Rigidbody>().isKinematic = false;
            _bokShelf.GetComponent<MeshCollider>().convex = true;
            _bokShelf.GetComponent<Rigidbody>().isKinematic = false;
            _bokShelf.GetComponent<Rigidbody>().useGravity = true;

            _gameOver = true;

            _scoreManager.StartCoroutine("GameOverCoroutine");
        }
    }

    private void DisplayTime(float timeToDisplay) {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (minutes == 0 && seconds == 20) {
            _timerText.color = Color.red;
            if (!_tickingSound.isPlaying) {

            _tickingSound.Play();
            }
        }
    }


    public IEnumerator FloorPanelOff() {
        for (int i = 0; i < _floorPlateList.Count; i--) {

            yield return new WaitForSeconds(10f);
            Debug.Log("Play Animation" + _floorPlateList[i].ToString());

            _floorPlateList[i].GetComponent<AudioSource>().Play();

            Quaternion startRotation = _floorPlateList[i].transform.rotation;
            Quaternion endRotation = Quaternion.Euler(15, 0, 15) * startRotation;

            float counter = 0f;
            while (counter < 1f) {
                counter += Time.deltaTime / 5f;
                _floorPlateList[i].transform.rotation = Quaternion.Lerp(startRotation, endRotation, counter);
                yield return null;
            }

            _floorPlateList[i].transform.rotation = endRotation;

            yield return new WaitForSeconds(0f);
            _floorPlateList[i].GetComponent<Rigidbody>().isKinematic = false;
            _floorPlateList[i].GetComponent<Rigidbody>().useGravity = true;
            _floorPlateList.RemoveAt(i);

            yield return StartCoroutine(FloorPanelOff());
        }
    }

    public void Shuffle<T>(IList<T> list) {
        System.Random random = new System.Random();
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}























