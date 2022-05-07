using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataUser : MonoBehaviour
{
    public static DataUser Instance;
    private string _playerName = "";
    private int _score = 0;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadDataPlayer();
    }

    public string getNamePlayer()
    {
        return _playerName;
    }

    public int getScorePlayer()
    {
        return _score;
    }

    public void SetPlayerName(string playerName)
    {
        _playerName = playerName;
    }

    public void SetScorePlayer(int score)
    {
        _score = score;
    }

    [System.Serializable]
    class DataJsonSaved
    {
        public string playerName;
        public int scorePlayer;
    }

    public void SaveDataPlayer ()
    {
        DataJsonSaved dataJsonSaved = new DataJsonSaved();
        dataJsonSaved.playerName = this._playerName;
        dataJsonSaved.scorePlayer = this._score;

        string json = JsonUtility.ToJson(dataJsonSaved);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);

    }

    public void LoadDataPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            DataJsonSaved data = JsonUtility.FromJson<DataJsonSaved>(json);

            this._playerName = data.playerName;
            this._score = data.scorePlayer;
        }
    }
}