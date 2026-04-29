using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Scriptable Objects/EntityStats")]
public class EntityStats : ScriptableObject
{
    public string EntityName;
    public int id;
    public float speed;
}