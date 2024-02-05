using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    // force amount and max velocity for WASD movement below
    public float forceAmount = 10;
    public float maxVelocity = 10;
    public GameManager gm;

    // get access to player rigidbody and sprite renderer
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // get access to game manager, used to check final color
        gm = GameObject.Find("Game Manager Holder").GetComponent<GameManager>(); 
        
        CheckForPlayerColor(); 
    }
    
    // check the set color of player (in game manager - final color)
    // default white, or set from previous scene
    void CheckForPlayerColor()
    {
        if (gm.finalColor != Color.white)
        {
            spriteRenderer.color = gm.finalColor;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        // WASD controls 
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(forceAmount * Vector3.up);  
            //Debug.Log("W pressed");
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(forceAmount * Vector3.left);
            //Debug.Log("A pressed");
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(forceAmount * Vector3.down);
            //Debug.Log("S pressed");
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(forceAmount * Vector3.right);
            //Debug.Log("D pressed");
        }
        
        // setting normalized max velocity
        if (rb.velocity.magnitude > maxVelocity)
        {
            Vector3 newVelocity = rb.velocity.normalized;
            newVelocity *= maxVelocity;
            rb.velocity = newVelocity;
        }
    }

    // moved to ColorChanger script 
    /*void OnTriggerEnter(Collider other){
        if (other.gameObject.CompareTag("blue"))
        {
            gameObject.tag = "blue";
            Debug.Log("Player tag blue");
            spriteRenderer.color = new Color(0, 0, 1);
        }
    }*/
}
