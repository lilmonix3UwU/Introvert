using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemybehavior : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Vector2 targetPosition;
    [SerializeField] int enemyHealth;
    [SerializeField] bool fast;
    
    // Start is called before the first frame update
    void Start()
    {
     
    }
    
    // Update is called once per frame
    void Update()
    {
      transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (!fast)
            {
                Destroy(collision.gameObject);
            }
            enemyHealth--;
        }


        if (collision.gameObject.CompareTag("Player")|| enemyHealth <= 0)
        { 
         Destroy(gameObject);
        } 
    }
}
