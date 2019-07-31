using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WordScreen : MonoBehaviour
{
    public Material WordOff, WordOn;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().material = WordOff;
    }
   
    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Unlit").Length == 0)
        {
            gameObject.GetComponent<MeshRenderer>().material = WordOn;
            Invoke("Next", 2f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }

    void NextLevel()
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        

       
    }
}
