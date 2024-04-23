using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 5;
    public float MaxSpeed;
    public LayerMask FloorLayer;

    private float _inputValue, _shootingValue;
    private Rigidbody2D _rb;
    private void OnMove(InputValue value)
    {
        _inputValue = value.Get<float>();
    }
    private void OnShoot(InputValue value)
    {
        _shootingValue = value.Get<float>();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isGrounded())
        {
            _rb.gravityScale = 2;
        }
        else
        {
            _rb.gravityScale = 1;
        }
    }
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveVector = new Vector2(_inputValue * MovementSpeed, 0);
        _rb.AddForce(moveVector, ForceMode2D.Force);

        if (_rb.velocity.magnitude >= MaxSpeed)
        {
            _rb.velocity.Normalize();
        }
    }

    private bool isGrounded()
    {
        if (Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - (transform.localScale.y / 2)), -Vector2.up, 2f, FloorLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
