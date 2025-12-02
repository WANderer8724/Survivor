using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform player;

    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;

    public float spawnDistance = 10f;   // минимальная дистанция от игрока
    public float spawnInterval = 2f;    // время между спавнами

    private float timer = 0f;

    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }
    }

    void SpawnEnemy()
    {
        // Выбираем точку вокруг игрока по кругу
        Vector2 randomCircle = Random.insideUnitCircle.normalized * spawnDistance;

        Vector3 spawnPos = new Vector3(
            player.position.x + randomCircle.x,
            player.position.y,
            player.position.z + randomCircle.y
        );

        // Выбираем случайный враг (1 или 2)
        GameObject prefabToSpawn = (Random.value > 0.5f) ? enemy1Prefab : enemy2Prefab;

        // Создаём врага
        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}