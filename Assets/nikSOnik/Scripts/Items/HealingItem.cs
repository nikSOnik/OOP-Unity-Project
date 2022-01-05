#region using
using UnityEngine;
#endregion

[CreateAssetMenu(fileName = "New Item", menuName = "nikSOnik/Items/New Healing Item")]
public class HealingItem : Item, IUsable //INHERITANCE
{
    [SerializeField] int amount;
    [SerializeField] AudioClip clip;
    public void Use(Player target) // is this POLYMORPHISM ???
    {
        Stats newStats = target.Stats;
        newStats.health += amount;
        target.Stats = newStats;
        PlaySound();
    }

    private void PlaySound()
    {
       //Play sound effects
    }
}