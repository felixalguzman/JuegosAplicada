using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public enum EstadoJuego
{
    Iniciando,
    Resorte,
    Disparando
}
public class ControlJuego : MonoBehaviour
{

    public List<GameObject> CeldasPrefabs;
    private GameObject objetoNuevo;
    const float ANCHOCOLUMNA = 1, ALTOFILA = 1;
    private Vector3 _areaResorte, _areaResorteAnterior;
    public static EstadoJuego EstadoActual = EstadoJuego.Iniciando;

    private GameObject tiraChinas;

    private bool joystickPresionado;

    private ControlRoca controlRoca;

    // Use this for initialization
    void Start()
    {

        Camera.main.transform.position = new Vector3(7.5f, -4.5f, -10f);
        CargarMapa(1);
        tiraChinas = GameObject.FindGameObjectWithTag("Player");



    }

    // Update is called once per frame
    void Update()
    {

        switch (EstadoActual)
        {

            case EstadoJuego.Iniciando:
                if (Input.touchSupported && Input.touchCount > 0 || Input.GetAxis("Jump") > 0)
                {

                    objetoNuevo = Instantiate(CeldasPrefabs[1], new Vector3(tiraChinas.transform.position.x, tiraChinas.transform.position.y + 0.5f), Quaternion.identity);
                    objetoNuevo.GetComponent<Rigidbody2D>().isKinematic = true;
                    EstadoActual = EstadoJuego.Resorte;
                    controlRoca = objetoNuevo.GetComponent<ControlRoca>();
                }
                break;

            case EstadoJuego.Resorte:

                _areaResorte = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));

                
                if (controlRoca != null)
                {
                    controlRoca.ActualizarAreaResorte(_areaResorte);
                }

               

                if (!joystickPresionado && (CrossPlatformInputManager.GetAxis("Horizontal") != 0 || CrossPlatformInputManager.GetAxis("Vertical") != 0))
                {

                    joystickPresionado = true;
                }
                else if (joystickPresionado && (CrossPlatformInputManager.GetAxis("Horizontal") == 0 && CrossPlatformInputManager.GetAxis("Vertical") == 0))
                {
                    joystickPresionado = false;

                    EstadoActual = EstadoJuego.Disparando;


                    if (controlRoca != null)
                    {
                        controlRoca.Disparar(_areaResorteAnterior *-1);
                    }

                    Camera.main.GetComponent<ControlCamara>().Seguimiento = true;
                    Camera.main.GetComponent<ControlCamara>().objetivo = objetoNuevo.GetComponent<Transform>();
                }
                _areaResorteAnterior = _areaResorte;
                break;

            case EstadoJuego.Disparando:
                break;
        }

    }

    /// <summary>
    /// Funcion para cargar mapas
    /// </summary>
    /// <param name="nivel"> nivel a cargar</param>
    void CargarMapa(int nivel)
    {
        string nivelCargado = Resources.Load<TextAsset>("Nivel" + nivel.ToString()).text;
        int filaActual = 0, columnaActual = -1;

        foreach (char celdaActual in nivelCargado)
        {
            if (celdaActual == '\n')
            {
                filaActual--;
                columnaActual = -1;
                continue;
            }

            columnaActual++;

            switch (celdaActual)
            {
                case '1':

                    objetoNuevo = CeldasPrefabs[0];
                    break;

                case '#':
                    objetoNuevo = CeldasPrefabs[2];
                    break;

                case '@':
                    objetoNuevo = CeldasPrefabs[3];
                    break;

                case '$':
                    objetoNuevo = CeldasPrefabs[4];
                    break;

                default:
                    continue;

            }



            Instantiate(objetoNuevo, new Vector3(columnaActual * ANCHOCOLUMNA, filaActual * ALTOFILA),
            Quaternion.identity);


        }
    }
}
