using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct ClampedInt
{
    [SerializeField] int min;
    [SerializeField] int max;
    [SerializeField] int value;

    public int Value { get => value; set => this.value = Mathf.Clamp(value, min, max); }
    public int Min => min; //INCAPSULATION
    public int Max => max; //INCAPSULATION
    public bool isMax => value == max;
    public bool isMin => value == min;

    #region Overloading
    public static implicit operator int(ClampedInt value) => value.value; 

    public static ClampedInt operator +(ClampedInt ci, int i)
    {
        ci.Value += i;
        return ci;
    }
    public static ClampedInt operator -(ClampedInt ci, int i)
    {
        ci.Value -= i;
        return ci;
    }
    public static ClampedInt operator ++(ClampedInt ci)
    {
        ci.Value++;
        return ci;
    }
    public static ClampedInt operator --(ClampedInt ci)
    {
        ci.Value--;
        return ci;
    }
    #endregion
}

[System.Serializable]
public struct Stats
{
    public ClampedInt lives;
    public ClampedInt health;
    public ClampedInt stamina;
    public ClampedInt speed;
}

public class Player : MonoBehaviour
{
    public UnityEvent OnDie;
    public UnityEvent<string> OnItemUsed;
    public UnityEvent OnStatsChanged;

    [SerializeField] Stats stats;
    public Stats Stats
    {
        get => stats;
        set
        {
            stats = value;
            OnStatsChanged?.Invoke();
            CheckStats();
        }
    }

    private void CheckStats()
    {
        if (stats.lives <= 0)
        {
            Die();
            return;
        }
        if (stats.health.isMax && !stats.lives.isMax)
        {
            stats.lives++;
            stats.health.Value = stats.health.Max / 3;
        }
        else if (stats.health.isMin)
        {
            stats.lives--;
            stats.health.Value = stats.health.Max / 3;
            CheckStats();
        }
    }

    public void Use(Item item)
    {
        
        if (!(item is IUsable))
        {
            //ABSTRACTION
            ItemUsed($"You can`t use {item.ItemName}");
            return;
        }
        ItemUsed($"You used\n{item.ItemName}\n------");
        (item as IUsable).Use(this);
    }

    void ItemUsed(string message)
    {
        OnItemUsed?.Invoke(message);
    } //ABSTRACTION
    void Die()
    {
        OnDie?.Invoke();
    } //ABSTRACTION
}