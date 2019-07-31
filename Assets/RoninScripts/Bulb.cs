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
    public Material BulbOff, BulbOn, BulbBlow;
    public float ChargeSpeed=3;
    public bool Coroutineisrunning;

    //STUFF JONTY ADDED
    public ParticleSystem Explosion;
    public bool Gameover = false;
   
    

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
            

        if(BulbPower < 3 && CollisionOn == true && bulbScript.ButtonHeldDown == true)
        {

            if (Coroutineisrunning == false)
            StartCoroutine(Blink());
        }

        //JONTY ADDED THIS FOR THE WARNING BLINK
        if (BulbPower >= 3 && CollisionOn == true && bulbScript.ButtonHeldDown == true)
        {

            if (Coroutineisrunning == false)
                StartCoroutine(OverBlink());
        }


        if (BulbPower > OverCharged)
        {
            gameObject.GetComponent<MeshRenderer>().material = BulbBlow;

            if (Gameover == false)
                BlowUpBulb();      
            
            FindObjectOfType<GameManager>().EndGame();
        }
       

    }

    public void BlowUpBulb()
    {
            Gameover = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            Instantiate(Explosion, transform.position, Quaternion.identity);        
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
        Debug.Log("Blinking");
        Coroutineisrunning = true;
        while (bulbScript.ButtonHeldDown == true && CollisionOn==true)
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


    IEnumerator OverBlink()
    {
        Debug.Log("OverBlinking");

        Coroutineisrunning = true;
        while (bulbScript.ButtonHeldDown == true && CollisionOn == true)
        {
            gameObject.GetComponent<MeshRenderer>().material = BulbBlow;
            yield return new WaitForSeconds(.1f);
            //yield return new WaitForEndOfFrame();
            //yield return new WaitForEndOfFrame();
            //yield return new WaitForEndOfFrame();
            
            gameObject.GetComponent<MeshRenderer>().material = BulbOff;
            yield return new WaitForSeconds(.06f);

            //yield return new WaitForEndOfFrame();
            //yield return new WaitForEndOfFrame();
            //yield return new WaitForEndOfFrame();
            //yield return new WaitForEndOfFrame();

        }
        Coroutineisrunning = false;
        gameObject.GetComponent<MeshRenderer>().material = BulbOn;

    }

}
