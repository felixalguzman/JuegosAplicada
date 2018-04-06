using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciarPatos : MonoBehaviour {

    float horaInicio, deltaTPatos = 5f;

    public GameObject nuevoPatoPrefab;

	// Use this for initialization
	void Start () {
        horaInicio = Time.time;
        Instantiate(nuevoPatoPrefab, new Vector3(0, 0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {

        if (Time.time - horaInicio > deltaTPatos)
        {
            //Instanciar nuevo pato
            Instantiate(nuevoPatoPrefab, new Vector3(0, 0), Quaternion.identity);
            horaInicio = Time.time;
            deltaTPatos *= 0.9f;
        }
	}
}
