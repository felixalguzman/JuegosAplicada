using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour {

    const float TIEMPORETRASO1 = 0.3f, TIEMPORETRASO2 = 0.9f;
    private float _tiempoUltimoDisparoProyectil1 = 0, _tiempoUltimoDisparoProyectil2 = 0;
    public GameObject proyctil1Prefab;
    public GameObject proyctil2Prefab;
    GameObject _nuevoProyectil;
    float VelocidadTraslacion = 5f;
    const float LIME = 2.45f, LIMO = -2.38f, LIMN = 4.06f, LIMS = -4.39f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.acceleration != Vector3.zero)
        {
            gameObject.transform.Translate(new Vector3(VelocidadTraslacion * Input.acceleration.x, VelocidadTraslacion * Input.acceleration.y ) * Time.deltaTime);

        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            gameObject.transform.Translate(new Vector3(Input.GetAxis("Horizontal") , Input.GetAxis("Vertical")) * Time.deltaTime * VelocidadTraslacion);

        }

        gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, LIMO, LIME), Mathf.Clamp(gameObject.transform.position.y, LIMS, LIMN));

        if (Time.time - _tiempoUltimoDisparoProyectil1 > TIEMPORETRASO1 && Input.GetButtonDown("Fire1")  || (Input.touchSupported && Input.touchCount == 1))
        {
            _nuevoProyectil= Instantiate(proyctil1Prefab, gameObject.transform.position, Quaternion.identity);

            _nuevoProyectil.GetComponent<MRUV>().Disparar(10f,0.5f);
            _tiempoUltimoDisparoProyectil1 = Time.time;
        }

        if (Time.time - _tiempoUltimoDisparoProyectil2 > TIEMPORETRASO2 && Input.GetButtonDown("Fire2") || (Input.touchSupported && Input.touchCount == 2))
        {
            _nuevoProyectil = Instantiate(proyctil2Prefab, gameObject.transform.position, Quaternion.identity);

            _nuevoProyectil.GetComponent<MRUV>().Disparar(-4f, 4f);
            _tiempoUltimoDisparoProyectil2 = Time.time;
        }

    }
}
