using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeightAdjuster : MonoBehaviour
{
    public float fixedHeight = 5; // �Œ肵���������i���[�g���P�ʁj
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = this.transform; // ���C���J������Transform���擾

        // �J�����̈ʒu���X�V���č������Œ�
        Vector3 newPosition = cameraTransform.position;
        newPosition.y = fixedHeight;
        cameraTransform.position = newPosition;
    }

    void Update()
    {
        // Update�ō������Ē�������ꍇ������΁A�����ŏ�����ǉ�
    }
}
