using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public Power bulbScript;
    public float BulbPower;
    public float newBulbPower;
    public bool CollisionOn;
    // Start is called before the first frame update
    void Start()
    {
        newBulbPower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionOn==true)
        {
          
            if (bulbScript.ButtonHeldDown == true)
            {

                BulbPower += bulbScript.power;
            }
        }

        if (CollisionOn == false)
        {
            newBulbPower = BulbPower;
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionOn = true;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("ON");
        CollisionOn = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OFF");
        CollisionOn = false;
    }

    
}
