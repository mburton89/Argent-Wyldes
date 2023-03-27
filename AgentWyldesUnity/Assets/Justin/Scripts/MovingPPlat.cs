using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPPlat : MonoBehaviour
{


    [SerializeField]
    private WaypointPath _waypointPath;
    [SerializeField]
    private float _speed; // speed of the platforn
    
    private int _targetWaypointIndex; // index of the waypoint that the waypoint is moving towards

    private Transform _previousWayPoint;
    private Transform _targetWayPoint;

    private float _timeToWayPoint;
    private float _elapsedTime;   
    
    
    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime; 
        float elapsedPercentage = _elapsedTime / _timeToWayPoint; //how much of ground the boat has covered
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage); //slows down when approaching the limits 0 and 1
        transform.position = Vector3.Lerp(_previousWayPoint.position, _targetWayPoint.position, elapsedPercentage); // moves to the next waypoint according the percentage of time passed
        transform.rotation = Quaternion.Lerp(_previousWayPoint.rotation, _targetWayPoint.rotation, elapsedPercentage);
        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }



    private void TargetNextWaypoint()
    {

        _previousWayPoint = _waypointPath.GetWaypoint(_targetWaypointIndex); // sets previous waypoint to the current waypoint target index
        _targetWaypointIndex = _waypointPath.GetNextWayPointIndex(_targetWaypointIndex); //sets target index to the next index 
        _targetWayPoint = _waypointPath.GetWaypoint(_targetWaypointIndex); //sets target waypoint to the waypoint at the target index

        _elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(_previousWayPoint.position, _targetWayPoint.position); 
        _timeToWayPoint = distanceToWaypoint / _speed; //calcs the time to get to the next waypoint

    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }


}
