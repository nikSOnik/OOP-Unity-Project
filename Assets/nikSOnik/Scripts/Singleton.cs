using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour
{
    public static T Instance { get; private set; } //INCAPSULATION
    private void Awake()
    {
        CreateInstance();
    }

    void CreateInstance()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = gameObject.GetComponent<T>();
        DontDestroyOnLoad(gameObject);
    }
}