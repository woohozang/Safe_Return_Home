using UnityEngine;
using UnityEngine.UI; // UI ����

public class TrashCanRespawn : MonoBehaviour
{
    public GameObject trashCanPrefab;
    public Vector2 spawnRangeX = new Vector2(-250f, 250f); // X�� ����
    public Vector2 spawnRangeZ = new Vector2(-250f, 250f); // Z�� ����
    public float spawnHeight = 100.0f; // ������ ���� ����
    public float spawnInterval = 5.0f; // ���� ���� (��)
    public int count = 1;
    private float nextSpawnTime = 0.0f;

    public Button cleanButton; // TrashCan�� ������ ��ư
    private GameObject currentTrashCan; // ���� ������ TrashCan

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnInterval;

            // ���������� ������ ������ŭ ����
            for (int i = 0; i < count; i++)
            {
                SpawnTrashCan();
            }
        }
    }

    void SpawnTrashCan()
    {
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomZ = Random.Range(spawnRangeZ.x, spawnRangeZ.y);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, randomZ);

        if (trashCanPrefab != null)
        {
            GameObject newTrashCan = Instantiate(trashCanPrefab, spawnPos, Quaternion.identity);

            // Add or get the TrashCanCollision script
            TrashCanCollision trashCanCollision = newTrashCan.GetComponent<TrashCanCollision>();
            if (trashCanCollision == null)
            {
                trashCanCollision = newTrashCan.AddComponent<TrashCanCollision>();
            }

            // �� cleanButton�� �����Ǿ� �־�� ��!
            trashCanCollision.SetButton(cleanButton, newTrashCan);
        }
    }
}