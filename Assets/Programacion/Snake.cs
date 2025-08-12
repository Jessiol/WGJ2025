using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Playables;

public class Snake : MonoBehaviour
{
    enum Direccion { Arriba, Derecha, Abajo, Izquierda }
    Direccion direccion = Direccion.Arriba;
    public List<Transform> tail;
    public float updateRate = .5f;
    //public float stepRate;

    public GameObject tailPrefab;
    public Vector3 verticalLimits;
    public Vector3 horizontalLimits;

    [SerializeField] MenuInicial MenuInicial;
    [SerializeField] private PlayableDirector pantallaplayableDirector;
    [SerializeField] private AudioSource controlAudio;

    public int puntos = 0;
    public TMP_Text textPuntos;

    void Start()
    {
        textPuntos.text = ("Puntuación: "+ puntos.ToString());
        InvokeRepeating("Move", 1, updateRate);

        
    }


    public void arriba()
    {
        if (direccion != Direccion.Abajo)
        {
            direccion = Direccion.Arriba;
        }
    }

    public void abajo()
    {
        if (direccion != Direccion.Arriba)
        {
            direccion = Direccion.Abajo;
        }
    }
    public void derecha()
    {
        if (direccion != Direccion.Izquierda)
        {
            direccion = Direccion.Derecha;
        }
    }
    public void izquierda()
    {
        if (direccion != Direccion.Derecha)
        {
            direccion = Direccion.Izquierda;
        }
    }
    void Update()
    {
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //{
        //    //transform.Translate(Vector2.up * speed * Time.deltaTime);
        //    if (direccion != Direccion.Abajo)
        //    {
        //        direccion = Direccion.Arriba;
        //    }
        //}

        //else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        //{
        //    //transform.Translate(Vector2.down * speed * Time.deltaTime);
        //    if (direccion != Direccion.Arriba)
        //    {
        //        direccion = Direccion.Abajo;
        //    }
        //}
        //else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    if (direccion != Direccion.Derecha)
        //    {
        //        direccion = Direccion.Izquierda;
        //    }
        //    // transform.Translate(Vector2.left * speed * Time.deltaTime);
        //}

        //else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    //transform.Translate(Vector2.right * speed * Time.deltaTime);
        //    if (direccion != Direccion.Izquierda)
        //    {
        //        direccion = Direccion.Derecha;
        //    }
        //}
    }

    void Move()
    {
        lastPos = transform.position;

        switch (direccion)
        {
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

        MoveTail();
    }

    Vector3 lastPos;
    void MoveTail()
    {
        for (int i = 0; i < tail.Count; i++)
        {
            Vector3 temp = tail[i].position;
            tail[i].position = lastPos;
            lastPos = temp;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Manzanas")
        {
            puntos += 1;
            textPuntos.text = ("Puntuación: " + puntos.ToString());
            tail.Add(Instantiate(tailPrefab, tail[tail.Count - 1].position, Quaternion.identity).transform);
            other.transform.position = new Vector3(Random.Range(horizontalLimits.x, horizontalLimits.y), Random.Range(verticalLimits.x, verticalLimits.y));
            Debug.Log("cambio");
        }
        else if (other.gameObject.tag == "Pared")
        {
            Debug.Log("se acabó");
            CancelInvoke();
            iniciarjuego();

        }
        else if (other.gameObject.tag == "Obsta")
        {
            Debug.Log("waos");
            CancelInvoke();
            iniciarjuego();
        }
    }

    public void iniciarjuego()
    {
        pantallaplayableDirector.Play();
        controlAudio.Stop();
       

    }

}
