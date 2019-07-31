using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedTapeGlow : MonoBehaviour
{
    public Material Red, RedGlow;

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("On Trigger with "+ other.name);

        if (other.gameObject.tag == "spark" && other.gameObject.GetComponent<Power>().ButtonHeldDown == true)
        {

            gameObject.GetComponent<MeshRenderer>().material = RedGlow;
        }

        if (other.gameObject.tag == "spark" && other.gameObject.GetComponent<Power>().ButtonHeldDown == false)
        {
            gameObject.GetComponent<MeshRenderer>().material = Red;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "spark")
            gameObject.GetComponent<MeshRenderer>().material = Red;
    }
}
