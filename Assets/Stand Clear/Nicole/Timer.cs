using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainingTime;
    public GameObject EndGame;
    public int barrierCount = 0;
    public int WinAmount = 2;
    public Transform Barriers;

    void Update()
    {
        if (remainingTime > 0) 
        {
        
            remainingTime-= Time.deltaTime;

        
        }
        else if (remainingTime < 0) 
        {
        
            remainingTime = 0;
            if (Barriers.childCount < WinAmount)
            {
                EndGame.SetActive(true);
            }
            else
            {

            }

        }

       
        
        
        
        
        
        
        

        
            remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}