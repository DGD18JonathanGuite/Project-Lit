using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeInputManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameObject.GetComponent<ChargeMovement>().WayPointID == 1)
            gameObject.GetComponent<ChargeChangeWayPoints>().PickWayPointSet();
    }
}
