using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    private int score;

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        /*If there is no current instance of GameManager,
        allocate this GameManager as one*/
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //When Switching scenes, the GameManager won't be destroyed
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.SetText("Score: " + score);
    }
}
