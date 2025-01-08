using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _shotDelay;
    private bool canShoot;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _ammoRegenDelay;
    [SerializeField] private int _maxAmmo;
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    [SerializeField] private GameObject _bullet;
    private GameObject player;

    void Start()
    {
        canShoot = true;
        player = gameObject;
    }


    void Update()
    {
        //rotate the player when A or D is pressed
        if (Input.GetKeyDown(KeyCode.A)) { transform.Rotate(0, 0, 45); }
        if (Input.GetKeyDown(KeyCode.D)) { transform.Rotate(0, 0, -45); }
        // if space is pressed and shot delay has passed it shoots
        if(Input.GetKeyDown(KeyCode.Space) && canShoot)
        { 
            StartCoroutine(Shoot());
        }


    }
    
    private IEnumerator Shoot()
    {
        canShoot = false;
        GameObject tempBullet = Instantiate(_bullet, player.transform.position, player.transform.rotation);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(player.transform.forward * _bulletSpeed);
        yield return new WaitForSeconds(_shotDelay);
        canShoot = true;
    }
    
}
