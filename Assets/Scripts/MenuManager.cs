using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public string playerName;
    public int score;

    public string _playerName;
    public int _score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetNameScore(string name, int score)
    {
        _playerName = name;
        _score = score;
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.playerName = _playerName;
        data.score = _score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            playerName = data.playerName;
            score = data.score;
        }
    }

}

[System.Serializable]
class PlayerData
{
    public string playerName;
    public int score;
}
