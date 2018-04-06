using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Caracter : MonoBehaviour, IDestruible {
    private  List<float> VidasIniciales = new List<float>{1, 2, 4, 7, 14, 20};
    void Awake()
    {
        switch (gameObject.tag)
        {
            case "Destruible1":
                Vidas = VidasIniciales[0];
                break;
            case "Destruible2":
                Vidas = VidasIniciales[1];
                break;
            case "Destruible3":
                Vidas = VidasIniciales[2];
                break;
            case "Destruible4":
                Vidas = VidasIniciales[3];
                break;
            case "Destruible5":
                Vidas = VidasIniciales[4];
                break;
            case "Destruible6":
                Vidas = VidasIniciales[5];
                break;
        }
    }

    private float vidas;

    public float Vidas
    {
        get { return vidas; }
        set { vidas = value; }
    }


    public float ReducirVidas(float dano)
    {
        float resultado = dano > Vidas ? Vidas : dano;
        Vidas -= dano;
        if (Vidas <= 0)
        {
            Destroy(gameObject);
        }

        return resultado;
    }

   

    // Use this for initialization
    void Start () {

        gameObject.GetComponent<MRUV>().Disparar(0,Random.Range(-1f,-5f));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
