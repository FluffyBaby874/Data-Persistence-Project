using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager Instance;

    public string yourName;

    public string bestScoreName;

    public int b_Score;

    public void Awake()
    {

        if(Instance  != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadBestScore();
    }

    [System.Serializable]
    public class SaveData
    {
        public int b_Score;
        public string bestScoreName;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.b_Score = b_Score;
        data.bestScoreName = bestScoreName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(data);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            b_Score = data.b_Score;
            bestScoreName = data.bestScoreName;
            Debug.Log(data);
        }
    }
}
