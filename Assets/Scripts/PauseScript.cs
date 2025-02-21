using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pauseMenu;
    
    public static bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);   
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape)){
            if(isPaused){
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        Cursor.visible = true;
        pauseMenu.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame(){
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void GoToMainMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
