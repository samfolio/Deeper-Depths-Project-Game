using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    /*Use this line to insert sounds
     * 
     * SoundManagerScript.PlaySound("Swimming");
     
     */


    public static AudioClip playerHurtSound, playerAirLossSound, swimSound, shootSound, enemyDeathSound, reloadSound, backgroundMusic, backgroundAmbience;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        playerHurtSound = Resources.Load<AudioClip>("playerHurt");
        playerAirLossSound = Resources.Load<AudioClip>("playerLosingAir");
        swimSound = Resources.Load<AudioClip>("Swimming");
        shootSound = Resources.Load<AudioClip>("Shooting");
        enemyDeathSound = Resources.Load<AudioClip>("EnemyDeath");
        reloadSound = Resources.Load<AudioClip>("Reloading");
        backgroundAmbience = Resources.Load<AudioClip>("BackgoundAmbience");
        backgroundMusic = Resources.Load<AudioClip>("BackgroundMusic");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlayShootingSound() {
        audioSrc.PlayOneShot(shootSound);
    }

    public static void PlaySound(string clip) {
        switch (clip) {
            case "playerHurt":
                audioSrc.PlayOneShot(playerHurtSound);
                break;
            case "playerLosingAir":
                audioSrc.PlayOneShot(playerAirLossSound);
                break;
            case "Swimming":
                audioSrc.PlayOneShot(swimSound);
                break;
            case "Shooting":
                audioSrc.PlayOneShot(shootSound);
                break;
            case "Reloading":
                audioSrc.PlayOneShot(reloadSound);
                break;
            case "BackgroundAmbience":
                audioSrc.PlayOneShot(backgroundAmbience);
                break;
            case "BackgroundMusic":
                audioSrc.PlayOneShot(backgroundMusic);
                break;

        }
    }
}
