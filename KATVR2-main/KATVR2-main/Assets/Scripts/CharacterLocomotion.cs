//���ꉽ�ɂ��g���Ă��܂���
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform playerCamera; // プレイヤーのカメラのトランスフォーム
    public float moveSpeed = 3f; // 移動速度
    public float sensitivity = 2f; // 感度

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        // CharacterControllerを取得
        characterController = GetComponent<CharacterController>();

        // 変更点: playerCameraが割り当てられていない場合、自動でMain Cameraを割り当てる
        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = playerCamera.forward;
        forward.y = 0; // 垂直の成分を無視する
        forward.Normalize();

        // カメラの方向に基づいて移動方向を計算する
        Vector3 moveDirection = forward * moveSpeed * Time.deltaTime;

        // CharacterControllerを使って移動する
        characterController.Move(moveDirection);

        // カメラの回転に基づいてキャラクターを回転させる
        float horizontalRotation = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, horizontalRotation, 0);
    }
}
