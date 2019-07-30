using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeInputManager : MonoBehaviour
{
    private void FixedUpdate()
    {
        //if (Input.GetKeyDown(KeyCode.W) && gameObject.GetComponent<ChargeMovement>().WayPointID == 0 && GameObject.Find("RotatingPanel").GetComponent<PanelTestRotation>().Rotating == false)
        //{
        //    gameObject.GetComponent<ChargeChangeWayPoints>().PickWayPointSet();
        //    GameObject.Find("RotatingPanel").GetComponent<PanelTestRotation>().RotatePanel();
        //}
    }

    public void RequestRotation()
    {
        if (gameObject.GetComponent<ChargeMovement>().WayPointID == 0 && GameObject.Find("RotatingPanel").GetComponent<PanelTestRotation>().Rotating == false)
        {
            gameObject.GetComponent<ChargeChangeWayPoints>().PickWayPointSet();
            GameObject.Find("RotatingPanel").GetComponent<PanelTestRotation>().RotatePanel();
        }
    }
}
