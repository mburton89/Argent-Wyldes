using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatWayPoints : MonoBehaviour
{

    public Transform GetWaypoint(int waypoointIndex) //gets a waypoint wiht a specific index first waypoint is 0 second waypoint is 1 and etc
    {
        return transform.GetChild(waypoointIndex); // all the waypoints are children of the object so we use get child


    }

    public int GetNextWayPointIndex(int CurrentWayPointIndex) // gets the current index in the path and then adds 1 to it
    {

        int nextWayPoinntIndex = CurrentWayPointIndex + 1;
        if (nextWayPoinntIndex == transform.childCount) // checks if the next waypoint index is equal to the number of child objects
        {
            nextWayPoinntIndex = 0; //rests the index back to 0 if the number gets too high 
        }
        return nextWayPoinntIndex;
    }
}
