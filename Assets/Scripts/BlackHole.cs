using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public float gravityPull = 100f;
    public float minDistanceForPull = 5f;
    public CircleCollider2D areaOfEffect;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Make sure your player GameObject has the "Player" tag.
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if (playerController != null)
            {
                float distance = Vector2.Distance(transform.position, other.transform.position);
                Vector2 direction = (transform.position - other.transform.position).normalized;

                // Calculate the force based on distance
                float forceMagnitude = Mathf.Clamp01((minDistanceForPull - distance) / minDistanceForPull) * gravityPull;
                Vector2 force = direction * forceMagnitude;

                // Apply the force to the player
                playerController.ApplyExternalForce(force);
            }
        }
    }
}
