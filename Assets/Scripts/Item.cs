using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        GameObject gameSceneController = GameObject.Find("GameSceneController");
        GameSceneController script =
            gameSceneController.GetComponent<GameSceneController>();
        script.AddScore(100); //スコアを加算する処理を呼び出す

        Destroy(gameObject); //衝突されたゲームオブジェクトを削除
    }
}