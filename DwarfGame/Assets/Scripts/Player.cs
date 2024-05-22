using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 5;
    public float MaxSpeed;
    public LayerMask FloorLayer;
    public float Drag = 6;
    public float AirDrag = 6;
    public int Ammo = 10;
    public float AmmoReload = 4;
    public GameObject AmmoUI;
    public bool IsShootingOne = true;

    public GameObject OneBulletUI, ThreeBulletsUI;

    private Text AmmoText;
    private float _inputValue, _shootingValue, _ammoTimer;
    private Rigidbody2D _rb;
    private void OnMove(InputValue value)
    {
        _inputValue = value.Get<float>();
    }
    private void OnShoot(InputValue value)
    {
        _shootingValue = value.Get<float>();
    }

    private void OnChangeShooting()
    {
        IsShootingOne = !IsShootingOne;
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        AmmoText = AmmoUI.GetComponent<Text>();
    }

    // Update is called once per frame
    private void Update()
    {
        AmmoText.text = Ammo.ToString();

        if (!isGrounded())
        {
            _rb.gravityScale = 2;
        }
        else
        {
            _rb.gravityScale = 1;
        }


        BulletUI();
      //  Reload();
    }

    private void BulletUI()
    {
        if(IsShootingOne) 
        {
            ThreeBulletsUI.SetActive(false);
            OneBulletUI.SetActive(true);
        }
        else
        {
            ThreeBulletsUI.SetActive(true);
            OneBulletUI.SetActive(false);
        }
    }

    private void Reload()
    {
        if (Ammo == 0)
        {
            _ammoTimer += Time.deltaTime;
            if (_ammoTimer >= AmmoReload)
            {
                Ammo = 10;
                _ammoTimer = 0;
                return;
            }
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

        if (isGrounded())
        {
            if (_inputValue != 0)
            {
                _rb.drag = 0;
            }
            else
            {
                _rb.drag = Drag;
            }
        }
        else 
        {
            _rb.drag = AirDrag;
        }
    }

    private bool isGrounded()
    {
        if (Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - (transform.localScale.y / 2)), -Vector2.up, 1f, FloorLayer))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
