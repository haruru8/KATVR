using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using OscJack;

public class OSC_stream : MonoBehaviour
{
    private Vector3 speed;//���s���x
    private Quaternion rotation;//��]
    private float speed2;//���s�̑����i��Βl�j
    private int isWalk = 0;//0�F��~�A1:���s�A2�F���s
    public int thr_walk_run = 8;//���s�ƃ����j���O�̋��E��
    [SerializeField] string ipAddress = "192.168.10.32";//���M���IP�A�h���X
    [SerializeField] int port = 9000;//Port�ԍ�
    OscClient client;//Client�̕ϐ��錾
    [SerializeField] float sendInterval = 0.025f;// OSC���b�Z�[�W�̑��M�Ԋu�i�b�j
    private float lastSendTime = 0f;

    void Start()
    {
        client = new OscClient(ipAddress, port);//Client�̋N��
    }

    void OnDestroy()
    {
        client.Dispose();//Client�̒�~
    }


    void Update()
    {
        var data = KATNativeSDK.GetWalkStatus();//KATVR���C�u�����ւ̃A�N�Z�X
        speed = data.moveSpeed;//���s���x�ix,y,z�j�̎擾
        rotation = data.bodyRotationRaw;//��]�ix,y,z,w�j�̎擾
        this.transform.Translate(speed * Time.deltaTime, Space.Self);//�ړ�
        this.transform.rotation = rotation;//��]
        speed2 = speed.magnitude;//�����̐�Η�
        if (speed2 > 0)
        {
            if (speed2 >= thr_walk_run)//������臒l�𒴂����ꍇ
            {
                isWalk = 2;//���s
            }
            else
            {
                isWalk = 1;//���s
            }
        }
        else
        {
            isWalk = 0;//��~
        }
        // ���Ԋu��OSC���b�Z�[�W�𑗐M����
        if (Time.time - lastSendTime >= sendInterval)
        {
            client.Send("/KATVR/position", this.transform.position.x, this.transform.position.y, this.transform.position.z);
            client.Send("/KATVR/rotation", this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
            client.Send("/KATVR/status", isWalk);
            client.Send("/KATVR/speed", speed.x, speed.y, speed.z);
            lastSendTime = Time.time;
        }
    }
}


