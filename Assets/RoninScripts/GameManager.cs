using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject Over;
    public GameObject Win;
    bool GameHasEnded = false;

    public void WinGame()
    {
        if (GameObject.FindGameObjectsWithTag("Unlit").Length == 0)
        {
            Debug.Log("WINNER WINNER");
            Win.gameObject.SetActive(true);
            Invoke("NextLevel", 2f);
        }
    }
    public void EndGame()
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            Debug.Log("GAME OVER");
            Over.gameObject.SetActive(true);
            Invoke("Restart", 2f);
           
        }
        
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
