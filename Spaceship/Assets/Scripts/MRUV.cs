using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public delegate void VelocidadPositivaEventHandler(object sender, EventArgs argumentos);
public class MRUV : MonoBehaviour {
    public event VelocidadPositivaEventHandler AlCambiarVelocidadPositiva;

    float _velocidadInicialY = 0, _aceleracionY = 0;
    bool _disparado = false, _haciaArriba = false;
	// Use this for initialization
	void Start () {
        //Disparar(5f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {

        if (!_disparado)
        {
            return;
        }

        gameObject.transform.Translate(new Vector3(0, _velocidadInicialY*Time.deltaTime + _aceleracionY*Mathf.Pow(Time.deltaTime,2) / 2));

        _velocidadInicialY += _aceleracionY * Time.deltaTime;

        if (_velocidadInicialY < 0)
        {
            _haciaArriba = false;
        }

        if (_velocidadInicialY > 0 && !_haciaArriba && AlCambiarVelocidadPositiva != null)
        {
            AlCambiarVelocidadPositiva(this, EventArgs.Empty);
        }
	}

    public void Disparar(float velocidadInicialY, float aceleracionY)
    {
        _velocidadInicialY = velocidadInicialY;
        _aceleracionY = aceleracionY;
        _disparado = true;
    }
}
