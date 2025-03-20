using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;     //移動速度を設定
    private Vector3 movement;   //移動方向を設定
    private CharacterController controller;
    public float rotationSpeed = 5.0f; //回転速度

    public GameObject cameraC;  //プレイヤーの視点方向を取得
    private Vector3 moveDir = Vector3.zero;     //移動方向と速度を管理する
    private float gravity = 9.8f;   //重力

    private float moveH;    //x方向
    private float moveV;    //z方向
    private float rotateH;  //x回転
    private float rotateV;  //y回転
    void Start()
    {
        controller = GetComponent<CharacterController>();   //CharacterControllerコンポーネントを取得し、controller変数に代入
    }

    void Update()
    {
        moveH = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).x;     //VRの入力を受け付け
        moveV = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick).y;
        movement = new Vector3(moveH, 0, moveV);    //移動ベクトルを作成

        // 右スティックでカメラの回転を取得
        rotateH = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x;
        rotateV = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).y;



        Vector3 desiredMove = cameraC.transform.forward * movement.z + cameraC.transform.right * movement.x;
        moveDir.x = desiredMove.x * speed;
        moveDir.z = desiredMove.z * speed;
        moveDir.y -= gravity * Time.deltaTime;  //重力をずっと適応

        controller.Move(moveDir * Time.deltaTime); //移動する

        // プレイヤー全体を回転させる
        transform.Rotate(0, rotateH * rotationSpeed, 0);  // 水平方向の回転

        // カメラの垂直方向の回転を制御
        cameraC.transform.Rotate(-rotateV * rotationSpeed, 0, 0); // 垂直方向の回転
    }
}
