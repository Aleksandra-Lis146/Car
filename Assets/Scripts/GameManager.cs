using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text end;
    private float delay = 3f;
    public void EndGame()
    {
        end.text = "Victory!";
        end.gameObject.SetActive(true);
        Invoke("Restart", delay);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Update is called once per frame
    //public void GameOver()
    //{
    //    end.text = "Game over";
    //    end.gameObject.SetActive(true);
    //    Invoke("Restart", delay);
    //}


}
