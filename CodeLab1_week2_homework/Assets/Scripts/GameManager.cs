using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Color finalColor;
    
    // Start is called before the first frame update

    private void Awake()
    {
        // if the instance var has not been set
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // if there is already a singleton of this type (gameManager)
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("Game Manager Start");
        //GetComponent<SpriteRenderer>().color = dotColor; //// 
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.CompareTag("Player");
            
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
