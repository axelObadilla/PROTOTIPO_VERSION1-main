using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrega : MonoBehaviour
{
    public GameObject objetoADestruir; // El objeto que debe ser destruido.
    public Transform objetoDetectar;   // El objeto cuya cercanía se detectará.
    public float distanciaUmbral = 2f;  // La distancia a la que el objeto debe estar para desencadenar la acción.
    public AudioClip sonidoDestruccion; // El clip de sonido a reproducir al destruir el objeto.
    public AudioSource audioSource;     // El AudioSource para reproducir el sonido.

    private bool objetoDestruido = false;

    private void Update()
    {
        if (!objetoDestruido)
        {
            // Calcula la distancia entre los dos objetos.
            float distancia = Vector3.Distance(objetoADestruir.transform.position, objetoDetectar.position);

            // Si la distancia es menor que la distancia umbral, destruye el objeto y reproduce el sonido.
            if (distancia < distanciaUmbral)
            {
                if (sonidoDestruccion != null && audioSource != null)
                {
                    audioSource.PlayOneShot(sonidoDestruccion);
                }
                
                Destroy(objetoADestruir);
                objetoDestruido = true;
            }
        }
    }
}
