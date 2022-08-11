using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnParticleCollision(GameObject other) 
    {
        Destroy(gameObject);
    }
}
