using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ManejoEscena : MonoBehaviour
{

    public TMP_Text puntajeTexto;
    public Jugador jugadorcito;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        puntajeTexto.text = jugadorcito.devolverPuntaje().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
