using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Start()
    {
        Destroy(this.gameObject, 2f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    
}
