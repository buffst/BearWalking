using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultSceneController : MonoBehaviour
{
    void Start()
    {
        GameObject textObject = GameObject.Find("ScoreText");
        Text scoreText = textObject.GetComponent<Text>();
        scoreText.text = GameSceneController.score.ToString();
    }

    public void OnGameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
