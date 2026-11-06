using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LinkedLists : MonoBehaviour
{
    public GameObject Node;
    public Agent miAgente;

    LinkedList<Vector3> nodos = new LinkedList<Vector3>();
    LinkedList<GameObject> objetosNodos = new LinkedList<GameObject>();

    private void Start()
    {
        GuardarCoordenada(new Vector3(5, 2, 10));
    }

    public void BotonAgregarCoordenada()
    {
        Camera cam = Camera.main;
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);
        float distanciaZ = Mathf.Abs(cam.transform.position.z);
        Vector3 puntoViewport = new Vector3(randomX, randomY, distanciaZ);
        Vector3 nuevaCoordenada = cam.ViewportToWorldPoint(puntoViewport);
        nuevaCoordenada.z = 0f;

        GuardarCoordenada(nuevaCoordenada);
    }

    public void GuardarCoordenada(Vector3 nuevaCoordenada)
    {
        nodos.AddLast(nuevaCoordenada);
        GameObject nuevoNodoVisual = Instantiate(Node, nuevaCoordenada, Quaternion.identity);
        objetosNodos.AddLast(nuevoNodoVisual);

        Debug.Log($"Coordenada guardada: {nuevaCoordenada}. Total nodos: {nodos.Count}");
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
        foreach (GameObject nodoVisual in objetosNodos)
        {
            Destroy(nodoVisual);
        }

        nodos.Clear();
        objetosNodos.Clear();

        Debug.Log("Ruta limpiada. Elementos: " + nodos.Count);
    }

    public void Remove()
    {
        if (nodos.Count > 0)
        {
            nodos.RemoveFirst();
            Destroy(objetosNodos.First.Value);
            objetosNodos.RemoveFirst();
        }
    }

    public void ReverseList()
    {
        nodos = new LinkedList<Vector3>(nodos.Reverse());
        objetosNodos = new LinkedList<GameObject>(objetosNodos.Reverse());

        Debug.Log("--- LISTA INVERTIDA ---");
        MostrarRuta();
    }

    public void BotonMoverAgente()
    {
        miAgente.RecibirInputRuta(nodos);
    }
}