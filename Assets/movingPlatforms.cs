using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movingPlatforms : MonoBehaviour
{
    public float leftLimit = -15.0f;
    public float resetXPosition = 40.0f;
    public float speed = 0.5f;
    private int direction = 1;
    public GameObject bonePrefab;
    public float boneProbability = 0.5f;
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {

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

    /*
    void ResetPosition()
    {
        transform.position = new Vector3(resetXPosition, initialPosition.y, initialPosition.z);
        if (transform.childCount > 0)
        {
            Transform bone = transform.GetChild(0);
            Destroy(bone.gameObject);
        }
        if (Random.value <= boneProbability)
        {
            GameObject bone = Instantiate(bonePrefab, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
            bone.transform.parent = transform;
        }
    }*/

    void ResetPosition()
    {
        transform.position = new Vector3(resetXPosition, initialPosition.y, initialPosition.z);

        if (transform.childCount > 0)
        {
            Transform bone = transform.GetChild(0);
            Destroy(bone.gameObject);
        }

        if (Random.value <= boneProbability)
        {
            if (bonePrefab != null) // Check if bonePrefab is assigned
            {
                GameObject bone = Instantiate(bonePrefab, transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity);
                bone.transform.parent = transform;
            }
        }
    }

}