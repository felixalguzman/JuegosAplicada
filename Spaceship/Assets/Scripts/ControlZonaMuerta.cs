using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlZonaMuerta : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Substring(0,9) == "Proyectil" || other.gameObject.tag .Substring(0,10)== "Destruible")
        {
            Destroy(other.gameObject);
        }
    }
}
