using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deci : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene("Decision", LoadSceneMode.Single);

    }
}
