using UnityEngine;

public class WasteMover : MonoBehaviour
{
    public Transform _motor;
    public float _maxPower = 1f;
    public float _minPower = 0.5f;

    private float _power;

    protected Rigidbody _moverRigidbody;
    protected Quaternion _startRotation;

    private void Awake() {
        _moverRigidbody = GetComponent<Rigidbody>();
        _startRotation = _motor.localRotation;
    }

    private void Update() {
        _power = Random.Range(_minPower, _maxPower);
        Vector3 forceDirection = transform.forward;
        int steer = 1;

        _moverRigidbody.AddForceAtPosition(steer * transform.forward * _power, _motor.position);
    }
}
