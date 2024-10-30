using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    //Shooting starts an animation in the way your mouse is moving and then goes back to the old one
    //make the rot so that if its between a sertain number it converts it
    //if dog dies make wimper noice 
    private Camera mainCam;
    private Vector3 mousePos;
    public Animator animator;

    private float timer;

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float bulletTimer;
    public float timeBetweenFiring;
    public AudioSource m_shootingSound;

    private void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        if (!canFire)
        {
            bulletTimer += Time.deltaTime;
            if (bulletTimer > timeBetweenFiring)
            {
                canFire = true;
                bulletTimer = 0;
            }
        }
        if (Mouse.current.leftButton.wasPressedThisFrame && canFire)
        {
            canFire = false;
            timer = 0.5f;
            mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.x, rotation.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, -rotZ);

            animator.SetFloat("rot", rotZ);
            animator.SetBool("isShooting", true);
            
                Instantiate(bullet, bulletTransform.position, Quaternion.identity);
            m_shootingSound.Play();

        }
        if (timer > -1)
        {
            timer -= Time.deltaTime;
        }
        if (timer < 0)
        {
            StopAnim();
        }

    }
    void StopAnim()
    {
        animator.SetBool("isShooting", false);
    }

}
