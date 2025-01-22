using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    private bool spamPrevention;

    [SerializeField] private float _shotDelay;
    private bool canShoot;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _ammoRegenDelay;
    [SerializeField] private int _maxAmmo;
    private int currenAmmo;
    [SerializeField] private GameObject _bullet;

    [SerializeField] private GameObject[] _barrels;

    [SerializeField] private int _maxHealth;
    [SerializeField] private int _health;
    
    private GameObject player;

    [SerializeField] private TextMeshPro _ammoText;
    [SerializeField] private TextMeshProUGUI _loseScreenWaveScore;
    [SerializeField] private GameObject _loseScreen;

    void Start()
    {
        canShoot = true;
        player = gameObject;
        currenAmmo = _maxAmmo;
        StartCoroutine(AmmoRegen());
        _health = _maxHealth;
        spamPrevention = true;
    }


    void Update()
    {
        //rotate the player when A or D is pressed
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A)) { transform.Rotate(0, 0, 45); }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D)) { transform.Rotate(0, 0, -45); }

        // if space is pressed and shot delay has passed it shoots
        if(Input.GetKeyDown(KeyCode.Space) && canShoot) { StartCoroutine(Shoot()); }

        if (currenAmmo == 0)
        {
            canShoot = false;
        }
        else 
        {
            canShoot = true;
        }

        //updating ammo count on the player
        _ammoText.text = currenAmmo.ToString();

        if (_health <= 0 && spamPrevention)
        {
            
            //_loseScreenWaveScore.text = "Du nåede til Wave " + ;
            _loseScreen.SetActive(true);
            Time.timeScale = 0;
            spamPrevention = false;
        }

    }



    private IEnumerator Shoot()
    {
        canShoot = false;
        currenAmmo--;
        GameObject tempBullet = Instantiate(_bullet, player.transform.position, player.transform.rotation);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(transform.up * _bulletSpeed);
        yield return new WaitForSeconds(_shotDelay);
        canShoot = true;
        
    }

    private IEnumerator AmmoRegen()
    {
        while (true)
        {
            if (currenAmmo < _maxAmmo)
            {
                yield return new WaitForSeconds(_ammoRegenDelay);
                currenAmmo++;
            }
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            _health--;
            _barrels[_health].SetActive(false);
        }
    }





    public void TryAgain()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
