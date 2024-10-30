using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public GameObject thisEnemy;
   // private void Start()
   // {
    //        thisEnemy = GameObject.FindGameObjectWithTag("Enemy");
   // }
    private void OnTriggerEnter2D(Collider2D Bullet)
    {
        {
            if (Bullet.gameObject.tag == ("Bullet") && Bullet.gameObject.layer != 6)
            {
                TakeDamage(10);
            }

        }
    }
    public override void Die()
    {
        EnemyList.instance.KilledEnemy(thisEnemy);
        this.gameObject.SetActive(false);
    }
}
