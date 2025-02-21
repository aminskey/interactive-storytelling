using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform cam;
    [SerializeField] Transform playerObj;
    [SerializeField] float sensitivity = 2f;
    [SerializeField] float rotLim = 88f;

    Vector2 rot;
    void Start()
    {
        rot = Vector2.zero;
    }



    // Update is called once per frame
    void Update()
    {
        float m_x = (!PauseScript.isPaused)? Input.GetAxis("Mouse X") : 0f;
        float m_y = (!PauseScript.isPaused)? Input.GetAxis("Mouse Y") : 0f;

        rot.y += m_y * sensitivity;
        rot.x += m_x * sensitivity;

        rot.y = Mathf.Clamp(rot.y, -rotLim, rotLim);
        rot.x = Mathf.Clamp(rot.x, -rotLim, rotLim);

        if(!isInRange(rot.x, 0f, -10, 10f)){
            playerObj.Rotate(0f, rot.x*0.03f, 0f);
            //transform.Rotate(0f, -2*rot.x/rotLim, 0f);
            rot.x += 0.5f * ((rot.x > 0)? -1f : 1f);
        } 
        
        cam.localEulerAngles = Vector3.left * rot.y + Vector3.up;
        transform.localEulerAngles = Vector3.up * rot.x;
    
    }

    bool isInRange(float x, float off, float min, float max){
        return (x + off) < max && (x-off) > min;
    }
}
