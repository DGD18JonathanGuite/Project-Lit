using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeChangeWayPoints : MonoBehaviour
{
    public GameObject WayPointSet1, WayPointSet2;

    public void PickWayPointSet()
    {
        Debug.Log("PickingWayPoint");
        if(gameObject.GetComponent<ChargeMovement>().WayPointSet == WayPointSet1)
        {
            Debug.Log("Waypoint set is WaypointSet1 and changing to WaypointSet2");
            gameObject.GetComponent<ChargeMovement>().WayPointSet = WayPointSet2;
            //gameObject.GetComponent<Transform>().Translate(new Vector3(0, (gameObject.GetComponent<ChargeMovement>().WayPointSet.transform.position.y + gameObject.GetComponent<Transform>().position.y)/2, 0));
        }
        else
        {
            Debug.Log("Waypoint set is WaypointSet2 and changing to WaypointSet1");
            gameObject.GetComponent<ChargeMovement>().WayPointSet = WayPointSet1;
            //gameObject.GetComponent<Transform>().Translate(new Vector3(0, (gameObject.GetComponent<ChargeMovement>().WayPointSet.transform.position.y - gameObject.GetComponent<Transform>().position.y)/2, 0));
        }
        ChargeReset();
    }

    public void ChargeReset()
    {
        gameObject.GetComponent<ChargeMovement>().WayPointID--;
        gameObject.GetComponent<ChargeMovement>().ChangeDirection();
    }
}
