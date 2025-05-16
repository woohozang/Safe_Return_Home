using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TrashRespawn : MonoBehaviour
{
    public GameObject[] trashPrefab; // ������ ������ ������ �迭 ����
    List<GameObject> trashList = new List<GameObject>(); //������ ������ ����Ʈ(����)

    public Vector2 spawnRangeX = new Vector2(-10f, 10f); // X�� ����
    public Vector2 spawnRangeZ = new Vector2(-10f, 10f); // Z�� ����
    public float spawnHeight = 0.5f; // ������ ���� ����
    public float spawnInterval = 3.0f; // ���� ���� (��)
    private float nextSpawnTime = 0.0f;
    public bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnInterval;
            int count = Random.Range(1, 3); //���� �����Ⱑ ������ �� 1�� �Ǵ� 2�����ÿ� ������
            
            for (int i = 0; i < count; i++)
            {
                SpawnTrash();
            }
        }
    }

    void SpawnTrash()
    {
        if (trashPrefab==null || trashPrefab.Length == 0) //����ó�� ����ڵ�? �ν����� â���� �迭 ���� 0���� �ʱ�ȭ �ϸ� ����ó�� �߻�
        {
            return;
        }
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomZ = Random.Range(spawnRangeZ.x, spawnRangeZ.y);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, randomZ);
        int TrashIndex = Random.Range(0, trashPrefab.Length);//�ν����� â���� �������� ������ ���� �� ������ �迭�� ���̸�ŭ �����ϰ� ������ ����
        GameObject AllTrash = trashPrefab[TrashIndex];
        if(AllTrash != null)
        {
            Instantiate(AllTrash, spawnPos, Quaternion.identity);
        }
        
    }
    public void ClearAllTrash()
    {
        foreach (GameObject trash in trashList)
        {
            if (trash != null)
                Destroy(trash);
        }

        trashList.Clear();
        isGameOver = true; // ������ �ߴ�
    }
}