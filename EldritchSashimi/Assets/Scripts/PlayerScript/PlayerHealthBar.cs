using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Slider healthSlider;

    public void SetMaxHealth(float health)
    {
        healthSlider.value = health;
    }
}
