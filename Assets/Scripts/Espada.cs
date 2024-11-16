using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{
    private Rigidbody2D rb;
    public float velocidadMinima = 0.1f;
    private Vector3 ultimaPosicionMouse;
    private Collider2D col;
    private AudioSource audioSource;
    private AudioClip cortarSonido;
    private AudioClip gameOverSonido;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // Cargar los sonidos desde la carpeta Resources
        cortarSonido = Resources.Load<AudioClip>("Sound/cortar");
        gameOverSonido = Resources.Load<AudioClip>("Sound/gameOver");
    }

    void Update()
    {
        col.enabled = SeMueveElMouse();
        AsociarEspadaAlMouse();
    }

    private void AsociarEspadaAlMouse()
    {
        var mousePosicion = Input.mousePosition;
        mousePosicion.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePosicion);
    }

    private bool SeMueveElMouse()
    {
        Vector3 posicionMouseActual = transform.position;
        float desplazamiento = (ultimaPosicionMouse - posicionMouseActual).magnitude;
        ultimaPosicionMouse = posicionMouseActual;
        return desplazamiento > velocidadMinima;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Interactivo")) // Si es una fruta
        {
            audioSource.clip = cortarSonido;
            audioSource.Play();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bomba")) // Si es una bomba
        {
            audioSource.clip = gameOverSonido;
            audioSource.Play();
            FindObjectOfType<GameManager>().AlTocarBomba();
            Destroy(other.gameObject);
        }
    }
}
