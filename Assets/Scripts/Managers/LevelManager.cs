using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int lives = 10;
    public int TotalLives { get; set; }

    private void Start()
    {
        TotalLives = lives;
    }
    private void ReduceLives()
    {
        Debug.Log("KUNTERI TTEN");
        TotalLives--;
        if (TotalLives <= 0)
        {
            TotalLives = 0;
            //Game Over
        }
    }
    
    private void OnEnable()
    {
        Enemy.OnEndReached += ReduceLives;
    }

    private void OnDisable()
    {
        Enemy.OnEndReached -= ReduceLives;
    }

}
