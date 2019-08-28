using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private int contador;
    public Transform particulas;
    private ParticleSystem systemaParticulas;
    private Vector3 position;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();
        contador =12;
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
            contador--;
            if(contador!=0){
            position = other.gameObject.transform.position;
            particulas.position=position;
            systemaParticulas = particulas.GetComponent<ParticleSystem> ();
            systemaParticulas.Play();
            other.gameObject.SetActive(false);
        }else{
            
             
            SceneManager.LoadScene(1);

        }
    }
    }
}
