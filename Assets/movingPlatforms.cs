using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movingPlatforms : MonoBehaviour
{
    public float leftLimit = -15.0f;
    public float resetXPosition = 40.0f;
    public float initialSpeed = 0.5f;
    public float accelerationRate = 0.1f;
    private int direction = 1;
    public GameObject bonePrefab;
    public GameObject enemyPrefab;
    public float prob = 0.5f;
    private Vector3 initialPosition;
    private float elapsedTime;
    private float speed;

    void Start()
    {
        initialPosition = transform.position;
        speed = initialSpeed;
    }

    void Update()
    {

        elapsedTime += Time.deltaTime;
        speed = initialSpeed + accelerationRate * elapsedTime;
        Vector3 movement = -Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);

        if (direction == 1 && transform.position.x < leftLimit)
        {
            ResetPosition();
        }
        else if (direction == -1 && transform.position.x > leftLimit)
        {
            ResetPosition();
        }
    }


    void ResetPosition()
    {
        transform.position = new Vector3(resetXPosition, initialPosition.y, initialPosition.z);

        if (transform.childCount > 0)
        {
            Transform bone = transform.GetChild(0);
            Destroy(bone.gameObject);
        }

        if (Random.value <= prob)
        {
            if (bonePrefab != null) // Check if bonePrefab is assigned
            {
                GameObject bone = Instantiate(bonePrefab, transform.position + new Vector3(Random.value, 0.5f, 0f), Quaternion.identity);
                bone.transform.parent = transform;
            }
        }

        if (Random.value <= prob)
        {
            if (enemyPrefab != null) // Check if bonePrefab is assigned
            {

                GameObject enemy = Instantiate(enemyPrefab, transform.position + new Vector3(Random.value, 0.5f, 0f), Quaternion.identity);
                enemy.transform.parent = transform;
            }
        }
    }

}