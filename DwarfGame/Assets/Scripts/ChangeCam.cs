using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam : MonoBehaviour
{
    public GameObject OldCamera;
    public GameObject NewCamera;

    private  BoxCollider2D _collider;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.gameObject.tag == "Player")
        {
            OldCamera.gameObject.SetActive(false);
            NewCamera.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(this.gameObject);
            _collider.isTrigger = false;

        }
    }
    private void Start()
    {
        _collider = GetComponent<BoxCollider2D>();
        NewCamera.gameObject.SetActive(false);
    }
}
