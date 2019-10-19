using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlResistencia : MonoBehaviour
{
    // Start is called before the first frame update
    public int resistencia;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RegistrarImpacto(Vector3 puntoImpacto){
        resistencia--;
        if(resistencia<=0){
            Destroy(transform.gameObject);
        }
    }

 
    void OnParticleCollision(GameObject other)
    {
        Debug.Log("collision cubo");
        Destroy(transform.gameObject);
    }
}
