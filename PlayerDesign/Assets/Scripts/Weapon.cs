using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Weapon : MonoBehaviour
{
    public float recoil = 10.0f;
    public Transform barrel = null;
    public GameObject bulletPrefab = null;

    private XRGrabInteractable interactable = null;
    private Rigidbody rigidBody = null;

    private void Awake()
    {
        interactable = GetComponent<XRGrabInteractable>();
        rigidBody = GetComponent<Rigidbody>();
    }
    
    private void OnEnable()
    {
        interactable.onActivate.AddListener(Fire);
    }

    private void OnDisable()
    {
        interactable.onActivate.RemoveListener(Fire);
    }

    private void Fire(XRBaseInteractor interactor)
    {
        CreateBullet();
        ApplyRecoil();
    }

    private void CreateBullet()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, barrel.position, barrel.rotation);
        Bullet bullet = bulletObject.GetComponent<Bullet>();
        bullet.Lauch();
    }

    private void ApplyRecoil()
    {
        rigidBody.AddRelativeForce(Vector3.right * recoil, ForceMode.Impulse);    
    }
}
