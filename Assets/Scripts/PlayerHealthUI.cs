using System;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private TextMeshProUGUI healthText;

    private void OnEnable()
    {
        playerHealth.OnHealthChanged += UpdateHealthUI;
    }

    private void OnDisable()
    {
        playerHealth.OnHealthChanged -= UpdateHealthUI;
    }

    void UpdateHealthUI(int currentHealth)
    {
        healthText.text = currentHealth.ToString();
    }
}
