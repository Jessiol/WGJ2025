using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Narrativa2 : MonoBehaviour
{
    public int indice = 0;
    public int indiceE = 0;
    public GameObject[] paneles;
    public GameObject[] panelesExtras;

    public void mostrarPaneles()
    {
        paneles[indice].SetActive(true);
     
    }

    public void siguiente()
    {
        if (indice < paneles.Length - 1)
        {
            paneles[indice].SetActive(false);
            indice += 1;
            mostrarPaneles();
        }
        else
        {
            paneles[indice].SetActive(false);
        }
    }

    public void mostrarPanelesExtras()
    {
        panelesExtras[indiceE].SetActive(true);

    }

    public void siguienteExtras()
    {
        if (indiceE < panelesExtras.Length - 1)
        {
            panelesExtras[indiceE].SetActive(false);
            indiceE += 1;
            mostrarPanelesExtras();
        }
        else
        {
            panelesExtras[indiceE].SetActive(false);
        }
    }
}
