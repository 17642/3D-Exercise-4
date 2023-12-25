using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float spawnRange = 9;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(enemyPrefab, new Vector3(0, 0, 6),enemyPrefab.transform.rotation);//(0,0,6) 위치에 시범으로 적 생성

        
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);//랜덤 위치에 적 생성
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);//y는 0(땅에 붙어있어야 하므로)/ X와 Z는 랜덤 위치

        return randomPos;
    }
}
