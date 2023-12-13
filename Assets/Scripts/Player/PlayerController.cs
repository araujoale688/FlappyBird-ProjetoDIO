using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public float jumpInterval = 0.2f;

    private Rigidbody rigidbodyPlayer;

    private float jumpCooldown = 0;
    private bool canJump = true;

    void Start()
    {
        rigidbodyPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        JumpPlayer();
    }

    private void JumpPlayer()
    {
        bool isGameActive = GameManager.Instance.IsGameActive();

        jumpCooldown -= Time.deltaTime;
        canJump = jumpCooldown <= 0 && isGameActive;

        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbodyPlayer.velocity = Vector3.zero;

                rigidbodyPlayer.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);

                jumpCooldown = jumpInterval;
            }
        }

        rigidbodyPlayer.useGravity = isGameActive;
    }
}