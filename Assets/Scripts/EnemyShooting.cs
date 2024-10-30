using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class EnemyShooting : MonoBehaviour
{
    private GameObject player;
    private bool hasLineOfSight = false;
    public GameObject bullet;
    public GameObject rotPoint;
    public Transform bulletPos;
    public Animator animator;
    public float rotZ;

    private float timer;

   
    public AudioSource m_shootingSound; 
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_shootingSound.playOnAwake = false;
       
    }
    private void FixedUpdate()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position);
        if (ray.collider != null)
        {

            hasLineOfSight = ray.collider.CompareTag("Player");
            if (hasLineOfSight)
            {

                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.green);
            }
            else
            {
                Debug.DrawRay(transform.position, player.transform.position - transform.position, Color.red);

            }
        }
    }
    private void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if (distance < 8)
        {
            timer += Time.deltaTime;
            if (timer > 0.5f && hasLineOfSight)
            {
                timer = 0;
                Shoot();
                Vector3 rotation = player.transform.position;
                rotZ = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
                rotPoint.transform.rotation = Quaternion.Euler(0, 0, -rotZ);

                animator.SetFloat("rot", rotZ);
            }
        }
    }

    void Shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
        m_shootingSound.Play();
        
    }
   
}
