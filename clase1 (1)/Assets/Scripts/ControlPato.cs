using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direccion
{
    NORTE = 0,
    SUR,
    ESTE,
    OESTE,
    NORESTE,
    NOROESTE,
    SURESTE,
    SUROESTE

}

public class ControlPato : MonoBehaviour {

    Direccion direccionActual;
    bool haciaDerecha = true, haciaDerechaAnterior;
    Vector3 nuevaDireccion;
    const float LIMO = -7.5f, LIME = 7.5f, LIMN = 4.5f, LIMS = -1f;
    float velocidadPato = 1f;
    Transform posicionActual;

    // Use this for initialization
    void Start () {

        
        direccionActual = GenerarDireccion();
        haciaDerecha = haciaDerechaAnterior = direccionActual == Direccion.ESTE || direccionActual == Direccion.NORESTE 
            || direccionActual == Direccion.SURESTE ? true : false;
	}
	
    
	// Update is called once per frame
	void Update () {

        nuevaDireccion = Vector3.zero;

        if (direccionActual == Direccion.NORTE || direccionActual == Direccion.NOROESTE || direccionActual == Direccion.NOROESTE)
        {
            nuevaDireccion.y = 1;
        }

        if (direccionActual == Direccion.SUR || direccionActual == Direccion.SURESTE || direccionActual == Direccion.SUROESTE)
        {
            nuevaDireccion.y = -1;
        }

        if (direccionActual == Direccion.ESTE || direccionActual == Direccion.NORESTE || direccionActual == Direccion.SURESTE)
        {
            nuevaDireccion.x = 1;
        }

        if (direccionActual == Direccion.OESTE || direccionActual == Direccion.NOROESTE || direccionActual == Direccion.SUROESTE)
        {
            nuevaDireccion.x = -1;
        }

        gameObject.transform.Translate(nuevaDireccion * Time.deltaTime* velocidadPato);

        detectarColision();

        haciaDerecha = direccionActual == Direccion.ESTE || direccionActual == Direccion.NORESTE
           || direccionActual == Direccion.SURESTE ? true : false;

        if (haciaDerecha != haciaDerechaAnterior)
        {
            // Ha habido un cambio de direccion que requiere un flip

            //Tres formas:
            //1:

            //gameObject.transform.localScale = new Vector3
            //    (gameObject.transform.localScale.x * (haciaDerecha ? 1: -1),
            //    gameObject.transform.localScale.y,
            //    gameObject.transform.localScale.z);

            //2:

            //gameObject.transform.localRotation = new Quaternion(0, haciaDerecha ? 0 : 180, 0, 0);

            //3:

            gameObject.GetComponent<SpriteRenderer>().flipX = !haciaDerecha;
            

            haciaDerechaAnterior = haciaDerecha;
        }
    }

    void detectarColision()
    {
        posicionActual = gameObject.transform;

        direccionActual = (posicionActual.position.x > LIME ||
                           posicionActual.position.x < LIMO ||
                           posicionActual.position.y > LIMN ||
                           posicionActual.position.y < LIMS) ? GenerarDireccion() : direccionActual;


    }

    Direccion GenerarDireccion()
    {
        Direccion _respuesta = Direccion.NORTE;

        switch( Random.Range(0, 8))
        {
            case 0:
                _respuesta = Direccion.NORTE;
                break;
            case 1:
                _respuesta = Direccion.SUR;
                break;
            case 2:
                _respuesta = Direccion.ESTE;
                break;
            case 3:
                _respuesta = Direccion.OESTE;
                break;
            case 4:
                _respuesta = Direccion.NORESTE;
                break;
            case 5:
                _respuesta = Direccion.NOROESTE;
                break;
            case 6:
                _respuesta = Direccion.SURESTE;
                break;
            case 7:
                _respuesta = Direccion.SUROESTE;
                break;
           

        }

        return _respuesta;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "DestructorPatos" && Input.GetAxis("Fire1") > 0)
        {
            GameObject.FindGameObjectWithTag("Disparo").GetComponent<ControlSonido>().ActivarSonidoDisparo();
            Destroy(gameObject);

            GameObject.FindGameObjectWithTag("Disparo").GetComponent<ControlSonido>().ActivarSonidoRecarga();



            //Incrementar puntaje
            GameObject.FindGameObjectWithTag("Globales").GetComponent<ControlPuntaje>().AumentarPuntaje();

            
           
        }
    }
   
}
