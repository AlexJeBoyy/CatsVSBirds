using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    readonly private List<string> keys = new List<string>();
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            keys.Add(collision.gameObject.name);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            if (keys.Contains(collision.gameObject.GetComponent<Door>().correspondingKeyName))
            {
                collision.gameObject.GetComponent<Door>().OpenDoor();
                keys.Remove(collision.gameObject.GetComponent<Door>().correspondingKeyName);
            }
        }

    }
}
