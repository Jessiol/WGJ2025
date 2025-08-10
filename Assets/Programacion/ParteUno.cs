using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ParteUno : MonoBehaviour
{
    public Animator gusano;
    NavMeshAgent jugador;
    public GameObject peluche, panuelo, cactus;
    [SerializeField] MuestraDialogos dialogos;

    public float velocidad = 1f;

    private void Start()
    {
        dialogos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MuestraDialogos>();
        jugador = GetComponent<NavMeshAgent>();
        
    }
    private void Update()
    {
        if (!jugador.pathPending && jugador.remainingDistance <= jugador.stoppingDistance){
            gusano.SetBool("walk", false);
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
                dialogos.iniciarCorrutinaTexto("peluche");
                Destroy(other.gameObject);
                break;
            case "gamuza":
                dialogos.iniciarCorrutinaTexto("gamuza");
                Destroy(other.gameObject);
                break;
            case "cactus":
                dialogos.iniciarCorrutinaTexto("cactus");
                Destroy(other.gameObject);
                break;
                //case "pcBebe":
                //    bottonPrueba.gameObject.SetActive(true);
                //    break;
                //case "pcPatio":
                //    bottonPrueba.gameObject.SetActive(true);
                //    break;
                //case "pcDentista":
                //    bottonPrueba.gameObject.SetActive(true);
                //    break;
                //case "pcHalloween":
                //    bottonPrueba.gameObject.SetActive(true);
                //    break;
                //case "pcBano":
                //    bottonPrueba.gameObject.SetActive(true);
                //    break;
        }
    }

}
