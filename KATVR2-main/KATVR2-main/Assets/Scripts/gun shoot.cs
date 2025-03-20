using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunShoot : MonoBehaviour
{
    // 射線の距離
    public float rayDistance = 10.0f;

    // Update is called once per frame
    void Update()
    {
        // 右コントローラーのトリガーボタンが押された場合
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
        {
            // カメラの正面から射線を出す
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                // 当たったオブジェクトの座標を表示
                Debug.Log(hit.collider.gameObject.transform.position);
            }
            // 射線を表示する
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red, 2.0f);
        }
    }
}
