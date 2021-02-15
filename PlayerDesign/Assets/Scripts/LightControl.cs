using System;
using UnityEngine;
using UnityEngine.Events;

public class LightControl : MonoBehaviour
{
    public Light lightObject;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ReverseLightState();
        }
    }

    void ReverseLightState()
    {
        if (lightObject.enabled)
        {
            lightObject.enabled = false;
        }
        else
        {
            lightObject.enabled = true;
        }
    }
}
