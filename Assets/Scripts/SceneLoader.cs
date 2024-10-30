using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    private void Awake()
    {
        instance = this;
    }
    public void loadLvL1()
    {
        SceneManager.LoadScene("Level1");
    }
    public static void Die()
    {
        SceneManager.LoadScene("Die");
    }
    public static void Won()
    {
        SceneManager.LoadScene("Won");
    }
}
