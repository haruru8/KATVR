using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeightAdjuster : MonoBehaviour
{
    public float fixedHeight = 5; // 固定したい高さ（メートル単位）
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = this.transform; // メインカメラのTransformを取得

        // カメラの位置を更新して高さを固定
        Vector3 newPosition = cameraTransform.position;
        newPosition.y = fixedHeight;
        cameraTransform.position = newPosition;
    }

    void Update()
    {
        // Updateで高さを再調整する場合があれば、ここで処理を追加
    }
}
