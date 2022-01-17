using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;

public class DataStorageManager : MonoBehaviour
{
    public static DataStorageManager istance;
    const string FILE_PATH = "/scoreInfo.dat";


    private void Awake()
    {
        istance = this;
    }

    public static void Save(int score)
    {
        ScoresData data;
        data = Load();
       
        using (var file = File.Open(Application.persistentDataPath + FILE_PATH, FileMode.OpenOrCreate))
        {
            Score scoreObj = new Score();
            scoreObj.score = score;
            BinaryFormatter bf = new BinaryFormatter();

            data.getScores().Add(scoreObj);

            bf.Serialize(file, data);

            file.Close();
            Debug.Log("Game data saved!");
        }

  

     
     
     
    }

    public static ScoresData Load()
    {
        ScoresData data = new ScoresData();
        if (File.Exists((Application.persistentDataPath + FILE_PATH)))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + FILE_PATH, FileMode.Open);
            data = bf.Deserialize(file) as ScoresData;
            file.Close();
            Debug.Log("Game data loaded!");
        }
        return data;
    }
}

[Serializable]
public class ScoresData 
{
    [SerializeField] private List<Score> scores;

    public ScoresData()
    {
        this.scores = new List<Score>();
    }
    private void setScores(List<Score> scores)
    {
        this.scores = scores;
    }

    public List<Score> getScores()
    {
        return this.scores;
    }
}



[Serializable]
public class Score
{
    [SerializeField]  public int score { get; set; }
}