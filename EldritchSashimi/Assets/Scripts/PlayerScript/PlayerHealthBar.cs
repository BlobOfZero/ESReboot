using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] Slider playerHealthSlider;
    [SerializeField] float maxValue;
    [SerializeField] float currentValue;
    [SerializeField] PlayerController controller;

    private void Start()
    {
        currentValue = controller.currentHealth;
        maxValue = controller.maxHealth;
        currentValue = maxValue;
        UpdateHealthUI();
    }

    public void UpdateHealthUI()
    {
        playerHealthSlider.value = currentValue / maxValue;
    }
}
