using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParteUno : MonoBehaviour
{
    public Animator gusano;
    NavMeshAgent jugador;
    public GameObject peluche, panuelo, cactus;

    public float velocidad = 1f;

    private void Start()
    {
        jugador = GetComponent<NavMeshAgent>();
        
    }
    public void puntoPeluche()
    {
        jugador.SetDestination(peluche.transform.position);
        
        while (jugador.isStopped == false)
        {
            gusano.SetBool("walk", true);
        }
    }
    public void puntoPanuelo()
    {
        jugador.SetDestination(panuelo.transform.position);
    }
    public void puntoCactus()
    {
        jugador.SetDestination(cactus.transform.position);
    }
}
