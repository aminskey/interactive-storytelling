using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollide : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] LayerMask msk;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other) {
        if(Physics.CheckBox(transform.position, transform.lossyScale/2f, transform.rotation, msk))
            anim.SetBool("hasCollided", true);
    }

    private void OnTriggerExit() {
        anim.SetBool("hasCollided", false);
    }
}
