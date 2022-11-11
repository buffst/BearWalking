using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneController : MonoBehaviour
{
    public static int score = 0;
    private Text scoreText;

    void Start()
    {
        GameObject gameScoreText = GameObject.Find("ScoreText");
        scoreText = gameScoreText.GetComponent<Text>();
        score = 0;
    }

   public void OnFailed()
    {
        Invoke("OnLoadGameScene", 1.5f);
    } //1.5秒経ってからOnLoadGameSceneメソッドを呼びだす

    private void OnLoadGameScene()
    {
        SceneManager.LoadScene("GameScene"); //GameSceneを読み込む
    }

    public void AddScore(int num)
    {
        score += num;
        scoreText.text = score.ToString();
    }

    public void OnGoal()
    {
        GameObject bear = GameObject.Find("Bear@Walking");
        BearController script = bear.GetComponent<BearController>();
        script.OnStop();
        Invoke("OnLoadResultScene", 1.5f);
    }

    private void OnLoadResultScene()
    {
        SceneManager.LoadScene("ResultScene");
    }
}