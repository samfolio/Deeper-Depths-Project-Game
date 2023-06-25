using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float speed;
    private Transform player;

    public float startingHealth = 100;
    public float currentHealth;
    public float damage;
    //Shooting damageTaken;
    public float damageTaken;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        currentHealth = startingHealth;
        //damageTaken=GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        // If the Collider2D component is enabled on the collided object
        if (coll.collider == true && coll.gameObject.tag == "bullet") //get hurt by bullet
        {
            
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                Debug.Log("Enemy Destroyed");
            }
            else {
                damageTaken = 50;
                currentHealth = currentHealth - damageTaken;
                Debug.Log("Enemy Hit");
            }
        } 
    }
}
