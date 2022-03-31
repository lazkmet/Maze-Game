using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    private LevelManager manager;
    public int selectedLevel;
    public Color gray;
    private Color original;
    public Button confirmButton;
    public Button[] selectionButtons = { };
    private void Awake()
    {
        manager = FindObjectOfType<LevelManager>();
        original = confirmButton.image.color;
    }
    private void OnEnable()
    {
        Reset();
    }
    private void Reset()
    {
        selectedLevel = -1;
        confirmButton.enabled = false;
        confirmButton.image.color = gray;
        HideAllButSelected();
    }
    public void HideAllButSelected() {
        for (int i = 0; i < selectionButtons.Length; i++) {
            if (i == selectedLevel)
            {
                selectionButtons[i].image.color = Color.white;
            }
            else
            {
                selectionButtons[i].image.color = gray;
            }
        }
    }
    public void SelectLevel(int levelIndex) {
        selectedLevel = levelIndex;
        EnableConfirm();
        HideAllButSelected();
    }
    private void EnableConfirm() {
        confirmButton.enabled = true;
        confirmButton.image.color = original;
    }
    public void Confirm() {
        if (selectedLevel > -1) {
            manager.StartLevel(selectedLevel);
        }
    }
}
