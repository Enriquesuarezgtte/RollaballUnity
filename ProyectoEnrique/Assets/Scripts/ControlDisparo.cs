using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDisparo : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject Player;
    public float TiempoEntreDisparos =1f;
    public float rango =100f;

    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunLine;
    Light gunLight;
    float effectsDisplayTime =1.2f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
