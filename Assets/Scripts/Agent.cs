using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public enum EstadoAgente
    {
        Idle,
        Moviendo,
        Detenerse,
        CambioDeRuta
    }

    public EstadoAgente estadoActual = EstadoAgente.Idle;
    public float velocidad = 5f;

    private LinkedList<Vector3> rutaNodos = new LinkedList<Vector3>();
    private LinkedListNode<Vector3> nodoObjetivoActual;
    private LinkedList<Vector3> nuevaRutaPendiente;

    void Update()
    {
        switch (estadoActual)
        {
            case EstadoAgente.Idle:
                break;

            case EstadoAgente.Moviendo:
                ProcesarMovimiento();
                break;

            case EstadoAgente.Detenerse:
                nodoObjetivoActual = null;
                CambiarEstado(EstadoAgente.Idle); 
                break;

            case EstadoAgente.CambioDeRuta:
                rutaNodos = nuevaRutaPendiente;
                nodoObjetivoActual = rutaNodos.First;
                CambiarEstado(EstadoAgente.Moviendo); 
                break;
        }
    }

    private void ProcesarMovimiento()
    {
        if (nodoObjetivoActual == null)
        {
            CambiarEstado(EstadoAgente.Detenerse);
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, nodoObjetivoActual.Value, velocidad * Time.deltaTime);

        if (Vector3.Distance(transform.position, nodoObjetivoActual.Value) < 0.05f)
        {
            nodoObjetivoActual = nodoObjetivoActual.Next;
            if (nodoObjetivoActual == null)
            {
                CambiarEstado(EstadoAgente.Detenerse);
            }
        }
    }

    public void RecibirInputRuta(LinkedList<Vector3> nuevaRuta)
    {
        if (nuevaRuta == null || nuevaRuta.Count == 0) return;
        nuevaRutaPendiente = nuevaRuta;
        CambiarEstado(EstadoAgente.CambioDeRuta);
    }

    private void CambiarEstado(EstadoAgente nuevoEstado)
    {
        if (estadoActual == nuevoEstado) return;

        estadoActual = nuevoEstado;
        Debug.Log($"Agente cambió de estado a: {estadoActual}");
    }
}
