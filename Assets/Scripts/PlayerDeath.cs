using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDeath : MonoBehaviour
{
    private const string OBSTACLE_TAG = "Obstacle";
    public UnityEvent OnDeath;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(OBSTACLE_TAG))
        {
            OnDeath?.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(OBSTACLE_TAG))
        {
            OnDeath?.Invoke();
        }
    }
}
