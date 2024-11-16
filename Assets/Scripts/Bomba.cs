using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada espada = collision.GetComponent<Espada>();

        if (!espada)
        {
            return;
        }

        FindObjectOfType<GameManager>().AlTocarBomba();
    }
}
