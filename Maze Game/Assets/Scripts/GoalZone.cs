using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GoalZone : MonoBehaviour
{
    private RotationalMovement maze;
    private GameManager manager;
    private void Awake()
    {
        maze = FindObjectOfType<RotationalMovement>();
        manager = FindObjectOfType<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        maze.enabled = false;
        manager.tim.Pause();
        manager.pausable = false;
        Invoke(nameof(Win), 0.8f);
    }
    private void Win() {
        manager.Win();
    }
}
