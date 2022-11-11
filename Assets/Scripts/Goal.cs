using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        GameObject controller = GameObject.Find("GameSceneController");
        GameSceneController script = controller.GetComponent<GameSceneController>();
        script.OnGoal();
    }
}