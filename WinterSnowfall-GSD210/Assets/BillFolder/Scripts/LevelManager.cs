using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public string SceneName;
    public float delayTime;
    public GameObject WinText;
    private void Start()
    {
        //WinText.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            WinText.gameObject.SetActive(true);
            Invoke("LoadNextLevel", delayTime);
        }
    }
    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneName); // loads scene When player enter the trigger collider
    }
}
