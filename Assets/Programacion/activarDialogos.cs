using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activarDialogos : MonoBehaviour
{
    [SerializeField] MuestraDialogos dialogos;
    private void OnTriggerEnter(Collider other)
    {
        switch (this.tag)
        {
            case "peluche":
                dialogos.iniciarCorrutinaTexto("peluche");
                break;
            //case "pcBebe":
            //    bottonPrueba.gameObject.SetActive(true);
            //    break;
            //case "pcPatio":
            //    bottonPrueba.gameObject.SetActive(true);
            //    break;
            //case "pcDentista":
            //    bottonPrueba.gameObject.SetActive(true);
            //    break;
            //case "pcHalloween":
            //    bottonPrueba.gameObject.SetActive(true);
            //    break;
            //case "pcBano":
            //    bottonPrueba.gameObject.SetActive(true);
            //    break;
        }
    }
}

