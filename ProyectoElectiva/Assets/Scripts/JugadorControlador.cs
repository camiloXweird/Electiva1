using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JugadorControlador : MonoBehaviour {
    public int velocidad;
    private Rigidbody rb;

    private AudioSource audioRecoge;

    private double nextTime = 0.0;
    public Text tiempo;
    public Text puntos;

    public Transform particulas;
    private ParticleSystem sistemaParticulas;
    private Vector3 posicion;
    // Start is called before the first frame update
    void Start () {
        rb = GetComponent<Rigidbody> ();
        audioRecoge = GetComponent<AudioSource>();
        sistemaParticulas = particulas.GetComponent<ParticleSystem>();
        sistemaParticulas.Stop();
    }

    // Update is called once per frame
    void Update () {
        nextTime += Time.deltaTime;
        tiempo.text=(int)nextTime % 1+":"+(int)nextTime / 60+":"+(int)nextTime % 60;
    }

    void FixedUpdate () {

        float movimientoHorizontal = Input.GetAxis ("Horizontal");
        float movimientoVertical = Input.GetAxis ("Vertical");
        Vector3 movimiento = new Vector3 (movimientoHorizontal, 0.0f, movimientoVertical);
        rb.AddForce (movimiento * velocidad);

    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag ("Recolectable")) {
            posicion = other.gameObject.transform.position;
            particulas.position = posicion;
            sistemaParticulas = particulas.GetComponent<ParticleSystem>();
            sistemaParticulas.Play();
            other.gameObject.SetActive (false);
            puntos.text = ""+(int.Parse(puntos.text)+10)+"";
            audioRecoge.Play();

        }
        else if (other.gameObject.CompareTag ("RecolectableNegativo")) {
            posicion = other.gameObject.transform.position;
            particulas.position = posicion;
            sistemaParticulas = particulas.GetComponent<ParticleSystem>();
            sistemaParticulas.Play();
            other.gameObject.SetActive (false);
            if(int.Parse(puntos.text) >= 10){
            puntos.text = ""+(int.Parse(puntos.text)-10)+"";
            }
            audioRecoge.Play();
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag ("Meta")) {
            SceneManager.LoadScene(1);
        }else if (other.gameObject.CompareTag ("Meta2")) {
            SceneManager.LoadScene(0);
        }
    }
}