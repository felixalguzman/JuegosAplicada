using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCamara : MonoBehaviour
{

    public Transform objetivo;
    public bool Seguimiento;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Seguimiento)
        {
            Camera.main.transform.position = new Vector3(objetivo.position.x, Camera.main.transform.position.y, -10f);

        }

    }
}
