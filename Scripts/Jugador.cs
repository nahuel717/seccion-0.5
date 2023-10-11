using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Jugador : MonoBehaviour
{
    private float velocidadMovimiento = 5.5f;
    private float fuerzaSalto  = 8f;

    public int cantidadDeSaltos = 2;
    private int puntaje;
    private Rigidbody2D rb;

    public bool estaEnSuelo;


    public int devolverPuntaje()
    {
        return puntaje;
    }

    public void setearPuntaje(int valorASumar)
    {
        puntaje += valorASumar;
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        puntaje = 0;
    } 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Piso"))
        {
            estaEnSuelo = true;
            cantidadDeSaltos = 2;
        }
        
    }

    private void OnCollisionExit2D(Collision2D colador)
    {
        if(colador.gameObject.CompareTag("Piso"))
        {
            estaEnSuelo = false;
        }
        
    }


    // Update is called once per frame
    void Update()
    {
        //Mover personaje horizontalmente
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 direccionMovimiento = new Vector2(horizontalInput, 0);
        rb.velocity = new Vector2(direccionMovimiento.x * velocidadMovimiento, rb.velocity.y);

        //hacer que el personaje salte si esta en el suelo o le queden saltos
        if(Input.GetButtonDown("Jump"))
        {
            if(estaEnSuelo || cantidadDeSaltos > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
                cantidadDeSaltos--;
            }
        }
    }
}
