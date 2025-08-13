using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Playables;

public class ControlEscena3 : MonoBehaviour
{
    public Animator gusano;
    NavMeshAgent jugador;
    public GameObject flor, pajaro, caca, alfinal;
    public bool uno, dos, tres = false;
    [SerializeField] MuestraDialogos dialogos;
    MenuInicial menus;
    [SerializeField] private PlayableDirector pantallaplayableDirector;
    [SerializeField] private GameObject panelparajo, panelcaca, panelSiguienteNivel;

    AudioSource sonido;

    public float velocidad = 1f;

    private void Start()
    {
        menus = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MenuInicial>();
        dialogos = GameObject.FindGameObjectWithTag("GameManager").GetComponent<MuestraDialogos>();
        sonido = GameObject.FindGameObjectWithTag("canto").GetComponent<AudioSource>();
        jugador = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        if (!jugador.pathPending && jugador.remainingDistance <= jugador.stoppingDistance)
        {
            gusano.SetBool("walk", false);

        }
        if (uno && dos && tres)
        {
            panelSiguienteNivel.SetActive(true);

        }

    }
    public void puntoFlor()
    {
        gusano.SetBool("walk", true);
        jugador.SetDestination(flor.transform.position);
        panelparajo.SetActive(true);

    }
    public void puntoPajaro()
    {
        jugador.SetDestination(pajaro.transform.position);
        gusano.SetBool("walk", true);
        sonido.Play();
        panelcaca.SetActive(true);
    }
    public void puntoCaca()
    {
        jugador.SetDestination(caca.transform.position);
        gusano.SetBool("walk", true);
    }
    public void puntoEscalera()
    {
        jugador.SetDestination(alfinal.transform.position);
        gusano.SetBool("walk", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "pajaro":
                uno = true;
                dialogos.iniciarCorrutinaTexto("pajaro");
                Destroy(other.gameObject);
                break;
            case "flor":
                dos = true;
                dialogos.iniciarCorrutinaTexto("flor");
                Destroy(other.gameObject);
                break;
            case "caca":
                tres = true;
                dialogos.iniciarCorrutinaTexto("caca");
                Destroy(other.gameObject);
                break;
            case "alfinal":
                pantallaplayableDirector.Play();
                break;
        }
    }
}
