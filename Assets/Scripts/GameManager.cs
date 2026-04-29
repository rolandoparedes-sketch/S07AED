using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    public MyQueue<string> BankQueue = new();
    public TMPro.TextMeshProUGUI orderText;
    public Entity[] entities;

    public PriorityQueue<EntityStats> priorityQueue =
        new((a, b) => a.speed < b.speed);

    void Start()
    {
        DetectEntities();
        BuildQueue();
    }

   
    [Button]
    public void DetectEntities()
    {
        entities = FindObjectsByType<Entity>(FindObjectsSortMode.None);
        Debug.Log("Entidades detectadas: " + entities.Length);
    }

   
    [Button]
    public void BuildQueue()
    {
        priorityQueue.Clear();

        for (int i = 0; i < entities.Length; i++)
        {
            priorityQueue.Enqueue(entities[i].stats);
        }

        Debug.Log("Cola construida: " + priorityQueue.Count);
    }

   
    [Button]
    public void Enqueue(string name)
    {
        BankQueue.Enqueue(name);
    }

    [Button]
    public void Dequeue()
    {
        Debug.Log("El primer Luchador es : " + BankQueue.Dequeue());
    }

    [Button]
    public void Peek()
    {
        Debug.Log("El siguiente en Luchar es " + BankQueue.Peek());
    }

    [Button]
    public void Clear()
    {
        BankQueue.Clear();
    }

    [Button]
    public void Count()
    {
        Debug.Log(BankQueue.Count);
    }

  

    [Button]
    public void ShowFirstPriority()
    {
        Debug.Log(priorityQueue.Peek().EntityName);
    }

    [Button]
    public void NextPriority()
    {
        Debug.Log("El siguiente en luchar es: " + priorityQueue.Dequeue().EntityName);
    }
    [Button]
    public void ShowOrder()
    {
        orderText.text = "orden/n";

        MyQueue<EntityStats> temp = new MyQueue<EntityStats>();
        int pos = 1;

        PriorityQueue<EntityStats> copy =
            new((a, b) => a.speed < b.speed);

        while (priorityQueue.Count > 0)
        {
            EntityStats e = priorityQueue.Dequeue();

            orderText.text += pos + ". " + e.EntityName + "\n";

            temp.Enqueue(e);
            copy.Enqueue(e);

            pos++;
        }

        priorityQueue = copy;
    }
}