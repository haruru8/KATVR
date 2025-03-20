using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KAT_cube_move : MonoBehaviour
{
    private Vector3 speed;
    // private Quaternion rotation; // �R�����g�A�E�g�܂��͍폜���܂�

    void Start()
    {
    }

    void Update()
    {
        var data = KATNativeSDK.GetWalkStatus(); // KATVR���C�u�����ւ̃A�N�Z�X
        speed = data.moveSpeed * 5; // ���s���x�ix,y,z�j�̎擾

        // x���W��z���W�̕������t�ɂ���
        speed.x = -speed.x;
        speed.z = -speed.z;
        
        // rotation = data.bodyRotationRaw; // �R�����g�A�E�g�܂��͍폜���܂�

        this.transform.Translate(speed * Time.deltaTime, Space.Self); // �ړ�
        // this.transform.rotation = rotation; // �R�����g�A�E�g�܂��͍폜���܂�

       // Debug.Log("Speed: " + speed.ToString()); // Rotation: " + rotation.eulerAngles.ToString() ���폜
    }
}
