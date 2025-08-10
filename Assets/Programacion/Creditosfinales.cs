using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Creditosfinales : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("CreditosFinales", LoadSceneMode.Single);

    }
}
