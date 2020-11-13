using System.Collections;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject _icePlatform;
    public float _scaleDownTime = 360f;

    private bool _isScaling = false;

    private void Start() {
        StartCoroutine(ScaleOverTime(_icePlatform.transform, new Vector3(45, 25, 45), _scaleDownTime));
    }

    private IEnumerator ScaleOverTime(Transform obectToScale, Vector3 toScale, float duration) {
        if (_isScaling) {
            yield break;
        }
        _isScaling = true;

        float counter = 0;

        Vector3 startScaleSize = obectToScale.localScale;

        while (counter < duration) {
            counter += Time.deltaTime;
            obectToScale.localScale = Vector3.Lerp(startScaleSize, toScale, counter / duration);
            yield return null;
        }

        _isScaling = false;
    }
}
