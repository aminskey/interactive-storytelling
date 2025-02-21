using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectInField : MonoBehaviour
{
    [SerializeField] Animator spikeAnim;
    AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        if(other.tag != "Trap"){
            Invoke("kill", 0.75f);
            audioSource.Play();
        }
    }

    private void OnTriggerExit(Collider other) {
        spikeAnim.SetBool("CollPlayer", false);
    }

    void kill(){
        spikeAnim.SetBool("CollPlayer", true);
    }

}
