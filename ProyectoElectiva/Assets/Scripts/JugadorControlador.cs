using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorControlador : MonoBehaviour {
    public int velocidad;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {

    }

    void FixedUpdate () {

        float movimientoHorizontal = Input.GetAxis ("Horizontal");
        float movimientoVertical = Input.GetAxis ("Vertical");
        Vector3 movimiento = new Vector3 (movimientoHorizontal, 0.0f, movimientoVertical);
        rb.AddForce (movimiento * velocidad);

    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Recolectable")) {
            other.gameObject.SetActive (false);
        }

        if (other.gameObject.CompareTag ("RecolectableNegativo")) {
            other.gameObject.SetActive (false);
        }
    }
}