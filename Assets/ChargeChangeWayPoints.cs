using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeChangeWayPoints : ResetChargeMovement
{
    public GameObject WayPointSet1, WayPointSet2;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Charge.GetComponent<ChargeMovement>().WayPointID == 1)
            PickWayPointSet();
    }

    void PickWayPointSet()
    {
        if(Charge.GetComponent<ChargeMovement>().WayPointSet == WayPointSet1)
        {
            Charge.GetComponent<ChargeMovement>().WayPointSet = WayPointSet2;
            Charge.GetComponent<Transform>().Translate(new Vector3(0, (Charge.GetComponent<ChargeMovement>().WayPointSet.transform.position.y + Charge.GetComponent<Transform>().position.y)/2, 0));
        }
        else
        {
            Charge.GetComponent<ChargeMovement>().WayPointSet = WayPointSet1;
            Charge.GetComponent<Transform>().Translate(new Vector3(0, (Charge.GetComponent<ChargeMovement>().WayPointSet.transform.position.y - Charge.GetComponent<Transform>().position.y)/2, 0));
        }
        ChargeReset();
    }
}
