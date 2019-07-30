using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPower : MonoBehaviour
{
    public Power RotatorScript;
    public float RotatorPower1;
    public float RotatorCharged=0.8f;
    public bool CollisionOn;
    public Material RotatorOff, RotatorOn;
    public float ChargeSpeed = 3;

    public GameObject Charge;

    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<MeshRenderer>().material = RotatorOff;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (CollisionOn == true)
        {
            Debug.Log("Shouldbecharging");
            if (RotatorScript.ButtonHeldDown == true)
            {
                RotatorPower1 += Time.deltaTime * ChargeSpeed;
            }
        }

        if (RotatorPower1 > RotatorCharged)
        {
            Charge.GetComponent<ChargeInputManager>().RequestRotation();
            RotatorPower1 = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "spark")
        {
            CollisionOn = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "spark")
        {
            //Debug.Log("ON");
            CollisionOn = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "spark")
        {
            //Debug.Log("OFF");
            CollisionOn = false;
        }

    }
}
