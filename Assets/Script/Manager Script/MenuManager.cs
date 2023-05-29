using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject player;

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void GameStart()
    {
        SceneManager.LoadScene("SampleScene");
    }

    
    public void QuitGame()
    {
        Application.Quit();
    }
    
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void Restart()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
