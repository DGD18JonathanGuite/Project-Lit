using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulb : MonoBehaviour
{
    public Power bulbScript;
    public float BulbPower;
    public float OverCharged=6;
    public float BulbCharged=3;
    public float newBulbPower;
    public bool CollisionOn;
    public Material BulbOff, BulbOn;
    public float ChargeSpeed=3;
    public bool Coroutineisrunning;
    

   
    

    // Start is called before the first frame update
    void Start()
    {
        newBulbPower = 0;
        gameObject.GetComponent<MeshRenderer>().material = BulbOff;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CollisionOn==true)
        {
          
            if (bulbScript.ButtonHeldDown == true)
            {

                BulbPower += Time.deltaTime * ChargeSpeed;
            }
        }

        if (CollisionOn == false)
        {
            newBulbPower = BulbPower;
            
        }

        if(BulbPower > BulbCharged)
        {
            gameObject.GetComponent<MeshRenderer>().material = BulbOn;
            gameObject.tag = "Untagged";
            FindObjectOfType<GameManager>().WinGame();
        }
            

        if(BulbPower<3 && CollisionOn == true && bulbScript.ButtonHeldDown == true)
        {

            if (Coroutineisrunning == false)
            StartCoroutine(Blink());
        }

        if(BulbPower > OverCharged)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
       

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "spark")
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

    IEnumerator Blink()
    {
        //for (int n = 0; n < 10; n++)
        //{
        //    gameObject.GetComponent<MeshRenderer>().material = BulbOn;
        //    yield return new WaitForSeconds(0.1f);
        //    gameObject.GetComponent<MeshRenderer>().material = BulbOff;
        //    yield return new WaitForSeconds(0.1f);

        //}
        Coroutineisrunning = true;
        while (bulbScript.ButtonHeldDown == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = BulbOn;
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            gameObject.GetComponent<MeshRenderer>().material = BulbOff;
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
            yield return new WaitForEndOfFrame();
        }
        Coroutineisrunning = false;
    }
    
}
