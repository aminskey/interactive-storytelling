using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehaviour : MonoBehaviour
{
    public GameObject arrow;
    public Transform neck;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateObj(){
        Instantiate(arrow, neck.position + neck.forward * 2f, neck.rotation, null);
    }
}
