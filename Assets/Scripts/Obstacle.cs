using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private Collider2D scoreAreaCollider;
    private float currentTime;
    private float velocity;
    static public float Lifetime { get; set; }

    private void OnEnable()
    {
        currentTime = 0;
        scoreAreaCollider.enabled = true;
    }

    public void SetVelocity(float velocity)
    {
        this.velocity = velocity;
    }

    private void Update()
    {
        transform.Translate(-velocity * Time.deltaTime, 0, 0);
        if(currentTime >= Lifetime)
        {
            gameObject.SetActive(false);
        }
        if(velocity > 0)
        {
            currentTime += Time.deltaTime;
        }
    }
}