using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manzana : MonoBehaviour
{

    public BoxCollider2D gridArea;
    // Start is called before the first frame update
    void Start()
    {
        Posicionrandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Posicionrandom()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("manzana creada");
            Posicionrandom();
        }
    }
 }
