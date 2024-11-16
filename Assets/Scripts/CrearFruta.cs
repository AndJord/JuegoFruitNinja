using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearFruta : MonoBehaviour
{
    public GameObject prefabFrutaCortada;

    public void CrearFrutaCortada()
    {
        GameObject inst = Instantiate(prefabFrutaCortada, transform.position, transform.rotation);
        Rigidbody[] rbsDeCortados = inst.transform.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody r in rbsDeCortados)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 100), transform.position,.5f);
        }

        FindObjectOfType<GameManager>().AumentarPuntaje();
        Destroy(inst.gameObject, 5);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Espada espada = collision.GetComponent<Espada>();

        if (!espada)
        {
            return;
        }

        CrearFrutaCortada();
    }
}
