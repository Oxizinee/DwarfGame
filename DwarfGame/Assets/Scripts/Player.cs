using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 5;

    private float _inputValue;
    private Rigidbody2D _rb;
    private void OnMove(InputValue value)
    {
        _inputValue = value.Get<float>();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveVector = new Vector2(_inputValue * MovementSpeed, _rb.velocity.y);

        _rb.velocity = moveVector;
    }
}
