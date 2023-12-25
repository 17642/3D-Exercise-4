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
        //Instantiate(enemyPrefab, new Vector3(0, 0, 6),enemyPrefab.transform.rotation);//(0,0,6) ��ġ�� �ù����� �� ����

        
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);//���� ��ġ�� �� ����
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);//y�� 0(���� �پ��־�� �ϹǷ�)/ X�� Z�� ���� ��ġ

        return randomPos;
    }
}