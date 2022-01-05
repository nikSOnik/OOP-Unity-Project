#region using
using UnityEngine;
using UnityEngine.Events;
#endregion

[CreateAssetMenu(fileName = "New Item", menuName = "nikSOnik/Items/New Energy Item")]
public class EnergyItem : Item, IUsable //INHERITANCE
{
    [SerializeField] int amount;
    [SerializeField] UnityEvent action;
    public void Use(Player target)  // is this POLYMORPHISM ???
    {
        Stats newStats = target.Stats;
        newStats.stamina += amount;
        target.Stats = newStats;

        DoSomething();
    }
    void DoSomething()
    {
        Debug.Log($"{ItemName} want to do something!");
        //and invoke the event!
    }
}