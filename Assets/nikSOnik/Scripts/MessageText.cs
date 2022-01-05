using System.Collections;
using TMPro;
using UnityEngine;

public class MessageText : MonoBehaviour
{
    TextMeshProUGUI target;
    [SerializeField] float delay;
    private void Awake()
    {
        target = GetComponent<TextMeshProUGUI>();
    }
    public void Show(string message)
    {
        StopAllCoroutines();
        Enable();
        StartCoroutine(ShowMessage(message));
    }

    public void ShowGameOver()
    {
        StopAllCoroutines();
        SetText("Game Over");
        Enable();
    }
    IEnumerator ShowMessage(string message)
    {
        SetText(message);
        yield return new WaitForSeconds(delay);
        Disable();
    }

    void Enable()    //ABSTRACTION
    {
        gameObject.SetActive(true);
    }

    void Disable()    //ABSTRACTION
    {
        gameObject.SetActive(false);
    }

    void SetText(string text)    //ABSTRACTION
    {
        target.text = text;
    }
}