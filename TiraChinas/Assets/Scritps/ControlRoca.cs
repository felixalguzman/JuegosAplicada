using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlRoca : MonoBehaviour
{

    public Vector3 _areaResorte;
    private const float _desplazamientoMaximo = 1.5f, _velocidadEscalar = 15f;
    private Vector3 _posicionInicial;
    private bool _disparada;
    private Vector3 _aceleracion = new Vector3(0f, -9.8f), _velocidadInicial, _nuevaPosicion;
    private bool _colisionada;
    // Use this for initialization
    void Start()
    {

        _posicionInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {



        if (!_disparada)
        {
            transform.position = _posicionInicial + (_areaResorte * _desplazamientoMaximo);
            return;
        }

        if (!_colisionada)
        {
            _nuevaPosicion = new Vector3(_velocidadInicial.x * Time.deltaTime + (_aceleracion.x * Mathf.Pow(Time.deltaTime, 2) / 2), _velocidadInicial.y * Time.deltaTime + (_aceleracion.y * Mathf.Pow(Time.deltaTime, 2) / 2));

            transform.Translate(_nuevaPosicion);
        }


    }

    public void ActualizarAreaResorte(Vector3 nuevaArea)
    {
        _areaResorte = nuevaArea;
    }

    public void Disparar(Vector3 nuevoResorte)
    {
        _disparada = true;

        _velocidadInicial = nuevoResorte * _velocidadEscalar;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _colisionada = true;
		GetComponent<Rigidbody2D>().isKinematic = false;
		GetComponent<Rigidbody2D>().gravityScale = 0f;
		GetComponent<PolygonCollider2D>().isTrigger = false;
    }
}
