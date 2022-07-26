using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName = "";
    public int playerScore = 0;

    public string bestPlayerName = "";
    public int bestPlayerScore = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayer();
    }

    class BestPlayer
    {
        public string name = "";
        public int score = 0;

        public BestPlayer(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
    }

    public void SavePlayer()
    {        
        BestPlayer player = new BestPlayer(playerName, playerScore);

        string json = JsonUtility.ToJson(player);

        File.WriteAllText($"E:/UnityProjects/gamesave.json", json);
        //File.WriteAllText(Application.persistentDataPath + "/gamesave.json", json);
    }

    public void LoadPlayer()
    {
        string path = $"E:/UnityProjects/gamesave.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BestPlayer player = JsonUtility.FromJson<BestPlayer>(json);

            bestPlayerName = player.name;
            bestPlayerScore = player.score;
        }
    }
}
