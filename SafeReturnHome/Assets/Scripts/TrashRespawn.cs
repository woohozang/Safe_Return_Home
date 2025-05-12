using UnityEngine;

public class TrashRespawn : MonoBehaviour
{
    public GameObject trashPrefab; // ������ ������ ������
    public GameObject trashCanPrefab;
    public Vector2 spawnRangeX = new Vector2(-10f, 10f); // X�� ����
    public Vector2 spawnRangeZ = new Vector2(-10f, 10f); // Z�� ����
    public float spawnHeight = 0.5f; // ������ ���� ����
    public float spawnInterval = 3.0f; // ���� ���� (��)
    public int count = 1;
    private float nextSpawnTime = 0.0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnInterval;

            
            for (int i = 0; i < count; i++)
            {
                SpawnTrash();
            }
        }
    }

    void SpawnTrash()
    {
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomZ = Random.Range(spawnRangeZ.x, spawnRangeZ.y);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, randomZ);

        if (trashPrefab != null)
        {
            Instantiate(trashPrefab, spawnPos, Quaternion.identity);
        }
        else if(trashCanPrefab != null)
        {
            Instantiate(trashCanPrefab, spawnPos, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Trash prefab is not assigned in the Inspector.");
        }
    }
}