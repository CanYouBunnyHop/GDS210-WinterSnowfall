using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKillZone : MonoBehaviour
{
    public float respawnTimer;
    public AudioSource playerDeathSfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            playerDeathSfx.Play();
           Invoke("ResetLevel", respawnTimer);
        }
    }
    private void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
