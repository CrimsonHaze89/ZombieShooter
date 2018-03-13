using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour {

    public enum GunType { Semi, Burst, Auto};
    public GunType gunType;

    public bool isFiring;

    public BulletController bullet;
    public float bulletSpeed;

    public float shotCooldown;
    private float shotCounter;

    public Transform firePoint;

	// Use this for initialization
	void Start ()
    {

    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(isFiring)
        {
           
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0)
            {
                shotCounter = shotCooldown;
                BulletController newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);

                newBullet.speed = bulletSpeed;
            }

        }

        else
        {
            shotCounter = 0;
        }
	}


}
