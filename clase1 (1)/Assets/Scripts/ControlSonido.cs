using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSonido : MonoBehaviour {

    private AudioSource audio1;
    private AudioSource audio2;

    // Use this for initialization
    void Start () {
        AudioSource[] audios = GetComponents<AudioSource>();
        audio1 = audios[0];
        audio2 = audios[1]; 
    }



    // Update is called once per frame
    void Update () {
		
	}

    public void ActivarSonidoDisparo()
    {
        audio1.Play();
    }

    public void ActivarSonidoRecarga()
    {
        audio2.PlayDelayed(1);
    }
}
