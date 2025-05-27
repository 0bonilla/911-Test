using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllCar : MonoBehaviour
{
    private void OnMouseDown()
    {
        CarSelectionManager.selectedCar = this;
        Debug.Log("Coche seleccionado: " + gameObject.name);
    }

    // Método para mover el coche a un destino
    public void MoveTo(Vector3 destino)
    {
        // Aquí puedes usar NavMeshAgent, Lerp, o tu lógica de movimiento
        // Ejemplo simple:
        transform.position = destino;
        // Si usas NavMeshAgent:
        // GetComponent<NavMeshAgent>().SetDestination(destino);
    }
}
