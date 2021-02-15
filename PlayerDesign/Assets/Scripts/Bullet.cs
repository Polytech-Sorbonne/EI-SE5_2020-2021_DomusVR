using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float launchForce = 50.0f;
    private Rigidbody rigidBody = null;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void Lauch()
    {
        rigidBody.AddRelativeForce(Vector3.forward * launchForce, ForceMode.Impulse);
        Destroy(gameObject, 5.0f);
    }
}
