using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();
        contador =0;
        Award.text ="";
        audioRecoleccion=GetComponent<AudioSource>();
        textUI.text = "Contador: "+contador.ToString();
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
            if(contador>=12){
            Award.text="Ganaste";
            
        }else{
            
             
           // SceneManager.LoadScene(1);

        }
    }
    }
    public IEnumerator DetenerParticulas(ParticleSystem part){
        yield return new WaitForSecondsRealtime(5);
        part.Stop();
    }
}
