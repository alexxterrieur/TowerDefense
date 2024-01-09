using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesSpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemiesSpawners;
    [SerializeField] private List<GameObject> enemyPrefabs;
    public Vector3 center;
    public Vector3 spawnSize;
    public Vector3 center2;
    public Vector3 donSpawnZone;

    public int waveNumber = 1;
    [SerializeField] private int enemiesNumber = 3; //enemies during the first wave
    public float multWave = 1.6f; //multiplicateurs d'ennemis pour la vague suivante

    public List<GameObject> enemiesAlive;

    void Update()
    {
        if (enemiesAlive.Count == 0)
        {
            //passer en mode inter vague
        }
    }

    public void SpawnWave()
    {
        List<GameObject> selectedEnemies = new List<GameObject>();
        List<GameObject> selectedSpawner = new List<GameObject>();
        for (int i = 0; i < enemiesNumber; i++)
        {
            //random enemy prefab
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            selectedEnemies.Add(enemyPrefab);
            SpawnEnemy(enemyPrefab);
        }
        enemiesNumber = Mathf.RoundToInt(enemiesNumber * multWave);

        waveNumber++;
    }

    //void SpawnEnemy(GameObject enemyPrefab)
    //{
    //    GameObject enemy = Instantiate(enemyPrefab);
    //    enemiesAlive.Add(enemy);
    //    enemy.transform.position = center + new Vector3(Random.Range(-spawnSize.x / 2, spawnSize.x / 2), Random.Range(-spawnSize.y / 2, spawnSize.y / 2), Random.Range(-spawnSize.z / 2, spawnSize.z / 2));
    //}

    void SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab);
        enemiesAlive.Add(enemy);

        Vector3 randomPosition;
        do
        {
            randomPosition = center + new Vector3(
                Random.Range(-spawnSize.x / 2, spawnSize.x / 2),
                Random.Range(-spawnSize.y / 2, spawnSize.y / 2),
                Random.Range(-spawnSize.z / 2, spawnSize.z / 2));
        } while (IsPositionInsideDonSpawnZone(randomPosition));

        enemy.transform.position = randomPosition;
    }

    bool IsPositionInsideDonSpawnZone(Vector3 position)
    {
        // Vérifiez si la position est à l'intérieur de la zone donSpawnZone
        bool insideZone = (
            position.x >= center2.x - donSpawnZone.x / 2 &&
            position.x <= center2.x + donSpawnZone.x / 2 &&
            position.y >= center2.y - donSpawnZone.y / 2 &&
            position.y <= center2.y + donSpawnZone.y / 2 &&
            position.z >= center2.z - donSpawnZone.z / 2 &&
            position.z <= center2.z + donSpawnZone.z / 2
        );

        return insideZone;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(center, spawnSize);

        Gizmos.color = Color.blue;
        Gizmos.DrawCube(center2, donSpawnZone);
    }
}