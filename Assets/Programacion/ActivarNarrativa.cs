using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivarNarrativa : MonoBehaviour
{
    Narrativa2 narrativa;

    // Start is called before the first frame update
    void Start()
    {
        narrativa = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Narrativa2>();
        narrativa.mostrarPaneles();
    }
    
    

}
