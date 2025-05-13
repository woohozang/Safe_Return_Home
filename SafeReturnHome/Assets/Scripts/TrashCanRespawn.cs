using UnityEngine;
using UnityEngine.UI; // UI 관련

public class TrashCanRespawn : MonoBehaviour
{
    public GameObject trashCanPrefab;
    public Vector2 spawnRangeX = new Vector2(-250f, 250f); // X축 범위
    public Vector2 spawnRangeZ = new Vector2(-250f, 250f); // Z축 범위
    public float spawnHeight = 100.0f; // 쓰레기 생성 높이
    public float spawnInterval = 5.0f; // 생성 간격 (초)
    public int count = 1;
    private float nextSpawnTime = 0.0f;

    public Button cleanButton; // TrashCan을 제거할 버튼
    private GameObject currentTrashCan; // 현재 생성된 TrashCan

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnInterval;

            // 쓰레기통을 지정된 개수만큼 생성
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

            // 꼭 cleanButton이 설정되어 있어야 함!
            trashCanCollision.SetButton(cleanButton, newTrashCan);
        }
    }
}