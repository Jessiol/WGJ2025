using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParteUno : MonoBehaviour
{
    public GameObject personaje;
    public GameObject lugarPeluche, puntoGrd2;

    public float velocidad = 1f;
    // Start is called before the first frame update
    public void puntoPeluche()
    {
        //personaje.transform.position = new Vector3(lugarPeluche.transform.position);
        Debug.Log("boton apretao");
        personaje.transform.position = Vector3.MoveTowards(personaje.transform.position, lugarPeluche.transform.position, velocidad * Time.deltaTime);
    }
}
