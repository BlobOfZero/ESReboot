using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CthuluDead : MonoBehaviour
{
    public GameObject winScreen;
    EnemyScript enemyScript;

    public void Start()
    {
        enemyScript = GetComponent<EnemyScript>();
    }

    public void Update()
    {
        if (enemyScript.health <= 0)
        {
            winScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
