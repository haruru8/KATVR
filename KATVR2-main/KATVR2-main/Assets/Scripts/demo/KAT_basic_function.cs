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
        var data = KATNativeSDK.GetWalkStatus(); // KATVR���C�u�����ւ̃A�N�Z�X
        speed = data.moveSpeed; // ���s���x�ix,y,z�j�̎擾
        rotation = data.bodyRotationRaw; // ��]�ix,y,z,w�j�̎擾

        // �f�o�b�O���O��ǉ����Ċm�F
        Debug.Log("speed: " + speed);
        Debug.Log("rotation: " + rotation);
        Debug.Log("rotation (x): " + rotation.x);
        Debug.Log("rotation (y): " + rotation.y);
        Debug.Log("rotation (z): " + rotation.z);
        Debug.Log("rotation (w): " + rotation.w);
    }

}
