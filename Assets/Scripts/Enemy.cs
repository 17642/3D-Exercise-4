using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookingDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookingDirection * speed);//플레이어 방향으로 힘을 가함(플레이어 위치 - 현재 위치)*속력
    }
}
