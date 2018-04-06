using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class ControlProyectil : MonoBehaviour
{

    public float Dano = 1f;
    private List<float> DanosIniciales = new List<float> { 1f, 4f, 8f };

    private void Awake()
    {
        switch (gameObject.tag)
        {
            case "Proyectil1":
                Dano = DanosIniciales[0];
                break;
            case "Proyectil2":
                Dano = DanosIniciales[1];
                break;
            case "Escudo":
                Dano = DanosIniciales[2];
                break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Escudo")
        {
            if(!gameObject.GetComponent<ControlEscudo>().Activo)
            return;
        }
        if (other.gameObject.GetComponent<IDestruible>() != null)
        {
            float nuevoPuntaje = other.gameObject.GetComponent<IDestruible>().ReducirVidas(Dano);
            GameObject.Find("ControlJuegoText").GetComponent<ControlJuego>().AumentarRecord((int)nuevoPuntaje);
            Destroy(gameObject);
        }
    }
}
