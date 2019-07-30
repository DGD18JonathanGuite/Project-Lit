using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeRotationbyPanel : MonoBehaviour
{
    

    public void RotateChargewithPanel(Transform setparent)
    {
        gameObject.GetComponent<ChargeMovement>().ChargecanMove = false;
        gameObject.transform.SetParent(setparent);
    }

    public void FreeChargefromPanel()
    {
        gameObject.GetComponent<ChargeMovement>().ChargecanMove = true;
        gameObject.transform.parent = null;

        gameObject.GetComponent<ChargeMovement>().ReestablishCurrentCourse();
    }
}
