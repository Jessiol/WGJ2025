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
        {"Cama", "Esta foto es de cuando tenía siete años. Ese día estaba tan cansada... Apenas podía moverme, solo quería quedarme en la cama con mis peluches. Mamá me dijo que el lupus a veces me haría sentir así."},
        {"Bano", "En esta foto tenía 8 años y ya comenzaban a aparecer erupciones en mis brazos. Al principio era raro, pero con el tiempo aprendí a cuidarlas y a no dejar que me molesten tanto."},
        {"Dentista", "¡No me gustan los dentistas! Pero ese día fui porque me salieron unas llagas muy molestas en la boca. Aunque no fue divertido, aprendí que es parte de vivir con lupus."},
        {"Halloween", "¡Halloween siempre ha sido mi día favorito! Esta fue la última vez que mi cara estuvo sin la mariposa del lupus. Ahora la tengo todo el tiempo, pero al menos en este recuerdo, me veo tal cual como me sentía."},
        {"Bebe", "Aquí tenía solo un año... Mi mamá siempre dice que ya desde chiquita se notaba lo fuerte que era. Aunque no tenía mucho cabello por la alopecia, ¡nunca dejé de sonreír!"},
        {"Patio", "Me encanta salir al patio y la jardinería, pero ahora tengo que usar mucho protector solar y procurar estar siempre bajo sombra. El sol no es muy amable conmigo últimamente…"},
        {"Cocina", "Aquí estaba ayudando a mamá en la cocina. Poco después, comencé a sentir dolor en las manos. Ahora ya no puedo hacerlo tan seguido, por culpa de la artritis..."},
        {"Erizo", "Este es Larry, mi erizo. Duerme mucho durante el día, así que por la noche está lleno de energía. A veces es gruñón, pero así lo quiero mucho. "},
        {"Coleccionable1", "Este es uno de mis dibujos favoritos, un arcoíris. Siempre los dibujo cuando me siento un poquito triste, ¡me recuerdan que después de la tormenta, siempre viene algo bonito!"},
        {"Coleccionable2", "Para las personas con lupus tener una dieta balanceada es clave. Las verduras y legumbres son nuestras mejores aliadas."},
        {"Kyoko", "Ella es mi mami, pero ahorita esta ocupada así que sigamos explorando."}
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
