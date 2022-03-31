using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public string[] levelNames;
    public int currentLevel { get; private set; } = -1;
    public int numLevels { get; private set; } = -1;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        numLevels = levelNames.Length;
    }
    public void StartLevel(int index){
        if (index > -1 && index < levelNames.Length) {
            currentLevel = index;
            SceneManager.LoadScene(levelNames[index]);          
        }
    }
    public void NextLevel() {
        int newLevel = currentLevel + 1;
        StartLevel(newLevel);
    }
}
