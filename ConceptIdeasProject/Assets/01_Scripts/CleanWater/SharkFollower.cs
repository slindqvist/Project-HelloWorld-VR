using UnityEngine;

public class SharkFollower : MonoBehaviour {
    [SerializeField] Transform _fishingRod;
    [SerializeField] float _chaseSpeed = 4f;
    [SerializeField] float _rotateSpeed = 2f;

    public Transform[] _waypoints;
    public float _moveSpeed;
    private int _currentIndex = 0;
    private float _waypointRadius = 1f;
    private bool _following = false;

    private float _swimUpDistance = 5f;
    private float _deepOffset = -5f;
    private Vector3 targetToFollow;

    void Update() {
        if (_fishingRod.transform.position.y <= 0) {
            Follow();
        }
        else {
            Swim();
        }
    }

    private void Follow() {
        if (Vector3.Distance(transform.position, _fishingRod.position) > _swimUpDistance) {
            targetToFollow = new Vector3(_fishingRod.position.x, _deepOffset, _fishingRod.position.z);
            Debug.Log("Attack rod");
        }
        else {
            targetToFollow = _fishingRod.position;
        }

        _following = true;
        transform.position += transform.forward * Time.deltaTime * _chaseSpeed;
        Vector3 rodDirection = targetToFollow - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(rodDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, Time.deltaTime * _rotateSpeed);
        Debug.Log("Chasing rod");
    }

    private void Swim() {
        if (_following) {
            _currentIndex = GetClosestWaypointIndex();
            _following = false;
        }

        if (Vector3.Distance(_waypoints[_currentIndex].transform.position, transform.position) < _waypointRadius) {
            _currentIndex++;
            if (_currentIndex >= _waypoints.Length) {
                _currentIndex = 0;
            }
        }

        Vector3 pointDirection = _waypoints[_currentIndex].transform.position - transform.position;
        Quaternion pointRotation = Quaternion.LookRotation(pointDirection);

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentIndex].transform.position, Time.deltaTime * _moveSpeed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, pointRotation, Time.deltaTime * _rotateSpeed);
    }

    private int GetClosestWaypointIndex() {
        Vector3 closestWaypoint = _waypoints[0].position;
        int closestIndex = 0;
        for (int i = 0; i < _waypoints.Length; i++) {
            if (Vector3.Distance(transform.position, _waypoints[i].position) < Vector3.Distance(transform.position, closestWaypoint)) {
                closestWaypoint = _waypoints[i].position;
                closestIndex = i;
            }
        }
        return closestIndex;
    }
}
