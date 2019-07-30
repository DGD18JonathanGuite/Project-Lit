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
    public bool ChargecanMove = true, DirectionisChanging = false;

    public void Start()
    {
        WayPointSet = GameObject.Find("WayPointsSetOne");
        ChargecanMove = true;
        target = WayPointSet.GetComponent<WaypointSystem>().WayPoints[WayPointID];
        direction = (target.position - gameObject.transform.position);
    }

    private void FixedUpdate()
    {        
        if(ChargecanMove == true)
        transform.Translate(direction.normalized * speed);
        if (Vector3.Distance(target.position, gameObject.transform.position) <= 0.1f && DirectionisChanging == false)
            ChangeDirection();
    }

    public void ChangeDirection()
    {
        DirectionisChanging = true;
        WayPointID += 1;
        if ((WayPointSet.GetComponent<WaypointSystem>().WayPoints.Length) == (WayPointID))
            WayPointID = 0;
        
            
            target = WayPointSet.GetComponent<WaypointSystem>().WayPoints[WayPointID];
            direction = (target.position - gameObject.transform.position);
        
        DirectionisChanging = false;
    }

    public void ReestablishCurrentCourse()
    {
        transform.rotation = Quaternion.identity; // This is necessary to have the Charge shot where it's supposed to be.
        target = WayPointSet.GetComponent<WaypointSystem>().WayPoints[WayPointID];
        
        Debug.Log("Target Position is " + target.position + " and GameObject position is " + gameObject.transform.position);
        direction = (target.position - gameObject.transform.position);
        
    }
}
