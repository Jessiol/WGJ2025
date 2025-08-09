using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    CharacterController control;
    public float velocidad;
    public float salto;

    //Gravedad
    public float gravedad;
    Vector3 movimiento;

    //Animacion
    //public animaciones animScript;

    void Start()
    {
        control = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Mover X, Z
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        control.Move(move * velocidad * Time.deltaTime);

        if (move.magnitude > 1)
        {
            move = move.normalized;
        }

        if (move != Vector3.zero)
        {

            transform.forward = move;
            /*
            if (this.transform.rotation == Quaternion.Euler(0, 100, 0))
            {
                this.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
            if (this.transform.rotation == Quaternion.Euler(0, 0, 0))
            {
                this.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            */
            //animScript.caminar = true;


        }
        else
        {
            //animScript.caminar = false;
        }

        //Gravedad Y
        movimiento.y = movimiento.y + gravedad + Time.deltaTime;
        control.Move(movimiento * Time.deltaTime);

        //Si esta tocando el suelo, evitar la acumulacion
        if (control.isGrounded)
        {
            movimiento.y = 0;
        }

        //Salto Y
        if (Input.GetButton("Jump") && control.isGrounded)
        {
            movimiento.y = movimiento.y + salto;
        }

    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ratita" && control.isGrounded)
        {

            movimiento.y = movimiento.y + salto;
        }
        else if (other.gameObject.tag == "GuardianPuerta")
        {
            movimiento.y = movimiento.y + salto;
        }
        else if (other.gameObject.tag == "guardiasPerg1")
        {
            movimiento.y = movimiento.y + salto;

        }
        else if (other.gameObject.tag == "guardiasPerg2")
        {
            movimiento.y = movimiento.y + salto;
        }
    }
    */
}
