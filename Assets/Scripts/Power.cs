using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    public float power;
    float maxPower = 10;
    float ChargeSpeed=3;
    public bool ButtonHeldDown;
   
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            power += Time.deltaTime * ChargeSpeed;
            ButtonHeldDown = true;
            
        }
        else
        {
            ButtonHeldDown = false;
            power = 0;  
        }
    }

   
}

