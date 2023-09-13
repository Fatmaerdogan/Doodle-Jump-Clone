using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public GameObject GameEndPanel;
    public TMP_Text ScoreText, GameEndScoreText;
    private void Start()
    {
        GameManager.instance.GameEndActive += PanelSet;
        GameManager.instance.Score += ScoreSet;
    }
    public void PanelSet()
    {
        GameEndPanel.SetActive(true);

    }
    public void ScoreSet(int _score)
    {

        ScoreText.text=GameEndScoreText.text=_score.ToString();

    }
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}