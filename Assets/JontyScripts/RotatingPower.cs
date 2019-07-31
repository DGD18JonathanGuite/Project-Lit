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

    public GameObject Indicator_1, Indicator_2, Indicator_3;

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
                CheckforIndicators();
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
            RotatorPower1 = 0;
            StartCoroutine(TurnOffallIndicators());
        }

    }

    void CheckforIndicators()
    {
        if (RotatorPower1 >= RotatorCharged / 3)
            Indicator_1.GetComponent<MeshRenderer>().material = RotatorOn;
        if (RotatorPower1 >= 2*RotatorCharged / 3)
            Indicator_2.GetComponent<MeshRenderer>().material = RotatorOn;
        if (RotatorPower1 >= RotatorCharged)
            Indicator_3.GetComponent<MeshRenderer>().material = RotatorOn;
    }

    
    IEnumerator TurnOffallIndicators()
    {
        yield return new WaitForSeconds(1f); 
        Indicator_1.GetComponent<MeshRenderer>().material = Indicator_2.GetComponent<MeshRenderer>().material = Indicator_3.GetComponent<MeshRenderer>().material = RotatorOff;
    }
}
