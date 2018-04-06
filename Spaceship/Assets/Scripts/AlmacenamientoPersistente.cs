using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization;
using System.IO;


public class AlmacenamientoPersistente : MonoBehaviour
{
    [DataContract]
    public class Roca
    {
        [DataMember]
        public float PosicionX { get; set; }
        [DataMember]
        public float PosicionY { get; set; }
        [DataMember]
        public float Vidas { get; set; }

        public Roca(float posicionX, float posicionY, float vidas)
        {
            PosicionX = posicionX;
            PosicionY = posicionY;
            Vidas = vidas;
        }
    }

    [DataContract]
    public class EstadoJuego
    {

        [DataMember]
        public int RecordActual { get; set; }
        [DataMember]
        public string NombreJugador { get; set; }
        [DataMember]
        public float PosicionXJugador { get; set; }
        [DataMember]
        public float PosicionYJugador { get; set; }
        [DataMember]
        public List<Roca> Rocas { get; set; }
    }
    public void RegistrarDatoPlayerPrefs(string nombreJugador, int recordActual)
    {
        PlayerPrefs.SetString("NombreJugador", nombreJugador);
        PlayerPrefs.SetInt("RecordActual", recordActual);
    }

    public string ObtenerNombreJugador()
    {
        return PlayerPrefs.GetString("NombreJugador");
    }
    public int ObtenerRecordActual()
    {
        return PlayerPrefs.GetInt("RecordActual");
    }

    public void GuardarEstadoJuego(string nombreJugador, int recordActual, GameObject jugador, List<GameObject> rocas)
    {
		Debug.Log(rocas.Count);
        // Paso 1: Instanciar EstadoJuego
        EstadoJuego nuevoEstado = new EstadoJuego();

        nuevoEstado.NombreJugador = nombreJugador;
        nuevoEstado.RecordActual = recordActual;
        nuevoEstado.PosicionXJugador = jugador.transform.position.x;
        nuevoEstado.PosicionYJugador = jugador.transform.position.y;

        nuevoEstado.Rocas = new List<Roca>();

        foreach (GameObject rocaActual in rocas)
        {
            nuevoEstado.Rocas.Add(new Roca(rocaActual.transform.position.x, rocaActual.transform.position.y, rocaActual.GetComponent<Caracter>().Vidas));
        }

        // Paso 2: Acceder al archivo
        using (FileStream fileStream = new FileStream(Application.persistentDataPath + "/temporal.xml", FileMode.Create))
        {
            // Paso 3: Serializar
            DataContractSerializer dataContract = new DataContractSerializer(typeof(EstadoJuego));
            dataContract.WriteObject(fileStream, nuevoEstado);
        }

    }

	 public EstadoJuego CargarEstadoJuego()
    {
        // Paso 1: Instanciar EstadoJuego
       EstadoJuego nuevoEstado;
        // Paso 2: Acceder al archivo
        using (FileStream fileStream = new FileStream(Application.persistentDataPath + "/temporal.xml", FileMode.Open))
        {
            // Paso 3: Serializar
            DataContractSerializer dataContract = new DataContractSerializer(typeof(EstadoJuego));
            nuevoEstado = (EstadoJuego)dataContract.ReadObject(fileStream);
			return nuevoEstado;
        }

    }
}
