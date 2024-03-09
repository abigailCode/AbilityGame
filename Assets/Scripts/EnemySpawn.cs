using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 2f;
    public float minX = -2.75f;
    public float maxX = 2.29f;

    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        // Generar una posición aleatoria en el rango de minX y maxX para el eje X
        float randomX = Random.Range(minX, maxX);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, transform.position.z);

        Quaternion spawnRotation = enemyPrefab.transform.rotation;
        Instantiate(enemyPrefab, spawnPosition, spawnRotation);
    }
}
