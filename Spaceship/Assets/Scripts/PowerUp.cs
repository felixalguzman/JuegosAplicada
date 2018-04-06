using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TipoPowerUp
{
    Ataque, 
    Defensa, 
    Escudo, 
    Bomba, 
    VelocidadJugador,
    AceleracionRocas
}
public class PowerUp : MonoBehaviour {
    public TipoPowerUp Tipo;
    public GameObject Jugador;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void InicializarPowerUp(TipoPowerUp tipo, GameObject jugador)
    {
        Tipo = tipo;
        Jugador = jugador;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Proyectil1" || other.gameObject.tag == "Proyectil2")
        {
            ActivarPowerUp();
        }
        
    }

    void ActivarPowerUp()
    {
        switch (Tipo)
        {
            case TipoPowerUp.Ataque:
                break;
            case TipoPowerUp.Defensa:
                break;
            case TipoPowerUp.Escudo:
                //Activar escudo en el jugador
                gameObject.GetComponent<ControlEscudo>().ActivarEscudo(Jugador.transform,new Vector3(5,5), Vector3.zero, Random.Range(1.5f,2.5f));
                break;
            case TipoPowerUp.Bomba:
                break;
            case TipoPowerUp.VelocidadJugador:
                break;
            case TipoPowerUp.AceleracionRocas:
                break;
            default:
                break;

            //Para los demas casos los demas tendran un Destroy
        }

       
    }
}
