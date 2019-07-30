using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
   
    public bool ButtonHeldDown;
    public Material SparksOff, SparksOn;

    private void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = SparksOff;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            
            ButtonHeldDown = true;
            gameObject.GetComponent<MeshRenderer>().material = SparksOn;

        }
        else
        {
            ButtonHeldDown = false;
            gameObject.GetComponent<MeshRenderer>().material = SparksOff;

        }
    }

   
}

