using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject correspondingKey;
    [HideInInspector] public string correspondingKeyName;


    private void Start()
    {
        correspondingKeyName = correspondingKey.gameObject.name.ToString();
    }
    public void OpenDoor()
    {
        if (EnemyList.AreOpponentsDead())
        {
            SceneLoader.Won();
            Destroy(gameObject);
        }
    }
}
