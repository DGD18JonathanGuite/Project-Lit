using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorPower : MonoBehaviour
{
    public Power RotatorScript;
    public float RotatorPower1;
    public float RotatorCharged=3;
    public bool CollisionOn;
    public Material RotatorOff, RotatorOn;
    public float ChargeSpeed = 3;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = RotatorOff;
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionOn == true)
        {

            if (RotatorScript.ButtonHeldDown == true)
            {

                RotatorPower1 += Time.deltaTime * ChargeSpeed;
            }
        }

        if (RotatorPower1 > RotatorCharged)
            Debug.Log("TurnRotator");

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
            Debug.Log("ON");
            CollisionOn = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "spark")
        {
            Debug.Log("OFF");
            CollisionOn = false;
        }

    }
}
