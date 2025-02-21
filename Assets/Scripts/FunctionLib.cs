using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FunctionLib : MonoBehaviour
{
    [SerializeField] AudioSource src;

    public float Zoom(float start, float end, float step){
        start = start + step * ((start > end)? -1f : 1f);
        return start;
    }

    public void Quit(){
        Invoke("Quit1", 0.125f);
    }

    void Quit1(){
        Application.Quit();
    }

    public void PlaySource(){
        src.Play();
    }

    void loadLev1(){
        SceneManager.LoadScene("Level-1");
    }

    void StartGame(){
        Invoke("loadLev1", 0.125f);
    }

    public void StartMenu(){
        Invoke("menuLoad", 0.125f);
    }

    public void menuLoad(){
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
