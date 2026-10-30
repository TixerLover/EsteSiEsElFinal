using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;

public class LinkedLists : MonoBehaviour
{
    LinkedList<Vector3> nodos = new LinkedList<Vector3>();

    private void Start()
    {
        GuardarCoordenada(new Vector3(0, 0, 0));
        GuardarCoordenada(new Vector3(5, 2, 10));
        GuardarCoordenada(new Vector3(-2, 4, 3));

    }
    public void GuardarCoordenada(Vector3 nuevaCoordenada)
    {
        nodos.AddLast(nuevaCoordenada);
        Debug.Log($"Coordenada guardada: {nuevaCoordenada}");
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
        nodos.Remove(node);
    }

    public void ReverseList()
    {
        LinkedListNode<Vector3> nodoActual = nodos.Last; 

        while (nodoActual != null)
        {
            Debug.Log(nodoActual.Value);
            nodoActual = nodoActual.Previous; 
        }
    }
}
