﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int contador;
    private AudioSource audioRecoleccion;
    public Transform particulas;
    public Text textUI;
    public Text Award;
    private ParticleSystem systemaParticulas;
    private Vector3 position;
    public float speed;
    public GameObject CuboMovible;
    public GameObject Cubo10Segundos;
    public GameObject Cubo5y3segundos;
    private int contadorColor;
    private bool recolected;
    private Material material;

    // Start is called before the first frame update
    void Start()
    {
        contadorColor=1;
        rb = GetComponent<Rigidbody>();
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();
        contador =0;
        Award.text ="";
        recolected=false;
        material=Cubo5y3segundos.GetComponent<Renderer>().material;
        audioRecoleccion=GetComponent<AudioSource>();
        textUI.text = "Contador: "+contador.ToString();
        StartCoroutine("Movimiento");
      //  StartCoroutine("DesaparecerCubo");
        //StartCoroutine("DesaparecerCubo5y3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");        
        Vector3 movimiento = new Vector3(
            moveHorizontal,0.0f,moveVertical);
            rb.AddForce(movimiento*speed);

    }
       void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Recolectable")){
            Debug.Log(contador);
            contador++;
            textUI.text = "Contador: "+contador.ToString();
            position = other.gameObject.transform.position;
            particulas.position=position;
            systemaParticulas = particulas.GetComponent<ParticleSystem> ();
            systemaParticulas.Play();
            StartCoroutine(DetenerParticulas(systemaParticulas));

            other.gameObject.SetActive(false);
            audioRecoleccion.Play();
          
                Debug.Log("RRR");
                recolected=true;
            
            if(contador>=13){
            Award.text="Ganaste";            
            }
        
       
    }
      if(other.gameObject.CompareTag("RecolectableR")){
            Debug.Log("ASD");
            contador++;
            textUI.text = "Contador: "+contador.ToString();
            position = other.gameObject.transform.position;
            particulas.position=position;
            systemaParticulas = particulas.GetComponent<ParticleSystem> ();
            systemaParticulas.Play();
            
            StartCoroutine(DetenerParticulas(systemaParticulas));
            other.gameObject.SetActive(false);
            audioRecoleccion.Play();
            recolected=true;
             
           // SceneManager.LoadScene(1);

        }
    }
    public IEnumerator DetenerParticulas(ParticleSystem part){
        yield return new WaitForSecondsRealtime(5);
        part.Stop();
    }

    public IEnumerator DesaparecerCubo(){
        yield return new WaitForSecondsRealtime(10);
        Cubo10Segundos.SetActive(false);
    }
    public IEnumerator DesaparecerCubo5y3(){
        
        for(;;){
            if(!recolected){
            if(Cubo5y3segundos.gameObject.activeSelf){
                Cubo5y3segundos.SetActive(false);
            yield return new WaitForSecondsRealtime(5);
            }else if(!Cubo5y3segundos.gameObject.activeSelf){
               
            Cubo5y3segundos.SetActive(true);
             if(contadorColor==1){
                    Cubo5y3segundos.GetComponent<Renderer>().material.color = Color.green; 
                }else if(contadorColor ==2){
                    Cubo5y3segundos.GetComponent<Renderer>().material.color = Color.black; 
                }else if(contadorColor ==3){
                    Cubo5y3segundos.GetComponent<Renderer>().material.color = Color.red; 
                }else if(contadorColor ==4){
                    Cubo5y3segundos.GetComponent<Renderer>().material.color = Color.white; 
                }else if(contadorColor ==5){
                    Cubo5y3segundos.GetComponent<Renderer>().material.color = Color.blue; 
                    contadorColor=0;
                }
                contadorColor++;
            yield return new WaitForSecondsRealtime(3);
            }
            }else{
                break;
            }
        }
    }

    public IEnumerator Movimiento() {
        for(;;){
            if(Vector3.Distance(transform.position, CuboMovible.transform.position)<6f){
                CuboMovible.transform.position=Vector3.Lerp(CuboMovible.transform.position,
                new Vector3 (Random.Range(-10.0f,10.0f),0.97f, Random.Range(-10.0f,10.0f)),
                20f*Time.deltaTime);
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
