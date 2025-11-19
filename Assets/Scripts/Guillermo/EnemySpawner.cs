using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] enemies;
    public int maxEnemies = 10;
    public float spawnDelay = 1f;
    public float area = 10f;
    public float spawnHeight = 10f;

    bool spawning;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !spawning)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            spawning = false;
        }
    }

    IEnumerator SpawnEnemies()
    {
        spawning = true;

        for (int i = 0; i < maxEnemies; i++)
        {
            Vector3 pos = transform.position + new Vector3(
                Random.Range(-area, area),
                spawnHeight,
                Random.Range(-area, area)
            );

            if (Physics.Raycast(pos, Vector3.down, out RaycastHit hit, spawnHeight * 2))
                Instantiate(enemies[Random.Range(0, enemies.Length)], hit.point, Quaternion.identity);

            yield return new WaitForSeconds(spawnDelay);
        }

        spawning = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(area * 2, 1, area * 2)); 
    }
}
