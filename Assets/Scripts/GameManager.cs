using UnityEngine;
using Sirenix.OdinInspector;

public class GameManager : MonoBehaviour
{
    public MyQueue<string> BankQueue = new();
    public TMPro.TextMeshProUGUI orderText;
    public Entity[] entities;
    public bool useSpeed = true;

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
        orderText.text = "ORDEN\n";

        MyQueue<EntityStats> temp = new MyQueue<EntityStats>();
        int pos = 1;

        while (priorityQueue.Count > 0)
        {
            EntityStats e = priorityQueue.Dequeue();

            orderText.text += pos + ". " + e.EntityName + "\n";

            temp.Enqueue(e);
            pos++;
        }

        priorityQueue = new PriorityQueue<EntityStats>(
            (a, b) => useSpeed ? a.speed < b.speed : a.id < b.id
        );

        while (temp.Count > 0)
        {
            priorityQueue.Enqueue(temp.Dequeue());
        }
    }
    [Button]
    public void RebuildQueue()
    {
       
        priorityQueue = new PriorityQueue<EntityStats>(
            (a, b) => useSpeed ? a.speed < b.speed : a.id < b.id
        );

       
        for (int i = 0; i < entities.Length; i++)// Nueva cola
        {
            priorityQueue.Enqueue(entities[i].stats);
        }
    }
    [Button]
    public void NextTurn()
    {
        if (priorityQueue.Count == 0)
            return;

        EntityStats current = priorityQueue.Dequeue();

        Debug.Log("Ataca: " + current.EntityName);

        ShowOrder();
    }
}