using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerUp;

    public int enemyCount = 0;

    private float spawnRange = 9;

    public int waveNumver = 1;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(enemyPrefab, new Vector3(0, 0, 6),enemyPrefab.transform.rotation);//(0,0,6) 위치에 시범으로 적 생성


        //Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);//랜덤 위치에 적 생성
        SpawnEnemyWave(3);//웨이브 시작
        Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);//파워업 소환
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;//남은 Enemy 개체의 수
        if (enemyCount == 0)
        {
            waveNumver++;
            SpawnEnemyWave(waveNumver);//적이 0보다 적으면 적 추가 소환(다음 웨이브)
            Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);//y는 0(땅에 붙어있어야 하므로)/ X와 Z는 랜덤 위치

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);//랜덤 위치 적 생성
        }
    }
}
