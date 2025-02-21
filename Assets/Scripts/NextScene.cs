using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform sphere;
    [SerializeField] GameObject endMsg;
    [SerializeField] LayerMask mask;
    [SerializeField] AudioSource playerSrc;
    AudioSource src;
    
    bool playing = false;

    FunctionLib f;

    Scene scene;

    void Start()
    {
        src = GetComponent<AudioSource>();
        f = GetComponent<FunctionLib>();
        scene = SceneManager.GetActiveScene();
        endMsg.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(hitPlayer()){
            if(!playing){
                playerSrc.Stop();
                src.Play();
                playing = true;
            }
            RenderSettings.fogDensity = f.Zoom(RenderSettings.fogDensity, 1f, Time.deltaTime);
            Invoke("Cont", 10f);
            endMsg.SetActive(true);
        }   
    }

    bool hitPlayer(){
        return Physics.CheckSphere(sphere.position, 3f, mask);
    }

    void Cont(){
        Cursor.visible = true;
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
