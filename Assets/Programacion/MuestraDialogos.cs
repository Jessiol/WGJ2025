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
    int tiempoparaeliminarTexto = 4;
    int CantidadAbiertas = 0;
    bool primeravez = false;
    string llave;
    //public GuardarItems items;
    //AccesoEscenaFinal escenaFinal;
    //Tutorial tuto;
    //Controlador jugador;
    public AudioManager audioManager;

    Dictionary<string, string> dicDialogosLila = new Dictionary<string, string>()
    {
        {"Cama", "Esta foto es de cuando ten�a siete a�os. Ese d�a estaba tan cansada... Apenas pod�a moverme, solo quer�a quedarme en la cama con mis peluches. Mam� me dijo que el lupus a veces me har�a sentir as�."},
        {"Bano", "En esta foto ten�a 8 a�os y ya comenzaban a aparecer erupciones en mis brazos. Al principio era raro, pero con el tiempo aprend� a cuidarlas y a no dejar que me molesten tanto."},
        {"Dentista", "�No me gustan los dentistas! Pero ese d�a fui porque me salieron unas llagas muy molestas en la boca. Aunque no fue divertido, aprend� que es parte de vivir con lupus."},
        {"Halloween", "�Halloween siempre ha sido mi d�a favorito! Esta fue la �ltima vez que mi cara estuvo sin la mariposa del lupus. Ahora la tengo todo el tiempo, pero al menos en este recuerdo, me veo tal cual como me sent�a."},
        {"Bebe", "Aqu� ten�a solo un a�o... Mi mam� siempre dice que ya desde chiquita se notaba lo fuerte que era. Aunque no ten�a mucho cabello por la alopecia, �nunca dej� de sonre�r!"},
        {"Patio", "Me encanta salir al patio y la jardiner�a, pero ahora tengo que usar mucho protector solar y procurar estar siempre bajo sombra. El sol no es muy amable conmigo �ltimamente�"},
        {"Cocina", "Aqu� estaba ayudando a mam� en la cocina. Poco despu�s, comenc� a sentir dolor en las manos. Ahora ya no puedo hacerlo tan seguido, por culpa de la artritis..."},
        {"Erizo", "Este es Larry, mi erizo. Duerme mucho durante el d�a, as� que por la noche est� lleno de energ�a. A veces es gru��n, pero as� lo quiero mucho. "},
        {"Coleccionable1", "Este es uno de mis dibujos favoritos, un arco�ris. Siempre los dibujo cuando me siento un poquito triste, �me recuerdan que despu�s de la tormenta, siempre viene algo bonito!"},
        {"Coleccionable2", "Para las personas con lupus tener una dieta balanceada es clave. Las verduras y legumbres son nuestras mejores aliadas."},
        {"Kyoko", "Ella es mi mami, pero ahorita esta ocupada as� que sigamos explorando."}
    };


    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<AudioManager>();
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
        if (!escribiendo)
        {
            textoAEscribir.text = "";
            escribiendo = true;

            panelDeTexto.SetActive(true);
            LeanTween.color(cajadeTexto.GetComponent<RectTransform>(), new Color(1.0f, 1.0f, 1.0f, 1.0f), .5f);

            if (llave == "Cama")
            {
                mensajeTuto();
            }

            btnAcelerar.SetActive(true);

            yield return new WaitForSeconds(1f);
            //
            controlAudio.Play();
            foreach (char letra in texto)
            {
                textoAEscribir.text = textoAEscribir.text + letra;
                yield return new WaitForSeconds(tiempoEntreLetras * Time.timeScale);
            }
            //
            btnAcelerar.SetActive(false);
            controlAudio.Stop();
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


    }

}
