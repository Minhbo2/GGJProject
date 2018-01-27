using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


// Basic data container for saving and loading
[Serializable]
public class Data
{
    public int s_Score;
    public int s_Level;
    public float s_CurrentHealth;

    public Data(int score, int level, float health)
    {
        s_Score = score;
        s_Level = level;
        s_CurrentHealth = health;
    }
}



public class DataUtility  {



    // give a file type to load 
    public static T LoadData<T>(string FileType)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + FileType, FileMode.Open);
        T LoadedData = (T)bf.Deserialize(file);
        file.Close();

        return LoadedData;
    }



    // give a file type to save
    public static void SavingData<T>(T SaveFile, string FileType)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + FileType);
        bf.Serialize(file, SaveFile);
        file.Close();
    }

}
