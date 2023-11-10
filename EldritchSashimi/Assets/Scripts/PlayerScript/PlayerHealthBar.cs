using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField] PlayerController controller;
    [SerializeField] TextMeshProUGUI healthText;

   private void Start()
    {
        controller = GetComponent<PlayerController>();

    }

    private void Update()
    {
        
    }
}
