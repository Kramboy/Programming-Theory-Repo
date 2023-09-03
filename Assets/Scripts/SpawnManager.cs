using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // ENCAPSULATION

    [SerializeField] MainManager mainManager;

    [SerializeField] private Transform pfEnemy;
    [SerializeField] private LayerMask enemyLayer;

    [SerializeField] private Transform minSpawnPosTop;
    [SerializeField] private Transform maxSpawnPosTop;

    private int maxAttempts;

    private void Start()
    {
        StartCoroutine(SpawnEnemyWave());
    }

    private IEnumerator SpawnEnemyWave()
    {
        while (true)
        {
            for (int i = 0; i < mainManager.GetLevel(); i++)
            {
                if (IsValidSpawnPosition(GetRandomPosition(out Vector3 position)))
                {
                    Transform enemyPrefab = Instantiate(pfEnemy, position, Quaternion.identity);
                    Enemy newEnemy = enemyPrefab.GetComponent<Enemy>();
                    newEnemy.SetSpeed(mainManager.GetLevel());
                }
            }
            yield return new WaitForSeconds(5f);
        }
    }

    private Vector3 GetRandomPosition(out Vector3 position)
    {
        float minRandomX = minSpawnPosTop.transform.position.x;
        float maxRandomX = maxSpawnPosTop.transform.position.x;
        float randomX = Random.Range(minRandomX, maxRandomX);

        float minRandomZ = minSpawnPosTop.transform.position.z;
        float maxRandomZ = maxSpawnPosTop.transform.position.z;
        float randomZ = Random.Range(minRandomZ, maxRandomZ);

        Vector3 randomPosition = new(randomX, 0f, randomZ);

        return position = randomPosition;
    }

    private bool IsValidSpawnPosition(Vector3 position)
    {
        Collider[] colliders = Physics.OverlapSphere(position, 1f, enemyLayer);
        if (colliders.Length == 0) return true;
        return false;
    }
}
