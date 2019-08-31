using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private string contador;
    private AudioSource audioRecoleccion;
    public Transform particulas;
    public Text textUI;
    public Text Award;
    public GameObject cuboAzul;
    private ParticleSystem systemaParticulas;
    private Vector3 position;
        private Vector3 positionAmarillo1;

    private Vector3 positionAmarillo2;

    private Vector3 positionAmarillo3;
    private Vector3 posipositionRojo1;
    private Vector3 posipositionRojo2;
    private Vector3 posipositionRojo3;
        private Vector3 posipositionAzul;


    public float speed;

    public GameObject cuboAmarillo1;
    public GameObject cuboAmarillo2;
    public GameObject cuboAmarillo3;
    public GameObject cuboRojo1;
    public GameObject cuboRojo2;
    public GameObject cuboRojo3;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();
        contador ="";
        Award.text ="";
        
        audioRecoleccion=GetComponent<AudioSource>();
        textUI.text = "Contador: "+contador.ToString();


        posipositionRojo1 = cuboRojo1.transform.position;
        posipositionRojo2 = cuboRojo2.transform.position;
        posipositionRojo3 = cuboRojo3.transform.position;

        positionAmarillo1 = cuboAmarillo1.transform.position;
        positionAmarillo2 = cuboAmarillo2.transform.position;
        positionAmarillo3 = cuboAmarillo3.transform.position;
        posipositionAzul = cuboAzul.transform.position;


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
        if(other.gameObject.CompareTag("Amarillo")){
            Debug.Log(contador);
            contador="Amarillo";
            textUI.text = "Color: "+contador.ToString();
            position = other.gameObject.transform.position;
            //particulas.position=position;
            //systemaParticulas = particulas.GetComponent<ParticleSystem> ();
            //systemaParticulas.Play();
            other.gameObject.transform.position = new Vector3(
            other.gameObject.transform.position.x-1,
            other.gameObject.transform.position.y,
            other.gameObject.transform.position.z
            );
        
            
            audioRecoleccion.Play();

    }else if (other.gameObject.CompareTag("Rojo")){
        Debug.Log(contador);
            contador="Rojo";
            textUI.text = "Color: "+contador.ToString();
            position = other.gameObject.transform.position;
 
            other.gameObject.transform.position = new Vector3(
            other.gameObject.transform.position.x+1,
            other.gameObject.transform.position.y,
            other.gameObject.transform.position.z
            );
        
            
            audioRecoleccion.Play();

    }else if (other.gameObject.CompareTag("Verde")){
        Debug.Log(contador);
            contador="Verde";
            textUI.text = "Color: "+contador.ToString();
            position = other.gameObject.transform.position;
            
            cuboAzul.gameObject.transform.position = new Vector3(
            cuboAzul.gameObject.transform.position.x,
            cuboAzul.gameObject.transform.position.y,
            -cuboAzul.gameObject.transform.position.z
            );
        
            
            audioRecoleccion.Play();

    }else if(other.gameObject.CompareTag("Azul")){
        
contador="Azul";
            textUI.text = "Color: "+contador.ToString();
       cuboRojo1.transform.position= posipositionRojo1 ;
        cuboRojo2.transform.position=posipositionRojo2 ;
     cuboRojo3.transform.position=posipositionRojo3 ;

       cuboAmarillo1.transform.position =positionAmarillo1 ;
        cuboAmarillo2.transform.position=positionAmarillo2 ;
        cuboAmarillo3.transform.position=positionAmarillo3 ;
       cuboAzul.transform.position= posipositionAzul ;
    }
    }
}
