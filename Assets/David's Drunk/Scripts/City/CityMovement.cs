using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityMovement : MonoBehaviour
{
    GameObject ciudad;
    Rigidbody rb;
    float speed = .05f;

    void Awake()
    { // Se inicializa el rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {// Se mueve la ciudad en la escena para dar efecto de recorrido
        rb.MovePosition(transform.position - transform.forward * speed);
	}
}
