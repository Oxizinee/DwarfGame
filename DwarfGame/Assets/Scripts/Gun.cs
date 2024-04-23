using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public float RotationSpeed = 180;
    public Transform BulletSpawn;
    public GameObject BulletPrefab;
    private Vector2 _rotationInput;
    private void OnRotate(InputValue value)
    {
        _rotationInput = value.Get<Vector2>();
    }
    private void OnShoot()
    {
        Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_rotationInput != Vector2.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(transform.forward, _rotationInput);
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRot, RotationSpeed * Time.deltaTime);

            transform.rotation = rotation;
        }
    }
}
