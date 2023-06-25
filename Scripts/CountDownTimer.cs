using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    //timer
    public float currentTime = 0f;
    public float startTime = 300f;

    // air
    public int air;
    public int numOfBubbles;

    public Image[] bubbles;
    public Sprite fullBubble;
    public Sprite emptyBubble;
    public bool drowning = false;

    //damage
    public Health HealthScript;
    public Spawner SpawnScript;

    void Start()
    {
        Health HealthScript = GameObject.Find("Player").GetComponent<Health>();
        Spawner SpawnScript = GameObject.Find("RandomEnemySpawner").GetComponent<Spawner>();
        

        currentTime = startTime;

        InvokeRepeating("AirTimer", 60f, 60f); //Air timer script every 60 seconds
        InvokeRepeating("SpawnEnemy", 6.0f, 2f); //Spawn enemy every 60 seconds
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        //Debug.Log(currentTime);

        if (air > numOfBubbles)
        {
            air = numOfBubbles;
        }

        for (int i = 0; i < bubbles.Length; i++)
        {
            if (i < air)
            {
                bubbles[i].sprite = fullBubble;
            }
            else
            {
                bubbles[i].sprite = emptyBubble;
            }

            if (i < numOfBubbles)
            {
                bubbles[i].enabled = true;
            }
            else
            {
                bubbles[i].enabled = false;
            }
        }
    }

    void SpawnEnemy() {
        Debug.Log(currentTime);
        SpawnScript.Spawn1Enemy();
    }

    void AirTimer() {
        if (air > 0)
        {
            air = air - 1;
        }
        else {
            HealthScript.playerTakeDamage();
            drowning = true;
        }
    
    }
}
