using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using Valve.VR;
using Valve.VR.Extras;

public class SceneHandler : MonoBehaviour {
    public SteamVR_Input_Sources _hand;

    public SteamVR_LaserPointer _laserPointer;
    public GameObject _rensaVattnetPlaceHolder,
                      _bokhyllanPlaceHolder;
    public AudioSource _buttonBokhyllan,
                       _buttonRensaVattnet;

    private void Awake() {
        _laserPointer.PointerIn += PointerInside;
        _laserPointer.PointerOut += PointerOutside;
        _laserPointer.PointerClick += PointerClick;

        _laserPointer.active = false;
    }

    public void PointerClick(object sender, PointerEventArgs e) {
        if (e.target.name == "RensaVattnet") {
            _rensaVattnetPlaceHolder.SetActive(true);
            if (!_buttonRensaVattnet.isPlaying) {
                _buttonRensaVattnet.Play();
            }
            Debug.Log("Rensa vattnet was clicked");
        }
        else if (e.target.name == "Bokhyllan") {
            _bokhyllanPlaceHolder.SetActive(true);
            if (!_buttonBokhyllan.isPlaying) {
                _buttonBokhyllan.Play();
            }
            Debug.Log("Bokhyllan was clicked");
        }
    }

    public void PointerInside(object sender, PointerEventArgs e) {
        if (e.target.name == "RensaVattnet") {
            Debug.Log("Rensa vattnet was entered");
        }
        else if (e.target.name == "Bokhyllan") {
            Debug.Log("Bokhyllan was entered");
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e) {
        if (e.target.name == "RensaVattnet") {
            Debug.Log("Rensa vattnet was exited");
        }
        else if (e.target.name == "Bokhyllan") {
            Debug.Log("Bokhyllan was exited");
        }
    }

    protected void Update() {
        if (SteamVR_Actions.default_GrabGrip.GetLastStateDown(_hand)) {
            _laserPointer.active = true;
            Debug.Log("Grip was touched");
        }
    }
}
