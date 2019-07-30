using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeMovement : MonoBehaviour
{
    public float speed;
    public int WayPointID = 0;
    public Transform target;
    Vector3 direction;
    public GameObject WayPointSet;

    public void Start()
    {
        //WayPointID = 0;
        target = WayPointSet.GetComponent<WaypointSystem>().WayPoints[WayPointID];
        direction = (target.position - gameObject.transform.position);
    }

    private void FixedUpdate()
    {        
        transform.Translate(direction.normalized * speed);
        if (Vector3.Distance(target.position, gameObject.transform.position) <= 0.1f)
            ChangeDirection();
    }

    public void ChangeDirection()
    {        
        if ((WayPointSet.GetComponent<WaypointSystem>().WayPoints.Length) == WayPointID)
            WayPointID = 0;
        else
        {
            target = WayPointSet.GetComponent<WaypointSystem>().WayPoints[WayPointID++];
            direction = (target.position - gameObject.transform.position);
        }            
    }
}
