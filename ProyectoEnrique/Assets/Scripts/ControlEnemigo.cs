using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class ControlEnemigo : MonoBehaviour
{

    Transform posicionJugador;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        posicionJugador = GameObject.FindGameObjectWithTag("Jugador").transform;
        agent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(posicionJugador.position);
    }
}
