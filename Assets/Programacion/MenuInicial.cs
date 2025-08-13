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
    public void IniciarRealLuego()
    {
        //controlAudio.Play();
        SceneManager.LoadScene("Cuarto", LoadSceneMode.Single);

    }
    public void CreditosFinales()
    {
        //controlAudio.Play();
        SceneManager.LoadScene("CreditosFinales", LoadSceneMode.Single);

    }

    public void goodE()
    {
        //controlAudio.Play();
        panelCreditos.SetActive(true);

    }
    public void badE()
    {
        //controlAudio.Play();
        SceneManager.LoadScene("CreditosFinales", LoadSceneMode.Single);

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
