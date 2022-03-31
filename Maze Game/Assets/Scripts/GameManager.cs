using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MenuManager))]
public class GameManager : MonoBehaviour
{
    private GameObject ball;
    private Vector3 ballPos;
    private RotationalMovement maze;
    public Timer tim;
    public LevelManager levels;
    private void Awake()
    {
        ball = GameObject.Find("Ball");
        ballPos = ball.transform.position;
        maze = FindObjectOfType<RotationalMovement>();
        tim = FindObjectOfType<Timer>();
        levels = FindObjectOfType<LevelManager>();
        Reset();
    }
    public void Win() { 
        //display victory screen
    }
    public void Reset()
    {
        ball.transform.position = ballPos;
        maze.Reset();
        tim.Reset();
    }
    public void Next() {
        levels.NextLevel();
    }
}
