using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    float angularSpeed = 5f;
    float currentAngle;
    float racketRadius = 1f;
    int racketDamage = 1;
    public int Damage => racketDamage;
    int moveDirection = 1;
    float rotationDuration = 1f;

    Transform playerTransform;

    private void Awake() 
    {
        playerTransform = FindObjectOfType<PlayerLevel>().transform;
    }

    private void OnEnable() 
    {
        StartCoroutine(RotationDuration());
    }

    void Update()
    {
        currentAngle += angularSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Sin (currentAngle) * racketRadius * moveDirection, playerTransform.position.y,  Mathf.Cos (currentAngle) * racketRadius * moveDirection);
        transform.position = playerTransform.position + offset;
    }

    IEnumerator RotationDuration()
    {
        yield return new WaitForSeconds(rotationDuration);

        Destroy(gameObject);
    }

    public void SetDurationRotation(float duration)
    {
        rotationDuration = duration;
    }

    public void SetDirection(int direction)
    {
        moveDirection = direction;
    }

    public void SetRadius(float radius)
    {
        racketRadius = radius;
    }

    public void SetDamage(int damage)
    {
        racketDamage = damage;
    }

    public void SetSpeed(int speed)
    {
        angularSpeed = speed;
    }
}
