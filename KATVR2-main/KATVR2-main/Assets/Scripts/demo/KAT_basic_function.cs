using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAT_basic_function : MonoBehaviour
{
    private Vector3 speed;
    private Quaternion rotation;
    void Start()
    {
    }
    void Update()
    {
        var data = KATNativeSDK.GetWalkStatus(); // KATVRライブラリへのアクセス
        speed = data.moveSpeed; // 歩行速度（x,y,z）の取得
        rotation = data.bodyRotationRaw; // 回転（x,y,z,w）の取得

        // デバッグログを追加して確認
        Debug.Log("speed: " + speed);
        Debug.Log("rotation: " + rotation);
        Debug.Log("rotation (x): " + rotation.x);
        Debug.Log("rotation (y): " + rotation.y);
        Debug.Log("rotation (z): " + rotation.z);
        Debug.Log("rotation (w): " + rotation.w);
    }

}
