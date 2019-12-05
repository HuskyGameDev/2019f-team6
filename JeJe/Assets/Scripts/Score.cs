using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
public class Score : MonoBehaviour
{
    float timer = 0.0f;
    public Text currentScore;
    int helper;
    void Awake()
    {
        currentScore = GetComponent<Text>();
    }
    void Update()
    {

        timer += Time.deltaTime;
        helper = ((int)(timer)) * 20;
        currentScore.text = "TIME:   " + helper.ToString() ;
    }
    string LeadingZero(int n)
    {
        return n.ToString().PadLeft(2, '0');
    }
}