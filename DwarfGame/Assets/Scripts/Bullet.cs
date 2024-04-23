using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float MovementSpeed = 10;
    void Update()
    {
        MoveForward();
    }

    private void MoveForward()
    {
        transform.position += transform.right * MovementSpeed * Time.deltaTime;
    }
}
