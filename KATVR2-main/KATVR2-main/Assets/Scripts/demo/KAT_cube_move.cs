using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAT_cube_move : MonoBehaviour
{
    private Vector3 speed;
    // private Quaternion rotation; // コメントアウトまたは削除します

    void Start()
    {
    }

    void Update()
    {
        var data = KATNativeSDK.GetWalkStatus(); // KATVRライブラリへのアクセス
        speed = data.moveSpeed * 5; // 歩行速度（x,y,z）の取得

        // x座標とz座標の方向を逆にする
        speed.x = -speed.x;
        speed.z = -speed.z;
        
        // rotation = data.bodyRotationRaw; // コメントアウトまたは削除します

        this.transform.Translate(speed * Time.deltaTime, Space.Self); // 移動
        // this.transform.rotation = rotation; // コメントアウトまたは削除します

       // Debug.Log("Speed: " + speed.ToString()); // Rotation: " + rotation.eulerAngles.ToString() を削除
    }
}
