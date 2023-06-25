using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shooting : MonoBehaviour
{
    //gun statistics
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //references
    //public Camera fpsCam;
    //public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    //graphics
    public TextMeshProUGUI text;

    //shooting base
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    //sound import
    public SoundManager SoundManagerScript;

    void Start() {
        SoundManager SoundManagerScript = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    //base code
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            Shoot2();
        }*/

        MyInput();

        text.SetText(bulletsLeft + " / " + magazineSize);
    }
    /*
    void Shoot2() {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //make the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //access the bullet
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //shoot the bullet
    }*/

    //New Gun code
    private void Awake() {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    private void MyInput() {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
        {
            Reload();
        }

        //shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    private void Reload() {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished() {
        bulletsLeft = magazineSize;
        reloading = false;
    }

    void Shoot() {
        readyToShoot = false;
        //shootingsound
        //SoundManagerScript.PlayShootingSound();

        //spread
        //float x = Random.Range(-spread, spread);
        //float y = Random.Range(-spread, spread);
        //spread is wip

        //Raycast aka projectiles launch include what layers are affected.
        //if collider hits enemy return get component
        //___.collider.GetComponent<ShootingAI>().TakeDamage(damage);

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //make the bullet
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>(); //access the bullet
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); //shoot the bullet

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0) Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot() {
        readyToShoot = true;
    }
}
