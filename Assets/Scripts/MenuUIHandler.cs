using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System.IO;

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI BestScoreText;
    public TextMeshProUGUI PlayerNameText;
    // Start is called before the first frame update
    void Start()
    {
        ReadBestScore();
    }

    void ReadBestScore()
    {
        string json;
        string filename = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(filename))
        {
            json = File.ReadAllText(filename);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            BestScoreText.text = $"Best Score : {data.Name} : {data.Score}";
        }
    }
    public void StartNew()
    {
        if (GameManager.Instance.PlayerName.Trim() == "")
        {
            Debug.Log("«Î ‰»Îƒ„µƒ√˚◊÷");
            return;
        }
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void SavePlayerName()
    {
        GameManager.Instance.PlayerName = PlayerNameText.text;
    }
}
