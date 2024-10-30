using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.InputSystem.Controls;

public class Health : MonoBehaviour
{
    public Image healthbar;
    public TMP_Text healthAmount;
    public float health = 100f;
    public float maxHealth;
    public float timer;
    public float roundedHealth;
    //public float timerReset;



    void Start()
    {
        maxHealth = health;
    }

    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        
        healthAmount.text = ((int)health).ToString() + "/" + maxHealth;

        if (timer > 5)
        {
            Healing(5);
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D Bullet)
    {
        {
            if (Bullet.gameObject.tag == ("Bullet"))
            {
                TakeDamage(10);
            }

        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthbar.fillAmount = health / 100f;
        timer = 0;
    }

    public void Healing(float healing)
    {
        health += healing * Time.deltaTime;
        health = Mathf.Clamp(health, 0, 100);

        healthbar.fillAmount = health / 100f;
    }
    public virtual void  Die()
    {
        //Destroy(this.gameObject);
        //EnemyList.instance.KilledEnemy(thisEnemy);
        //this.gameObject.SetActive(false);
    }
}
