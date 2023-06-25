using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update() {

        if (health > numOfHearts) {
            health = numOfHearts;
        }

        for (int i = 0; i < hearts.Length; i++) {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else {
                hearts[i].enabled = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collider2D component is enabled on the collided object
        if (coll.collider == true && coll.gameObject.tag == "Enemy") //get hurt by enemy
        {
            Debug.Log("Player Hit");
            playerTakeDamage();

        }
    }

    public void playerTakeDamage() {
        if (health == 1)
        {
            Destroy(gameObject);
            Debug.Log("Player Destroyed");
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            health = health - 1;
        }
    }
}
