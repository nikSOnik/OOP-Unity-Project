using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Player player;
    public Player Player => player; //INCAPSULATION
}