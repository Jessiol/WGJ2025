using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    [SerializeField] private GameObject panelCreditos;

    public void IniciarJuego()
    {
        //controlAudio.Play();
        SceneManager.LoadScene("juegoSnake", LoadSceneMode.Single);

    }
    public void AbrirMuestraCreditos()
    {
        //controlAudio.Play();
        panelCreditos.SetActive(false);
        panelCreditos.SetActive(true);
    }
    public void CerrarMuestraCreditos()
    {
        //controlAudio.Play();
        panelCreditos.SetActive(true);
        panelCreditos.SetActive(false);
    }
    public void quitarJuego()
    {
        //controlAudio.Play();
        Application.Quit();
    }
}
