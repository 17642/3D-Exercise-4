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
        //Instantiate(enemyPrefab, new Vector3(0, 0, 6),enemyPrefab.transform.rotation);//(0,0,6) ��ġ�� �ù����� �� ����


        //Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);//���� ��ġ�� �� ����
        SpawnEnemyWave(3);//���̺� ����
        Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);//�Ŀ��� ��ȯ
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;//���� Enemy ��ü�� ��
        if (enemyCount == 0)
        {
            waveNumver++;
            SpawnEnemyWave(waveNumver);//���� 0���� ������ �� �߰� ��ȯ(���� ���̺�)
            Instantiate(powerUp, GenerateSpawnPosition(), powerUp.transform.rotation);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);//y�� 0(���� �پ��־�� �ϹǷ�)/ X�� Z�� ���� ��ġ

        return randomPos;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);//���� ��ġ �� ����
        }
    }
}
