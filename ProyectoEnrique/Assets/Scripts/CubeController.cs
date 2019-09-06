using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    // Start is called before the first frame update

    private float valorx;
    private float valory;
    private float valorz;
    private Vector3 vectorInicial;
    private Vector3 vectorCambio;
    private Vector3 escala;
    private Vector3 rotacion;
    public Material material;

    public Slider sliderx;
    public Slider slidery;
    public Slider sliderz;
    void Start()
    {
        vectorInicial = transform.position;
        vectorCambio = transform.position;
        valorx = vectorCambio.x;
        valory = vectorCambio.y;
        valorz = vectorCambio.z;
        escala =transform.localScale;
        rotacion = transform.eulerAngles;  
        

        material=GetComponent<Renderer>().material;
        material.color = Color.black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotarCubo(){
        transform.Rotate(new Vector3(45,45,45));
    }

    public void EscalarCubo(float value){
        transform.localScale = new Vector3(value, value, value);
    }

    public void MoverXCubo(float value){
        transform.position = new Vector3(value, transform.position.y, transform.position.z);        
    }
     public void MoverYCubo(float value){
        transform.position = new Vector3(transform.position.x, value, transform.position.z);        
    }
     public void MoverZCubo(float value){
        transform.position = new Vector3(transform.position.x, transform.position.y, value);        
    }

    public void Reset(){
        transform.Rotate(rotacion);
        transform.localScale = (escala);
        transform.position = vectorInicial;
        sliderx.value = 0;
        slidery.value = 0;
        sliderz.value = 0;
    }


    public void CambiarColor(int opcion){
        Debug.Log("parametro:"+ opcion);
        switch (opcion)
        {
            case 0 : 
            Debug.Log("Opcion 1");
            material.color = Color.black;
            break;
            case 1 :
            Debug.Log("Opcion 2");
            material.color = Color.red;
            break;
            case 2 :
            Debug.Log("Opcion 3");
            material.color = Color.yellow;
            break;

        }
    }

    
}
