using System;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string highScorePlayerName;
    public int highScore;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int highScore;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            LoadHighScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool IsNewHighScore(int newScore)
    {
        if (newScore > highScore)
        {
            highScorePlayerName = playerName;
            highScore = newScore;
            SaveHighScore();

            return true;
        }
        return false;
    }

    private void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.playerName = highScorePlayerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/highscore.json", json);
    }

    private void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/highscore.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.playerName;
            highScore = data.highScore;
        }
    }
}
