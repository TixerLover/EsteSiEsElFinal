using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinkedLists : MonoBehaviour
{
    public GameObject Node;

    LinkedList<Vector3> nodos = new LinkedList<Vector3>();

    private void Start()
    {
        GuardarCoordenada(new Vector3(5, 2, 10));
    }

    public void BotonAgregarCoordenada()
    {
        Vector3 nuevaCoordenada = new Vector3(Random.Range(-5, 5), 2, Random.Range(-10, 10));
        GuardarCoordenada(nuevaCoordenada);
    }

    public void GuardarCoordenada(Vector3 nuevaCoordenada)
    {
        nodos.AddLast(nuevaCoordenada);
        Debug.Log($"Coordenada guardada: {nuevaCoordenada}. Total nodos: {nodos.Count}");
        Instantiate(Node, transform.position, Quaternion.identity);
    }

    public void MostrarRuta()
    {
        Debug.Log($"--- Recorriendo la lista ({nodos.Count} puntos) ---");
        foreach (Vector3 punto in nodos)
        {
            Debug.Log($"Punto en la ruta: {punto}");
        }
    }

    public void ClearRoute()
    {
        nodos.Clear();
        Debug.Log("Elementos despues de depurar: " + nodos.Count);
    }

    public void RemoveSpecific()
    {
        LinkedListNode<Vector3> node = nodos.Find(new Vector3(5, 2, 10));
        if (node != null)
        {
            nodos.Remove(node);
            Debug.Log("Coordenada eliminada con éxito.");
        }
        else
        {
            Debug.Log("El nodo que intentas eliminar no existe en la lista.");
        }
    }

    public void ReverseList()
    {
        nodos = new LinkedList<Vector3>(nodos.Reverse());
        Debug.Log("--- LISTA INVERTIDA ---");
        MostrarRuta();
    }
}