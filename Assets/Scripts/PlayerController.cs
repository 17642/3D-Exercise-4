using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float powerUpForce = 15.0f;
    public float speed = 5.0f;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    private bool hasPowerUp = false;
    public GameObject powerupIndicator;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput); // ���� �������� ���� ����.
        powerupIndicator.transform.position = transform.position+new Vector3(0,-0.5f,0);//PowerupIndicator ��ġ ����
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            hasPowerUp = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountRoutine());
            powerupIndicator.gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Debug.Log("Collided With "+collision.gameObject.name+"With Powerup Set To"+hasPowerUp);
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;//

            enemyRigidBody.AddForce(awayFromPlayer*powerUpForce,ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpCountRoutine()
    {
        yield return new WaitForSeconds(7);//7�ʰ� ���
        hasPowerUp = false;//�Ŀ��� ����
        powerupIndicator.gameObject.SetActive(false);
    }
}
