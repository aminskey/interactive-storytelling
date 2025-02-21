using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject FPS_Cam;
    [SerializeField] GameObject TPS_Cam;
    
    // Start is called before the first frame update
    void Start()
    {
        FPS_Cam.SetActive(true);
        TPS_Cam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.F5)){
            FPS_Cam.SetActive(!FPS_Cam.activeSelf);
            TPS_Cam.SetActive(!TPS_Cam.activeSelf);
        }
    }
}
