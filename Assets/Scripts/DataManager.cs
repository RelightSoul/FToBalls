using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string PlayerName { get; set; } = "";
    public int PlayerScore { get; set; } = 0;
    private const int playersArrayCount = 5;
    public PlayersData playersData;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [Serializable]
    public class BestPlayer : IComparable<BestPlayer>
    {
        public string name = "";
        public int score = 0;

        public int CompareTo(BestPlayer player)
        {
            if (player is null)
                throw new ArgumentException();
            else
                return score.CompareTo(player.score);
        }
    }    

    [Serializable]
    public class PlayersData
    {
        public BestPlayer[] playersArray;

        public PlayersData()
        {
            playersArray = new BestPlayer[playersArrayCount];
        }
    }

    public void SaveData()
    {
        if (PlayerScore > playersData.playersArray[playersArrayCount - 1].score)
        {
            playersData.playersArray[playersArrayCount - 1].score = PlayerScore;
            playersData.playersArray[playersArrayCount - 1].name = PlayerName;

            PlayersData data = playersData;
            string json = JsonUtility.ToJson(data);
            File.WriteAllText($"E:/UnityProjects/datasave.json", json);
        } 
    }

    public void LoadData()
    {
        string path = $"E:/UnityProjects/datasave.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playersData = JsonUtility.FromJson<PlayersData>(json);
            System.Array.Sort<BestPlayer>(playersData.playersArray);
            System.Array.Reverse<BestPlayer>(playersData.playersArray);
        }
    }

    public string BestPlayersList()
    {
        BestPlayer[] bests = playersData.playersArray;
        string data = "\tTop5";
        foreach (BestPlayer player in bests)
        {
            data += $"\n{player.name} {player.score}";
        }
        return data;
    }
}
