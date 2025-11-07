using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    int randSpawn;
    Vector3 spawnPos;
    void Awake()
    {
        spawnPos = new Vector3 (2, 1.4f, 0);
        randSpawn = Random.Range(0, enemies.Length);

        Instantiate(enemies[randSpawn], spawnPos, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
