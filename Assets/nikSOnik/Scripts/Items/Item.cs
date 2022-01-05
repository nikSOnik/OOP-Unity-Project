using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField] string itemName;
    public string ItemName => itemName; //INCAPSULATION
}