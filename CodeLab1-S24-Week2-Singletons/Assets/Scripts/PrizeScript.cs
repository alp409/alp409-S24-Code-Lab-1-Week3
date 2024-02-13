using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PrizeScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // score goes up by one 
        GameManager.instance.Score++;
        // prize relocates to random new location
        transform.position = new Vector3(
            Random.Range(-10, 10),
            Random.Range(-8, 8));
    }
}
