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
        if (controller == null)
        {
            DontDestroyOnLoad(gameObject);
            controller = this;
        }
        else if (controller != this)
        {
            Destroy(gameObject);
        }
    }
    public void Guardar()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/persistencia.dat");
        Debug.Log(Application.persistentDataPath);
        DatosJuego datos = new DatosJuego();
        datos.posx = GameObject.Find("ThirdPersonController").transform.position.x;
        datos.posy = GameObject.Find("ThirdPersonController").transform.position.y;
        datos.posz = GameObject.Find("ThirdPersonController").transform.position.z;

        bf.Serialize(file, datos);
        file.Close();

    }

    public void Cargar()
    {
        if (File.Exists(Application.persistentDataPath + "/persistencia.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =  File.Open(Application.persistentDataPath + "/persistencia.dat", FileMode.Open);
            DatosJuego datos = (DatosJuego)bf.Deserialize(file);
            file.Close();
            Vector3 position = new Vector3(datos.posx, datos.posy, datos.posz);
            GameObject.Find("ThirdPersonController").transform.position =position;
        }
    }
}


[Serializable]
public class DatosJuego
{
    public float posx;
    public float posy;
    public float posz;

}
