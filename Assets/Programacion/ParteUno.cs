using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class ParteUno : MonoBehaviour
{
    public Animator gusano;
    NavMeshAgent jugador;
    public GameObject peluche, panuelo, cactus;
    public bool uno, dos, tres = false;
    [SerializeField] MuestraDialogos dialogos;
    MenuInicial menus;
    [SerializeField] private PlayableDirector pantallaplayableDirector;

    public float velocidad = 1f;

    private void Start()
    {
        menus = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MenuInicial>();
        dialogos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MuestraDialogos>();
        jugador = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!jugador.pathPending && jugador.remainingDistance <= jugador.stoppingDistance){
            gusano.SetBool("walk", false);

        }
        if(uno && dos && tres)
        {
            pantallaplayableDirector.Play();
        }
        
    }
    public void puntoPeluche()
    {
        gusano.SetBool("walk", true);
        jugador.SetDestination(peluche.transform.position);
        
    }
    public void puntoPanuelo()
    {
        jugador.SetDestination(panuelo.transform.position);
        gusano.SetBool("walk", true);
    }
    public void puntoCactus()
    {
        jugador.SetDestination(cactus.transform.position);
        gusano.SetBool("walk", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "peluche":
                uno = true;
                dialogos.iniciarCorrutinaTexto("peluche");
                Destroy(other.gameObject);
                break;
            case "gamuza":
                dos = true;
                dialogos.iniciarCorrutinaTexto("gamuza");
                Destroy(other.gameObject);
                break;
            case "cactus":
                tres = true;
                dialogos.iniciarCorrutinaTexto("cactus");
                Destroy(other.gameObject);
                break;  
        }
    }

}
