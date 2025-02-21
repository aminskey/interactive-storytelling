using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float playerHealth;
    [SerializeField] GameObject img;
    [SerializeField] Slider hb;
    [SerializeField] LayerMask msk;
    [SerializeField] AudioSource hurtSnd;

    Rigidbody rb;
    FunctionLib f;
    float maxHealth = 12f;
    public bool dead;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        f = GetComponent<FunctionLib>();
        dead = false;
        playerHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hb.value = playerHealth/maxHealth;
        if(playerHealth <= 0f){
            RenderSettings.fogDensity = Mathf.Lerp(RenderSettings.fogDensity, 1f, 0.25f*Time.deltaTime);
            if(!dead){
                Invoke("gameOver", 4f);
                dead = true;
            }
            rb.velocity = Vector3.zero;            
        }
        if(img.activeSelf){
            Invoke("activeFalse", 0.125f);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Trap"){
            img.SetActive(true);
            playerHealth -= 1f;
            hurtSnd.Play();
            if(playerHealth <= 0f){
                rb.velocity = Vector3.zero;
            } else {
                if(other.gameObject.layer == msk) rb.velocity = new Vector3(0f, 10f, 0f);
            }
        }
    }
    
    void activeFalse(){
        img.SetActive(false);
    }

    void gameOver(){
        SceneManager.LoadScene("GameOver");
    }
}
