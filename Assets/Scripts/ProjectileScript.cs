using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float speed = 2f;
    bool isMoving = true;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Trap";
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving) {
            rb.velocity = transform.forward * speed;
        }
    }

    private void OnCollisionEnter(Collision other) {
        rb.velocity = Vector3.zero;
        isMoving = false;
        Destroy(gameObject);
    }

}
