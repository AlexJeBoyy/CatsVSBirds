using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;
    private int jeMama;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        //Debug.Log(rot);
        //add rot if -90
        if (rot > 90)
        {
            jeMama = 180;
        }
        else
        {
            jeMama = 0;
        }
        transform.rotation = Quaternion.Euler(0,0,rot + 30 + jeMama);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
