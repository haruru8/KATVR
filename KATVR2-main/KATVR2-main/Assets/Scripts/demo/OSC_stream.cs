using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OscJack;

public class OSC_stream : MonoBehaviour
{
    private Vector3 speed;//歩行速度
    private Quaternion rotation;//回転
    private float speed2;//歩行の速さ（絶対値）
    private int isWalk = 0;//0：停止、1:歩行、2：走行
    public int thr_walk_run = 8;//歩行とランニングの境界線
    [SerializeField] string ipAddress = "192.168.10.32";//送信先のIPアドレス
    [SerializeField] int port = 9000;//Port番号
    OscClient client;//Clientの変数宣言
    [SerializeField] float sendInterval = 0.025f;// OSCメッセージの送信間隔（秒）
    private float lastSendTime = 0f;

    void Start()
    {
        client = new OscClient(ipAddress, port);//Clientの起動
    }

    void OnDestroy()
    {
        client.Dispose();//Clientの停止
    }


    void Update()
    {
        var data = KATNativeSDK.GetWalkStatus();//KATVRライブラリへのアクセス
        speed = data.moveSpeed;//歩行速度（x,y,z）の取得
        rotation = data.bodyRotationRaw;//回転（x,y,z,w）の取得
        this.transform.Translate(speed * Time.deltaTime, Space.Self);//移動
        this.transform.rotation = rotation;//回転
        speed2 = speed.magnitude;//速さの絶対量
        if (speed2 > 0)
        {
            if (speed2 >= thr_walk_run)//速さが閾値を超えた場合
            {
                isWalk = 2;//走行
            }
            else
            {
                isWalk = 1;//歩行
            }
        }
        else
        {
            isWalk = 0;//停止
        }
        // 一定間隔でOSCメッセージを送信する
        if (Time.time - lastSendTime >= sendInterval)
        {
            client.Send("/KATVR/position", this.transform.position.x, this.transform.position.y, this.transform.position.z);
            client.Send("/KATVR/rotation", this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            client.Send("/KATVR/status", isWalk);
            client.Send("/KATVR/speed", speed.x, speed.y, speed.z);
            lastSendTime = Time.time;
        }
    }
}


