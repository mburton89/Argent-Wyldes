using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPPlat : MonoBehaviour
{


    [SerializeField]
    private WaypointPath _waypointPath;
    [SerializeField]
    private float _speed;
    
    private int _targetWaypintIndex;

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
        float elapsedPercentage = _elapsedTime / _timeToWayPoint;
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        transform.position = Vector3.Lerp(_previousWayPoint.position, _targetWayPoint.position, elapsedPercentage);
        transform.rotation = Quaternion.Lerp(_previousWayPoint.rotation, _targetWayPoint.rotation, elapsedPercentage);
        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }



    private void TargetNextWaypoint()
    {

        _previousWayPoint = _waypointPath.GetWaypoint(_targetWaypintIndex);
        _targetWaypintIndex = _waypointPath.GetNextWayPointIndex(_targetWaypintIndex);
        _targetWayPoint = _waypointPath.GetWaypoint(_targetWaypintIndex);

        _elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(_previousWayPoint.position, _targetWayPoint.position);
        _timeToWayPoint = distanceToWaypoint / _speed;

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
