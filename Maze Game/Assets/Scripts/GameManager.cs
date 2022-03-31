using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MenuManager))]
public class GameManager : MonoBehaviour
{
    private GameObject ball;
    private Vector3 ballPos;
    private RotationalMovement maze;
    public Timer tim { get; private set; }
    public LevelManager levels { get; private set; }
    public MenuManager menus;
    [HideInInspector]
    public bool pausable = false;
    private void Awake()
    {
        ball = GameObject.Find("Ball");
        ballPos = ball.transform.position;
        maze = FindObjectOfType<RotationalMovement>();
        tim = FindObjectOfType<Timer>();
        levels = FindObjectOfType<LevelManager>();
        menus = GetComponent<MenuManager>();
    }
    private void Start()
    {
        Reset();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && pausable) {
            menus.TogglePause();
        }
    }
    public void Win() {
        Time.timeScale = 0;
        tim.Pause();
        menus.SetActiveScreen(1);
    }
    public void Reset()
    {
        pausable = true;
        ball.transform.position = ballPos;        
        maze.Reset();
        tim.Reset();
        menus.Reset();
        foreach (LoopingMusic l in FindObjectsOfType<LoopingMusic>()) {
            l.Reset();
        }
        foreach (OneWayDoor o in FindObjectsOfType<OneWayDoor>()) {
            o.Reset();
        }
    }
    public void Next() {
        levels.NextLevel();
    }
}
