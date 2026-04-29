using Sirenix.OdinInspector;
using UnityEngine;

public class GameManagerPriority : MonoBehaviour
{
    public MyQueue<string> Entitys = new();

    public float speed = 0;
    public float MaxSpeed = 100;


    public PriorityQueue<EntityStats> priorityQueue =
        new((a, b) => a.speed < b.speed);
    void Start()
    {

    }
    [Button]
    public void Enqueue(string name)
    {
        Entitys.Enqueue(name);
    }
    [Button]
    public void Dequeue()
    {
        Debug.Log("EL PRIMERO EN LUGAR ES : " + Entitys.Dequeue());
    }
    [Button]
    public void Peek()
    {
        Debug.Log("El PROXIMO LUCHADOR ES " + Entitys.Peek());
    }

    [Button]
    public void Clear()
    {
        Entitys.Clear();
    }

    [Button]
    public void Count()
    {
        Debug.Log(Entitys.Count);
    }
}
