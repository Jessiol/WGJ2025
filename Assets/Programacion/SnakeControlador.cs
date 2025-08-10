using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeControlador : MonoBehaviour
{
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Manzanas"){
            Debug.Log("manzana comida");
            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Pared" || other.gameObject.tag == "Obsta")
        {
            Debug.Log("se acabó");
            Time.timeScale = 0;
        }
    }

}
