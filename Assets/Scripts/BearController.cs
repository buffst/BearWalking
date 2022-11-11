using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearController : MonoBehaviour
{
    private float speed = 3.0f;
    private float verticalInput = 0f;
    private Rigidbody bearRigidbody;
    private bool isStop;

    void Start()
    {
        bearRigidbody = GetComponent<Rigidbody>(); //Rigidbodyコンポーネントを取得する
        isStop = false;
    }

    void Update()
    {
        if (isStop)
        {
            return;
        }

        if(transform.position.y < 0.5) //落ちたか判定
        { //落ちた場合の処理
            isStop = true;
            GameObject gameSceneController = GameObject.Find("GameSceneController");
            GameSceneController script =
                gameSceneController.GetComponent<GameSceneController>();
            script.OnFailed(); //GameSceneControllerスクリプトのOnFailedメソッドを呼出
        }
        else
        {
            verticalInput = Input.GetAxis("Vertical"); //上下キーを押したときの値を取得する

            if (Input.GetKey("right")) //右キーが押されたか調べる
            {
                bearRigidbody.transform.Rotate(0, 5, 0); //進行方向右に5度回転
            }
            else if (Input.GetKey("left"))
            {
                bearRigidbody.transform.Rotate(0, -5, 0);
            }
        }
        
    }

    void FixedUpdate()
    {
        if (isStop)
        {
            return;
        }

        if ( bearRigidbody.velocity.sqrMagnitude < 5.0f ) //移動速度が5.0より小さいか確認
        {
            Vector3 bearForward = bearRigidbody.transform.forward;
            Vector3 moveVector = speed * (bearForward * verticalInput); //力のかけ方を計算
            moveVector.y = 0;
            bearRigidbody.AddForce(moveVector,ForceMode.Impulse); //力を加えて動かす
        }
    }

    public void OnStop()
    {
        isStop = true;
    }
}