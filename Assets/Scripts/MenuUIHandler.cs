using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField _input;
    public TMP_Text _labelBestScore;
    private const string labelText = "Best Score: ";
    private void Start()
    {
        _input.text = DataUser.Instance.getNamePlayer();
        _labelBestScore.text = labelText + DataUser.Instance.getScorePlayer().ToString() + " " + DataUser.Instance.getNamePlayer();
    }
    public void StartNew()
    {
        DataUser.Instance.SetPlayerName(_input.text);
        DataUser.Instance.SaveDataPlayer();
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
            Application.Quit(); // original code to quit Unity player
    #endif
        DataUser.Instance.SaveDataPlayer();
    }

}
