using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyList : MonoBehaviour
{
    public static List<GameObject> Enemies = new List<GameObject>();

    public static EnemyList instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
        Debug.Log(Enemies.Count + " Enemies Left");
    }
    public void KilledEnemy(GameObject Enemy)
    {
        if (Enemies.Contains(Enemy))
        {
            Enemies.Remove(Enemy);
        }

        Debug.Log(Enemies.Count + " Enemies Left");

    }

    public static bool AreOpponentsDead()
    {
        if (Enemies.Count <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Update()
    {
        AreOpponentsDead();
        if (AreOpponentsDead() == true)
        {
            Debug.Log("Dead");
        }
    }

}
