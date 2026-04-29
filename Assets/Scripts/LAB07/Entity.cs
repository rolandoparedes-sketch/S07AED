using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityStats stats; 

    public void TakeTurn() 
    {
        Debug.Log(stats.EntityName + " actúa");
    }
}

