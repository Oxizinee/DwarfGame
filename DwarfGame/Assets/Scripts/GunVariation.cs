using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunVariation : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;

    public float RotationSpeed = 180;
    public float RecoilStrengthVertical = 10;
    public float RecoilStrengthHorizontal = 10;
    public Transform BulletSpawn;
    public Transform BulletSpawn2;
    public Transform BulletSpawn3;
    public GameObject BulletPrefab;
    private Vector2 _rotationInput;
    private void OnRotate(InputValue value)
    {
        _rotationInput = value.Get<Vector2>();
    }
    private void OnShoot()
    {
        if (Player.GetComponent<Player>().Ammo > 0)
        {
            GameObject bullet = Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn.transform.rotation);
            Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn2.transform.rotation);
            Instantiate(BulletPrefab, BulletSpawn.transform.position, BulletSpawn3.transform.rotation);

            Vector3 shootDir = -transform.right;
            Player.GetComponent<Rigidbody2D>().AddForce(new Vector2(shootDir.x * RecoilStrengthHorizontal, shootDir.y * RecoilStrengthVertical), ForceMode2D.Impulse);
            Player.GetComponent<Player>().Ammo--;
        }
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
            Quaternion rotation = Quaternion.RotateTowards(transform.localRotation, targetRot, RotationSpeed * Time.deltaTime);

            transform.localRotation = rotation;
        }
    }
}
