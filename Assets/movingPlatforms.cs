using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingPlatforms : MonoBehaviour
{
    public float leftLimit = -15.0f;
    public float resetXPosition = 40.0f;
    public float speed = 0.5f;
    private int direction = 1;

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

    void ResetPosition()
    {
        transform.position = new Vector3(resetXPosition, initialPosition.y, initialPosition.z);
    }
}