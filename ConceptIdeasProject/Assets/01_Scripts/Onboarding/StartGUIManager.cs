using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartGUIManager : MonoBehaviour
{
    public TextMeshProUGUI _petBottle, _goalsCube, _ikeaBox;
    public float _fadeTime = 0.5f;

    private void Start() {
        _petBottle.canvasRenderer.SetAlpha(0.0f);
        _goalsCube.canvasRenderer.SetAlpha(0.0f);
        _ikeaBox.canvasRenderer.SetAlpha(0.0f);

        PETBottleFadeIn();
        GoalsCubeFadeIn();
        IKEABoxFadeIn();
    }

    public void PETBottleFadeIn() {
        _petBottle.CrossFadeAlpha(1, _fadeTime, false);
    }

    public void GoalsCubeFadeIn() {
        _goalsCube.CrossFadeAlpha(1, _fadeTime, false);
    }

    public void IKEABoxFadeIn() {
        _ikeaBox.CrossFadeAlpha(1, _fadeTime, false);
    }

    public void PETBottleFadeOut() {
        _petBottle.CrossFadeAlpha(0, _fadeTime, false);
    }

    public void GoalsCubeFadeOut() {
        _goalsCube.CrossFadeAlpha(0, _fadeTime, false);
    }

    public void IKEABoxFadeOut() {
        _ikeaBox.CrossFadeAlpha(0, _fadeTime, false);
    }
}
