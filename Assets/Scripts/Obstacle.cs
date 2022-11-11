using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private Rigidbody obstacleRigid;
    private float lastTime;
    private float timeInterval = 4f;
    private float speed = 100f;
    private float direction;

    void Start()
    {
        obstacleRigid = GetComponent<Rigidbody>();
        lastTime = Time.time; //ゲームを開始してからの経過時間を記憶する
        direction = -1.0f;
    }

    void FixedUpdate()
    {
        if(Time.time >= lastTime + timeInterval)
        {
            lastTime = Time.time;
            direction *= -1.0f;
            obstacleRigid.velocity = Vector3.zero;
        }

        Vector3 obstacleRight = obstacleRigid.transform.right;
        Vector3 moveVector = speed * (obstacleRight * direction);
        moveVector.y = 0f;
        moveVector.z = 0f;
        obstacleRigid.AddForce(moveVector,ForceMode.Impulse);
    }
}
//p125にコードが載っている