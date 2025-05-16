using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class TrashRespawn : MonoBehaviour
{
    public GameObject[] trashPrefab; // 생성할 쓰레기 프리팹 배열 선언
    List<GameObject> trashList = new List<GameObject>(); //쓰레기 프리팹 리스트(종류)

    public Vector2 spawnRangeX = new Vector2(-10f, 10f); // X축 범위
    public Vector2 spawnRangeZ = new Vector2(-10f, 10f); // Z축 범위
    public float spawnHeight = 0.5f; // 쓰레기 생성 높이
    public float spawnInterval = 3.0f; // 생성 간격 (초)
    private float nextSpawnTime = 0.0f;
    public bool isGameOver = false;

    void Update()
    {
        if (isGameOver) return;

        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnInterval;
            int count = Random.Range(1, 3); //랜덤 쓰레기가 낙하할 때 1개 또는 2개동시에 떨어짐
            
            for (int i = 0; i < count; i++)
            {
                SpawnTrash();
            }
        }
    }

    void SpawnTrash()
    {
        if (trashPrefab==null || trashPrefab.Length == 0) //예외처리 방어코드? 인스펙터 창에서 배열 값을 0으로 초기화 하면 예외처리 발생
        {
            return;
        }
        float randomX = Random.Range(spawnRangeX.x, spawnRangeX.y);
        float randomZ = Random.Range(spawnRangeZ.x, spawnRangeZ.y);
        Vector3 spawnPos = new Vector3(randomX, spawnHeight, randomZ);
        int TrashIndex = Random.Range(0, trashPrefab.Length);//인스펙터 창에서 동적으로 종류를 설정 후 프리팹 배열의 길이만큼 랜덤하게 쓰레기 투하
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
        isGameOver = true; // 스폰도 중단
    }
}