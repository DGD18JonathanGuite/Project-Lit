using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetChargeMovement : MonoBehaviour
{
    public GameObject Charge;

    public void ChargeReset()
    {
        Charge.GetComponent<ChargeMovement>().WayPointID--;
        Charge.GetComponent<ChargeMovement>().ChangeDirection();
    }
}
