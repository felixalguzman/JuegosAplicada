using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMira : MonoBehaviour {

    Vector3 nuevaPsocicionMouse;
	// Use this for initialization
	void Start () {

        Cursor.visible = false;
		
	}
	
	// Update is called once per frame
	void Update () {

        nuevaPsocicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = new Vector3(nuevaPsocicionMouse.x,nuevaPsocicionMouse.y, -0.2f);
		
	}
}
