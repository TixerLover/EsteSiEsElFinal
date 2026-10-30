using UnityEngine;

public class Agent : MonoBehaviour
{
    [Header("Status")]
    public Agente currentState = Agente.Idle;
    
    public enum Agente
    {
        Idle,
        Move,
        Stop,
        Change
    }

    void Update()
    {

        switch (currentState)
        {
            case Agente.Idle:
                break;
            case Agente.Move:
                break;
            case Agente.Stop:
                break;
            case Agente.Change:
                break;
        }
    }
}
