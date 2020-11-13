using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSceneAnimControl : MonoBehaviour
{
    public AudioSource _icePlatform01,
                       _icePlatform02,
                       _icePlatform03,
                       _icePlatform04;

    private Animator _icePlatformAnimator;

    void Start()
    {
        _icePlatformAnimator = GetComponent<Animator>();
        _icePlatformAnimator.SetBool("HasWon", false);
    }

    [ContextMenu("YouHaveWon")]
    public void PlayWinScene() {
        _icePlatformAnimator.SetBool("HasWon", true);
        if(!_icePlatform01.isPlaying && !_icePlatform02.isPlaying && !_icePlatform03.isPlaying && !_icePlatform04.isPlaying) {
            _icePlatform01.Play();
            _icePlatform02.Play();
            _icePlatform03.Play();
            _icePlatform04.Play();
        }
    }
}
