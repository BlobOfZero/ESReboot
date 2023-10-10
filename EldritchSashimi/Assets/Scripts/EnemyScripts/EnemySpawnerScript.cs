using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    [SerializeField] private float delayspawnrate = 1f;

    [SerializeField] private GameObject enemyPrefabs;

    [SerializeField] private bool CanSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }
    private IEnumerator Spawner()
    {
        WaitForSeconds wait = new WaitForSeconds(delayspawnrate);
        while (CanSpawn)
        {
            yield return wait;

            Instantiate(enemyPrefabs, transform.position, Quaternion.identity);
        }
    }
}
