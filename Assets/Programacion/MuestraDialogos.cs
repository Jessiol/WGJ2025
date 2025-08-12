using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuestraDialogos : MonoBehaviour
{
    [SerializeField] private GameObject panelDeTexto;
    [SerializeField] private GameObject btnAcelerar;
    [SerializeField] private Text textoAEscribir;
    [SerializeField] private GameObject cajadeTexto;
    [SerializeField] public AudioSource controlAudio;
    public bool escribiendo;
    //float tiempoEntreLetras = 0.05f;
    public float tiempoEntreLetras;
    int tiempoparaeliminarTexto = 2;
    int CantidadAbiertas = 0;
    bool primeravez = false;
    string llave;
    Narrativa2 narrativa;
    //public GuardarItems items;
    //AccesoEscenaFinal escenaFinal;
    //Tutorial tuto;
    //Controlador jugador;
    public AudioManager audioManager;

    Dictionary<string, string> dicDialogosLila = new Dictionary<string, string>()
    {
        //ESCENA 2 OBJETOS
        {"peluche", "¡Oh! Esto es tan diferente a mi piel, se mueve cuando la rodeo con mi cuerpo."},
        {"cactus", "¡Auch! Duele…"},
        {"gamuza", "¡Me gusta! Se siente diferente de un lado."},
        //ESCENA 2 NARRATIVA
    };


    void Start()
    {
        narrativa = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Narrativa2>();
        //audioManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioManager>();
        escribiendo = false;
    }

    public void iniciarCorrutinaTexto(string texto)
    {
        StartCoroutine(escribirTextos(dicDialogosLila[texto]));
        llave = texto;

    }

    public IEnumerator escribirTextos(string texto)
    {

        textoAEscribir.CrossFadeAlpha(1, 1f, true);
        yield return new WaitForSeconds(.3f);


        panelDeTexto.SetActive(true);
        LeanTween.color(cajadeTexto.GetComponent<RectTransform>(), new Color(1.0f, 1.0f, 1.0f, 1.0f), .5f);
        if (!escribiendo)
        {
            textoAEscribir.text = "";
            escribiendo = true;

            yield return new WaitForSeconds(1f);
            foreach (char letra in texto)
            {
                textoAEscribir.text = textoAEscribir.text + letra;
                yield return new WaitForSeconds(tiempoEntreLetras * Time.timeScale);
            }

            yield return new WaitForSecondsRealtime(tiempoparaeliminarTexto);
            LeanTween.color(cajadeTexto.GetComponent<RectTransform>(), new Color(1.0f, 1.0f, 1.0f, 0.0f), 1f).setOnComplete(limpiarEspacio);
            textoAEscribir.CrossFadeAlpha(0, 1f, true);


        }
            yield return null;
    }


    public IEnumerator borrarTexto()
    {
        yield return new WaitForSecondsRealtime(tiempoparaeliminarTexto);
        LeanTween.color(cajadeTexto.GetComponent<RectTransform>(), new Color(1.0f, 1.0f, 1.0f, 0.0f), 1f).setOnComplete(limpiarEspacio);
        textoAEscribir.CrossFadeAlpha(0, 1f, true);
    }
    public void limpiarEspacio()
    {
        //jugador.controlesActivados = true;
        CantidadAbiertas += 1;
        textoAEscribir.text = "";
        panelDeTexto.SetActive(false);
        escribiendo = false;

        if (llave == "cactus")
        {
            narrativa.mostrarPanelesExtras();
        }
    }

}
