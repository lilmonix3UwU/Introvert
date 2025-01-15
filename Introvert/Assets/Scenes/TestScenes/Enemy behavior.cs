using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemybehavior : MonoBehaviour
{
    [SerializeField] float speed = 1.0f;
    [SerializeField] Vector2 targetPosition;
    
    // Start is called before the first frame update
    void Start()
    {
     Debug.Log("Vi laver et 2d top-down wave-shooter, der bruger et ottekantet gridsystem. Spillet handler om at overleve s� lang tid som muligt mod fjender, som du skal skyde, da de vil r�re dig.");
        
    }
    
    // Update is called once per frame
    void Update()
    {
        //float step = speed * Time.deltaTime;
      transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
       
    } 
}
