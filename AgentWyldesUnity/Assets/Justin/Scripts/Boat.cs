using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class Boat : InteractableObject
{
    [SerializeField]
    private bool CanMove;
    [SerializeField]
    private bool isMoving;
    [SerializeField]
    private BoatWayPoints _boatWayPointPath;
    [SerializeField]
    private float _speed; // speed of the platforn
    [SerializeField]
    private Transform playerTeleportPoint;
    [SerializeField]
    GameObject rowboat;
    private int _targetWayPointIndex; // index of the waypoint that the waypoint is moving towards

    private Transform _previousWayPoint;
    private Transform _targetWayPoint;
    public Transform teleportForDock1;
    public Transform teleportForDock2;
    public Transform teleportToThis;
    public float elapsedPercentage;
    private float _timeToWayPoint;
    private float _elapsedTime;
    private void Start()
    {
        TargetNextWaypoint();
    }
    protected override void OnTriggerEnter(Collider other)
    {
        ////if (isMoving)
        //{
        //    interactableCanvas.SetActive(false);

        //}
        base.OnTriggerEnter(other);

    }

    protected override void OnTriggerStay(Collider other)
    {
        //if (isMoving)
        //{
        //    interactableCanvas.SetActive(false);

        //}
        base.OnTriggerStay(other);
    }

    protected override void OnTriggerExit(Collider other)
    {
        //if (isMoving)
        //{
        //    return;
        //}
        base.OnTriggerExit(other);

    }

    protected override void Interact(Movement player)
    {
        base.Interact(player);
        //if (!CanMove)
        //{
        //    return;
        //}
       if (!isMoving)
        {
            StartBoatMovemenet();


        }



    }
    private void FixedUpdate()
    {
        
        Vector3 Playermovement;
        //SetMoving(!isMoving);
        if (isMoving)  
        {
            interactableCanvas.SetActive(false);
            _elapsedTime += Time.deltaTime;
            elapsedPercentage = _elapsedTime / _timeToWayPoint; //how much of ground the boat has covered
            elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage); //slows down when approaching the limits 0 and 1
            transform.position = Vector3.Lerp(_previousWayPoint.position, _targetWayPoint.position, elapsedPercentage); // moves to the next waypoint according the percentage of time passed
            movement.transform.SetParent(rowboat.transform);
            //movement.transform.position = playerTeleportPoint.transform.position;
            //movement.transform.position.y = 0;
            Playermovement = playerTeleportPoint.transform.position;
            //Playermovement.y += 0.5f;
            movement.transform.position = Playermovement;
            movement.controller.enabled= false;
            movement.animator.SetBool("isSitting", true);
            movement.mouseLook.xClamp = 0;

            if (elapsedPercentage >= 1)
            {
                float dist1 = Vector3.Distance(movement.transform.position, teleportForDock1.position);
                float dist2 = Vector3.Distance(movement.transform.position, teleportForDock2.position);
                 if (dist1 < dist2) 
                {

                    teleportToThis = teleportForDock1;
                
                
                }
                else
                {
                    teleportToThis = teleportForDock2;
                }
                TargetNextWaypoint();
                isMoving= false;
                movement.transform.SetParent(null);
                movement.animator.SetBool("isSitting", false);
                movement.transform.position = teleportToThis.position;
                movement.controller.enabled= true;
                movement.mouseLook.xClamp = 70;



            }

            //}
        }
        //else
        //{
        //}
    }
    private void StartBoatMovemenet()
    {
        isMoving = true;
       
        //SetMoving(!isMoving);
        //movement.transform.position = playerTeleportPoint.transform.position;
        //_elapsedTime += Time.deltaTime;
        //float elapsedPercentage = _elapsedTime / _timeToWayPoint; //how much of ground the boat has covered
        //elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage); //slows down when approaching the limits 0 and 1
        //transform.position = Vector3.Lerp(_previousWayPoint.position, _targetWayPoint.position, elapsedPercentage); // moves to the next waypoint according the percentage of time passed
        ////transform.rotation = Quaternion.Lerp(_previousWayPoint.rotation, _targetWayPoint.rotation, elapsedPercentage);
        ////if (elapsedPercentage >= 1)
        ////{
        ////    TargetNextWaypoint();

        ////}
    }

    private void TargetNextWaypoint()
    {
        
        _previousWayPoint = _boatWayPointPath.GetWaypoint(_targetWayPointIndex); // sets previous waypoint to the current waypoint target index
        _targetWayPointIndex = _boatWayPointPath.GetNextWayPointIndex(_targetWayPointIndex); //sets target index to the next index 
        _targetWayPoint = _boatWayPointPath.GetWaypoint(_targetWayPointIndex); //sets target waypoint to the waypoint at the target index

        _elapsedTime = 0;
        float distanceToWaypoint = Vector3.Distance(_previousWayPoint.position, _targetWayPoint.position);
        _timeToWayPoint = distanceToWaypoint / _speed; //calcs the time to get to the next waypoint
        //CanMove = true;

    }
    private void SetMoving(bool isMoving)
    {

        this.isMoving = isMoving;
        movement.controller.enabled = !isMoving;
        //if (!isMoving)
        //{
        //    movement.mouseLook.mo
        //}
    }

}
