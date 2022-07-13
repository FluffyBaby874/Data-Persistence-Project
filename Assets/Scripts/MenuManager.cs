using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public InputField inputField;

    public Text MenuBestScore;

    void Start()
    {
        inputField = GameObject.Find("Enter Name").GetComponent<InputField>();
        MenuBestScore.text = $"Best Score : {MainMenuManager.Instance.bestScoreName} : {MainMenuManager.Instance.b_Score}";
    }

    public void NameChecker()
    {
        MainMenuManager.Instance.yourName = inputField.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        MainMenuManager.Instance.SaveBestScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void EndAndSave()
    {
        if (UnityEditor.EditorApplication.isPlaying == false)
        {
            MainMenuManager.Instance.SaveBestScore();
        }
    }

    public void ResetBestScore()
    {
        MainMenuManager.Instance.b_Score = 0;
        MainMenuManager.Instance.bestScoreName = "";
        MenuBestScore.text = $"Best Score : {MainMenuManager.Instance.bestScoreName} : {MainMenuManager.Instance.b_Score}";
        MainMenuManager.Instance.SaveBestScore();
    }
}
