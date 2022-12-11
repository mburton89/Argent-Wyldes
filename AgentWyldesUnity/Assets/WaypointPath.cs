using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
   
    public Transform GetWaypoint(int waypoointIndex)
    {
        return transform.GetChild(waypoointIndex);


    }
    
    public int GetNextWayPointIndex(int CurrentWayPointIndex)
    {

        int nextWayPoinntIndex = CurrentWayPointIndex + 1;
        if (nextWayPoinntIndex == transform.childCount)
        {
            nextWayPoinntIndex = 0;
        }
        return nextWayPoinntIndex;
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
