using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{

    private List<GameObject> _rocasEstadoJuego;
    public List<GameObject> RocasPrefabs;
    public int RecordActual = 0;
    public string NombreJugador = "Felix";
    public TextMesh NombreJugadorText;
    public TextMesh RecordText;
    public GameObject EscudoPrefab;
    private AlmacenamientoPersistente almacenamientoPersistente;
    // Use this for initialization
    void Start()
    {
        almacenamientoPersistente = GetComponent<AlmacenamientoPersistente>();
        InvokeRepeating("InstanciarRoca", 2f, 1.5f);
        InvokeRepeating("GenerarPowerUp", 5f, 10f);
        NombreJugadorText.text = NombreJugador;
        RecordText.text = RecordActual.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F6))
        {
            almacenamientoPersistente.RegistrarDatoPlayerPrefs(NombreJugador, RecordActual);
        }
        else if (Input.GetKeyDown(KeyCode.F7))
        {
            NombreJugador= almacenamientoPersistente.ObtenerNombreJugador();
            NombreJugadorText.text = NombreJugador;
            RecordActual = almacenamientoPersistente.ObtenerRecordActual();
            RecordText.text = RecordActual.ToString();
        }
        else if(Input.GetKeyDown(KeyCode.F8))
        {
            _rocasEstadoJuego = new List<GameObject>();

            foreach(GameObject rocaActual in RocasPrefabs)
            {
                _rocasEstadoJuego.AddRange(GameObject.FindGameObjectsWithTag(rocaActual.tag));

            }
            
            almacenamientoPersistente.GuardarEstadoJuego(NombreJugador,RecordActual, GameObject.FindGameObjectWithTag("Player"), _rocasEstadoJuego);
        }
    }

    void InstanciarRoca()
    {
        Instantiate(RocasPrefabs[Random.Range(0, 6)], new Vector3(Random.Range(-2.42f, 2.46f), 6f), Quaternion.identity);
    }

    void GenerarPowerUp()
    {
        Instantiate(EscudoPrefab, new Vector3(Random.Range(-2.42f, 2.46f), 3f), Quaternion.identity).GetComponent<PowerUp>().InicializarPowerUp(TipoPowerUp.Escudo, GameObject.FindGameObjectWithTag("Player"));
    }

    public void AumentarRecord(int nuevoRecord)
    {
        RecordActual += nuevoRecord;
        RecordText.text = RecordActual.ToString();
    }
}
