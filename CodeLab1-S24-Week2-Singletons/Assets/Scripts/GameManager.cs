using System;
using System.Collections;
using System.Collections.Generic;
using System.IO; // i put this one in manually... is that right?
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
// using UnityEngine.Windows; // this was messing me up

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int score = 0; 

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
            Debug.Log("Score changed");
            
            if(score > HighScore)
            {
                HighScore = score;
            }
        }
}
    
    private int highScore = 0;

    private const string KEY_HIGH_SCORE = "High Score";

    int HighScore
    {
        get
        {
            if (File.Exists(DATA_FULL_HS_FILE_PATH))
            {
                string fileContents = File.ReadAllText(DATA_FULL_HS_FILE_PATH);
                highScore = Int32.Parse(fileContents);
            }

            return highScore;
        }

        set
        {
            highScore = value;
            Debug.Log("New High Score!");

            string fileContent = "" + highScore;

            if (!Directory.Exists(Application.dataPath + DATA_DIR))
            {
                Directory.CreateDirectory(Application.dataPath + DATA_DIR);
            }
            
            File.WriteAllText(DATA_FULL_HS_FILE_PATH, fileContent);
        }
    }

    //public int score = 0;
    public int targetScore = 3;
    public TextMeshProUGUI scoreText;

    private int levelNum = 1;

    private const string DATA_DIR = "/Data/";
    private const string DATA_HS_FILE = "hs.txt";

    private string DATA_FULL_HS_FILE_PATH;
    
    private void Awake()
    {
        if (instance == null) // if the instance var has not been set
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // if there is already a singleton of this type
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        DATA_FULL_HS_FILE_PATH = Application.dataPath + DATA_DIR + DATA_HS_FILE;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Level: " + levelNum + "\nScore: " + score + "\nHigh Score: " + HighScore;
        
        //when score reaches target score, we go to the next level
        if (score == targetScore)
        {
            levelNum++;
            SceneManager.LoadScene(
                SceneManager.GetActiveScene().buildIndex + 1);
            targetScore *= Mathf.RoundToInt(
                targetScore + targetScore); // this is controlling the difficulty curve
        }
    }
}
