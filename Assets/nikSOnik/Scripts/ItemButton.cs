using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ItemButton : MonoBehaviour
{
    [SerializeField] Item item;
    private void Awake()
    {
        InitializeButton();
    }

    private void InitializeButton() //ABSTRACTION
    {
        Button target = GetComponent<Button>();
        target.onClick.AddListener(Click);
        target.GetComponentInChildren<TextMeshProUGUI>().text = $"Use {item.ItemName}";
    }

    void Click()
    {
       GameManager.Instance.Player.Use(item);
    }
}