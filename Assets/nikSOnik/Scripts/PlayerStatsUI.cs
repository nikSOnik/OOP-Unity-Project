using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Ideally I should have created a separate script for a slider with targeted property
/// Where "targeted property" can be ScriptableObject
/// After this I need just reference to the health / stamina / speed slider which contain InitializeValues and UpdateInfo methods
/// </summary>
public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] Player target;
    [SerializeField] Slider healthSlider; 
    [SerializeField] Slider staminaSlider;
    [SerializeField] Slider speedSlider;
    [SerializeField] Color healthColor;
    [SerializeField] Color staminaColor;
    [SerializeField] Color speedColor;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] string healthCharacter;

    private void Awake()
    {
        InitializeValues();
        UpdateInfo();
    }
    void InitializeValues()
    {
        Stats stats = target.Stats;
        ClampedInt value = stats.health;
        healthSlider.minValue = value.Min;
        healthSlider.maxValue = value.Max;

        value = stats.stamina;
        staminaSlider.minValue = value.Min;
        staminaSlider.maxValue = value.Max;

        value = stats.speed;
        speedSlider.minValue = value.Min;
        speedSlider.maxValue = value.Max;
    }
    public void UpdateInfo()
    {
        UpdateHealthSlider();
        UpdateStaminaSlider();
        UpdateSpeedSlider();
        UpdateLivesText();
    }
    private void UpdateLivesText() //ABSTRACTION
    {
        int lives = target.Stats.lives;
        StringBuilder builder = new StringBuilder("Lives: ");
        for (int i = 0; i < lives; i++)
        {
            builder.Append(healthCharacter);
        }
        livesText.text = builder.ToString();
    }
    private void UpdateHealthSlider() //ABSTRACTION
    {
        healthSlider.value = target.Stats.health;
    }

    private void UpdateStaminaSlider() //ABSTRACTION
    {
        staminaSlider.value = target.Stats.stamina;
    }

    private void UpdateSpeedSlider() //ABSTRACTION
    {
        speedSlider.value = target.Stats.speed;
    }

#if UNITY_EDITOR
    void ChangeColor()
    {
        if (healthSlider != null)
            healthSlider.fillRect.GetComponent<Image>().color = healthColor;
        if (staminaSlider != null)
            staminaSlider.fillRect.GetComponent<Image>().color = staminaColor;
        if (speedSlider != null)
            speedSlider.fillRect.GetComponent<Image>().color = speedColor;
    }
    private void OnValidate()
    {
        ChangeColor();
    }
#endif
}