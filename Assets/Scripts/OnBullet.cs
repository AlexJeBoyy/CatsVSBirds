using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBullet : MonoBehaviour
{
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            Destroy(this.gameObject);
            timer = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != ("Bullet"))
        {
            Destroy(this.gameObject);
        }

    }
}
