using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybehavior : MonoBehaviour
{
    float speed = 1.0f;
    [SerializeField] Object[] enemyTypes;
    
    // Start is called before the first frame update
    void Start()
    {
     Debug.Log("Vi laver et 2d top-down wave-shooter, der bruger et ottekantet gridsystem. Spillet handler om at overleve så lang tid som muligt mod fjender, som du skal skyde, da de vil røre dig.");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up/*(1, 0, 0)*/*Time.deltaTime*speed);
        
    }
}
