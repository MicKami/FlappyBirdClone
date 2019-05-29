using UnityEngine.Events;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D body;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private float spinForce;

    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    private void Jump()
    {
        ResetVelocity();
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        body.angularVelocity = 0;
        body.AddTorque(-spinForce * (1 + Random.Range(-1, 2) * Random.value * 0.1f), ForceMode2D.Impulse);
    }

    public void ResetVelocity()
    {   
        if(enabled) body.velocity = Vector2.zero;
    }
}
