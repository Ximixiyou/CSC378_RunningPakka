using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float acceleration = 0.1f;
    public float maxSpeed = 10f;
    public float initialSlowdownTime = 30f;

    private float currentSpeed;

    void Start()
    {
        currentSpeed = moveSpeed;
        StartCoroutine(Slowdown(initialSlowdownTime));
    }

    void Update()
    {
        // Move the camera to the right at the current speed
        transform.Translate(Vector3.right * currentSpeed * Time.deltaTime);

        // Speed up until reaching the maximum speed
        if (currentSpeed < maxSpeed)
        {
            currentSpeed += acceleration * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, moveSpeed, maxSpeed);
        }
    }

    // Coroutine that slows down the camera over time
    IEnumerator Slowdown(float slowdownTime)
    {
        float elapsedTime = 0f;
        float startSpeed = currentSpeed;

        while (elapsedTime < slowdownTime)
        {
            // Calculate the new speed based on the elapsed time
            float t = elapsedTime / slowdownTime;
            currentSpeed = Mathf.Lerp(startSpeed, moveSpeed, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        currentSpeed = moveSpeed;
    }
}
