using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnemyBullet : OnBullet
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != ("Enemy") && collision.gameObject.tag != ("Bullet"))
        {
            Destroy(this.gameObject);
        }
        
    }
}
