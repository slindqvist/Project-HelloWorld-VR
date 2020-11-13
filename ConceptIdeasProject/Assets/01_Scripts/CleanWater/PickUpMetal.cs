using UnityEngine;

public class PickUpMetal : MonoBehaviour
{
    MetalWasteManager _metalWasteManager;
    ScoreManager _scoreManager;
    AudioManager _audioManager;

    public int _recycleValue = 2;

    private void Start() {
        _metalWasteManager = FindObjectOfType<MetalWasteManager>();
        _scoreManager = FindObjectOfType<ScoreManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("MetalBin")) {
            _audioManager.StartCoroutine("PlayMetalDrop");

            _metalWasteManager._metalCount = _metalWasteManager._metalCount - 1;
            _scoreManager.AddPointsToScoreboard(_recycleValue);

            _metalWasteManager.SetMetalCountText();
            Destroy(gameObject);
            Debug.Log("Metal recycled");
        }
    }
}
