using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class ColorChanger : MonoBehaviour
{
    // set dotColor in inspector to match the sprite color
    [SerializeField]
    private Color dotColor;
   
    // get access to Game Manager to set the final color when triggered below
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("Game Manager Holder").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        // if player object enters trigger of color dots,
        // set the dotColor serialized field to match the dot
        // set final color in game manager to dotColor
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log($"Player triggered {dotColor}");
            other.GetComponent<SpriteRenderer>().color = dotColor;
            gm.finalColor = dotColor;
        }
    }
}

