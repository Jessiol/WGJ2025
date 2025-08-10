using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControlador : MonoBehaviour
{
    enum Direccion { Arriba, Derecha, Abajo, Izquierda }

    Direccion direccion = Direccion.Arriba;

    Vector3 Lastpost;
    [SerializeField] float speed;
    [SerializeField] float distancia;
    [SerializeField] float frecuencia;
    [SerializeField] SpawnManzanas spawnManzanas;
    [SerializeField] MenuInicial MenuInicial;

    [SerializeField] List<Transform> Tail = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Moviendo", 0.5f, frecuencia);
    }

    // Update is called once per frame
    void Update()
    {
        Lastpost = transform.position;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (direccion != Direccion.Abajo)
            {
                direccion = Direccion.Arriba;
            }
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(Vector2.down * speed * Time.deltaTime);
            if (direccion != Direccion.Arriba)
            {
                direccion = Direccion.Abajo;
            }
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (direccion != Direccion.Derecha)
            {
                direccion = Direccion.Izquierda;
            }
            // transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //transform.Translate(Vector2.right * speed * Time.deltaTime);
            if (direccion != Direccion.Izquierda)
            {
                direccion = Direccion.Derecha;
            }
        }

        moveTail();
    }
    
    void moveTail()
    {
        for (int i = 0; i < Tail.Count; i++)
        {
            Vector3 temp = Tail[i].position;
            Tail[i].position = Lastpost;
            Lastpost = temp;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Manzanas"){
            Debug.Log("manzana comida");
            //Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Pared" || other.gameObject.tag == "Obsta")
        {
            Debug.Log("se acabó");
            MenuInicial.IniciarRealLuego();
        }
    }

    void Moviendo()
    {
        switch(direccion){
            case Direccion.Arriba:
            transform.Translate(Vector3.up);
            break;
        case Direccion.Derecha:
            transform.Translate(Vector3.right);
            break;
        case Direccion.Abajo:
            transform.Translate(Vector3.down);
            break;
        case Direccion.Izquierda:
            transform.Translate(Vector3.left);
            break;

        }

    }

}
