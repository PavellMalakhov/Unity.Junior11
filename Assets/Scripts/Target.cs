using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoint;
    [SerializeField] private float _speed;
    [SerializeField] private int _currentWaypoint = 0;

    private void Update()
    {
        if (transform.position == _waypoint[_currentWaypoint].position)
        {
            _currentWaypoint = (_currentWaypoint + 1) % _waypoint.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoint[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}
