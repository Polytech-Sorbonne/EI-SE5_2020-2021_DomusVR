using System;
using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [Serializable] public class HitEvent : UnityEvent<int> { }
    public HitEvent OnHit = new HitEvent();
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
            FigureOutScore(collision.transform.position);
    }

    private void FigureOutScore(Vector3 hitPosition)
    {
        float distanceFromCenter = Vector3.Distance(transform.position, hitPosition);
        int score = 0;

        if (distanceFromCenter < 0.1f)
            score = 50;
        else if (distanceFromCenter < 0.2f)
            score = 25;
        else if (distanceFromCenter < 0.3f)
            score = 10;
        else if (distanceFromCenter < 0.4f)
            score = 5;
        else if (distanceFromCenter < 0.5f)
            score = 1;

        OnHit.Invoke(score);
    }
}
