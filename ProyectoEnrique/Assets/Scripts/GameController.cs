using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameController : MonoBehaviour
{
    
    public static GameController controller;

    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void Awake()
    {
    if(controller ==null)        {
        DontDestroyOnLoad(gameObject);
        controller=this;
    }else if(controller!=this){
        Destroy(gameObject);
    }
    }
    
}
