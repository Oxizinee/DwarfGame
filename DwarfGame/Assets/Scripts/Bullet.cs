using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MovementSpeed = 10;

    private float _outOfScreenTimer = 0;
    void Update()
    {
        MoveForward();
        DeleteOutOfScreen();
    }

    private void MoveForward()
    {
        transform.position += transform.right * MovementSpeed * Time.deltaTime;
    }

    private void DeleteOutOfScreen()
    {
        var pos = Camera.main.WorldToScreenPoint(transform.position);

        if (!Screen.safeArea.Contains(pos))
        {
            _outOfScreenTimer += Time.deltaTime;

            if (_outOfScreenTimer > 2)
            {
                Destroy(gameObject);
            }
        }
    }
}
