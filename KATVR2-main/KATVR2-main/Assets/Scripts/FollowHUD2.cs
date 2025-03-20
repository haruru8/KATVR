using UnityEngine;

public class FollowHUD2 : MonoBehaviour
{
    public Transform headTransform; // プレイヤーのカメラTransform

    void Update()
    {
        // Canvasの位置と回転をカメラに合わせる
        transform.position = headTransform.position;
        transform.rotation = headTransform.rotation;
    }
}
