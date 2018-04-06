using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPuntaje : MonoBehaviour {

    int puntajeActual = 0;
    public TextMesh Textopuntaje;


	// Use this for initialization
	void Start () {
        Textopuntaje.text = "Patos: " + puntajeActual;
	}

    void Update()
    {
        
    }

    public void AumentarPuntaje()
    {
        puntajeActual++;
        Textopuntaje.text = "Patos: " + puntajeActual;
    }
}
