#region using
using UnityEngine;
#endregion

[CreateAssetMenu(fileName = "New Item", menuName = "nikSOnik/Items/New Speed Item")]
public class SpeedItem : Item, IUsable //INHERITANCE
{
    [SerializeField] int amount;
    [SerializeField] ParticleSystem system;
    public void Use(Player target) // is this POLYMORPHISM ???
    {
        Stats newStats = target.Stats;
        newStats.speed += amount;
        target.Stats = newStats;
        ApplyParticles(target);
    }

    void ApplyParticles(Player target)
    {
        //Apply particles to the player
    }
}