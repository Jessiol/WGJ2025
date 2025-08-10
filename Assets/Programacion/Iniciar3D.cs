using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Iniciar3D : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Cuarto", LoadSceneMode.Single);

    }
}
