using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ControlAnimacion : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<MRUV>().AlCambiarVelocidadPositiva += HaCambiadoHaciaArriba;
	}
	
	// Update is called once per frame
	void Update () {

	}

    void HaCambiadoHaciaArriba(object sender, EventArgs argumentos)
    {
        gameObject.GetComponent<Animator>().SetFloat("velocidadProyectil2", 100f);

    }
}
