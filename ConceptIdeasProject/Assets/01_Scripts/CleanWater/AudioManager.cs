using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioSource
        _dropFeedbackSound,
        _plasticRecycleSound,
        _metalRecycleSound,
        _electronicRecycleSound,
        _rodSound,
        _scoreSound,
        _timerSound,
        _sharkBiteSound, 
        _gameOverSound;

    public IEnumerator PlayPlasticDrop() {
        if (!_plasticRecycleSound.isPlaying) {
            _plasticRecycleSound.pitch = Random.Range(0.5f, 2f);
            _plasticRecycleSound.Play();
        }
        yield return new WaitForSeconds(0.5f);
        if (!_dropFeedbackSound.isPlaying) {
            _dropFeedbackSound.Play();
        }
        yield return null;
    }

    public IEnumerator PlayMetalDrop() {
        if (!_metalRecycleSound.isPlaying) {
            _metalRecycleSound.pitch = Random.Range(0.5f, 2f);
            _metalRecycleSound.Play();
        }
        yield return new WaitForSeconds(0.5f);
        if (!_dropFeedbackSound.isPlaying) {
            _dropFeedbackSound.Play();
        }
        yield return null;
    }

    public IEnumerator PlayElectronicDrop() {
        if (!_electronicRecycleSound.isPlaying) {
            _electronicRecycleSound.pitch = Random.Range(0.5f, 2f);
            _electronicRecycleSound.Play();
        }
        yield return new WaitForSeconds(0.5f);
        if (!_dropFeedbackSound.isPlaying) {
            _dropFeedbackSound.Play();
        }
        yield return null;
    }

    public void PlayRodSplash() {
        if (!_rodSound.isPlaying) {
            _rodSound.Play();
        }
    }

    public void PlayScorePoint() {
        if (!_scoreSound.isPlaying) {
            _scoreSound.Play();
        }
    }

    public void PlayTimerCountdown() {
        if (!_timerSound.isPlaying) {
            _timerSound.Play();
        }
    }

    public void StopTimerCountdown() {
            _timerSound.Stop();
    }

    public void PlaySharkAttack() {
        if (!_sharkBiteSound.isPlaying) {
            _sharkBiteSound.Play();
        }
    }

    public void PlayGameOver() {
        if (!_gameOverSound.isPlaying) {
            _gameOverSound.Play();
        }
    }
}
