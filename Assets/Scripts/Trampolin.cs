using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float fuerzaImpulso = 500f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trampolin"))
        {
            // Obtener el Rigidbody del jugador
            Rigidbody rb = GetComponent<Rigidbody>();

            // Verificar si el Rigidbody no es nulo
            if (rb != null)
            {
                // Calcular la dirección del impulso hacia arriba
                Vector3 direccionImpulso = Vector3.up;

                // Aplicar el impulso al Rigidbody en la dirección calculada
                rb.AddForce(direccionImpulso * fuerzaImpulso);
            }
        }
    }
}
