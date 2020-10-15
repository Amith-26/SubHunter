using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score = 0;
    public int extraPoints = 0;
    public Text scoreText;
    public Text extraPointsText;
    // Start is called before the first frame update
    void Start()
    {
        Singleton();
        AssignText();
    }
    private void Singleton()
    {
        int count = FindObjectsOfType<Score>().Length;
        if (count > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void AssignText()
    {
        scoreText.text = "EXP : " + score;
        extraPointsText.text = " x " + extraPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void _Score(int points)
    {
        this.score += points;
        scoreText.text = "EXP : " + score;
    }
    public void MetalBoxScore(int _point)
    {
        this.extraPoints += _point;
        extraPointsText.text = " x " + extraPoints;
    }
    public void Reset()
    {
        Destroy(this.gameObject);
    }

}
