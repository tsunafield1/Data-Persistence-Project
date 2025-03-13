using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using TMPro;


#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI HighScoreText;

    private void Start()
    {
        HighScoreText.text = $"Best Score: {DataManager.Instance.highScorePlayerName}: {DataManager.Instance.highScore}";
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void OnNameEndEdit(string newName)
    {
        DataManager.Instance.playerName = newName;
    }
}
