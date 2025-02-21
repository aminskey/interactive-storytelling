using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    [SerializeField] float jumpForce = 3f;
    //[SerializeField] Transform groundCheck;
    [SerializeField] Camera cam;
    [SerializeField] LayerMask mask;
    Animator player_anim;
    Rigidbody rb;
    Vector3 d;
    //PlayerHealthScript phs;

    CameraScript cm;


    private float startSpeed;
    private float jumpFactor = 1f;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cm = GetComponent<CameraScript>();

        player_anim = GetComponent<Animator>();
        //phs = GetComponent<PlayerHealthScript>();
        startSpeed = speed;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        d = transform.forward * vert + transform.right * horiz;

        rb.velocity = d * speed + new Vector3(0f, rb.velocity.y, 0f);
        if (Input.GetKey(KeyCode.LeftControl)){
            jumpFactor = 2f;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 70f, 20f*Time.deltaTime);
        } else {
            speed = startSpeed;
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, 60f, 20f*Time.deltaTime);
        }

        
        if(d != Vector3.zero){
            player_anim.SetBool("IsMoving", true);
            //Look();
        } else {
            player_anim.SetBool("IsMoving", false);
        }
        
    }

    void Look(){
        GameObject p = new GameObject();
        p.transform.position = transform.position + d;
        var rot = Quaternion.LookRotation(p.transform.position - transform.position, Vector3.up);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, 360f * Time.deltaTime);
    }

    void Jump(float factor){
        rb.velocity = new Vector3(rb.velocity.x, jumpForce*factor, rb.velocity.z);
    }
    /*
    bool isGrounded(){
        return Physics.CheckSphere(groundCheck.position, 0.2f, mask);
    }
    */
}
