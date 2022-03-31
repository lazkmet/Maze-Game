using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class GoalZone : MonoBehaviour
{
    private RotationalMovement maze;
    private void Awake()
    {
        maze = FindObjectOfType<RotationalMovement>();
    }
    private void OnTriggerEnter(Collider other)
    {
        maze.enabled = false;
        FindObjectOfType<GameManager>().tim.Pause();
        Invoke(nameof(Win), 1.5f);
    }
    private void Win() {
        FindObjectOfType<GameManager>().Win();
    }
}
