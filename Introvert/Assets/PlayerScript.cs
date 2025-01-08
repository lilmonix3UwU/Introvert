using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private float _ShotSpeed;
    [SerializeField] private float _BulletSpeed;
    [SerializeField] private float _AmmoRegenDelay;
    [SerializeField] private int _MaxAmmo;
    [SerializeField] private int _MaxHealth;
    [SerializeField] private int _Health;


    void Start()
    {
        
    }


    void Update()
    {
        //rotate the player when A or D is pressed
        if (Input.GetKeyDown(KeyCode.A)) { transform.Rotate(0, 0, 45); }
        if (Input.GetKeyDown(KeyCode.D)) { transform.Rotate(0, 0, -45); }



    }
    
}
