﻿using UnityEngine;

public class Player_walk : MonoBehaviour
{
    [SerializeField]
    private float speed = 500.0f;

    [SerializeField]
    private float jumpForce = 8.0f;
    private bool OnGround = true;

    private Rigidbody2D rigidBody;
    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            Debug.LogError("Failed to cache rigid body. rigid body not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        Vector2 movement = new Vector2(deltaX, rigidBody.velocity.y);
        rigidBody.velocity = movement;

        if (!Mathf.Approximately(deltaX, 0.0f))
        {
            // Scale x to either positive or negative 1 to 'turn' the character
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1.0f, 1.0f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && OnGround == true)
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            OnGround = false;
        }

        if(transform.position.y < -8f)
        {
            transform.position = new Vector3(-8.89f , -5.13f , 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Ground")
        {
            OnGround = true;
        }
    }
}


