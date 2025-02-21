using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadScript : MonoBehaviour
{
    [SerializeField] Transform cam;
    [SerializeField] Transform ent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var rot = transform.position - cam.position;
        transform.rotation = Quaternion.LookRotation(rot);
        transform.position = ent.position + transform.forward*0.0625f;
    }
}
