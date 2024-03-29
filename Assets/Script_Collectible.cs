using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script_Collectible : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints; // start the waypoints array
    [SerializeField] private float[] _speed; // speeds of the target to go to the next waypoint[same index]

    private float _checkDistance = 0.1f; // current distance waypoint-cible
    Vector3 startPosition = Vector3.zero;

    private Transform _targetWaypoint; // which waypoint to move to
    private int _currentWaypointIndex = 0; // to start the index of the waypoint array


    // Start is called before the first frame update
    void Start()
    {
        _targetWaypoint = _waypoints[0];
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // movement
        transform.position = Vector2.MoveTowards(transform.position, _targetWaypoint.position, _speed[_currentWaypointIndex] * Time.deltaTime); // transform position to move to the target waypoint at _speed speed (mod deltaTime)
        if (Vector2.Distance(transform.position, _targetWaypoint.position) < _checkDistance)
        {
            // if the position hasn't reached the target waypoint yet
            _targetWaypoint = GetNextWaypoint();
        }
    }

    private Transform GetNextWaypoint()
    {
        _currentWaypointIndex++; // inc the index
        if (_currentWaypointIndex >= _waypoints.Length)
        {
            // if the index is larger than the last index in the waypoint array
            _currentWaypointIndex = 0;
        }
        return _waypoints[_currentWaypointIndex];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // � debug lol
        Debug.Log("Destroy Collision");
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
