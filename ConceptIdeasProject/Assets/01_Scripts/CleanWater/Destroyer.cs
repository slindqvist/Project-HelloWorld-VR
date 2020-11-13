using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public float _lifetime = 60f;

    void Update()
    {
        if (_lifetime > 0) {
            _lifetime -= Time.deltaTime;
            if(_lifetime <= 0) {
                //Destroy object
                DestroyObject();
            }
        }
    }

    private void DestroyObject() {
        Destroy(this.gameObject);
    }
}
