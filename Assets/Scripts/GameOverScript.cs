using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;
    [SerializeField] float fogDelta=0.001f;

    FunctionLib f;

    void Start()
    {
        f = GetComponent<FunctionLib>();
        RenderSettings.fog = true;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        RenderSettings.fogDensity = f.Zoom(RenderSettings.fogDensity, 0f, fogDelta);

        if(RenderSettings.fogDensity <= 0f){
            RenderSettings.fog = false;
        }
    }

}
