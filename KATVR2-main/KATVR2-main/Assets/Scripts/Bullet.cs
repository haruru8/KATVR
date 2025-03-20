using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Counter counterScript;  // �J�E���^�[�X�N���v�g�ւ̎Q��
    [SerializeField] private float destroyTimer = 2f; // �����Ŕj�󂳂�鎞��

    void Start()
    {

        // ��莞�Ԍ�Ɏ����Ŕj�󂷂�^�C�}�[��ݒ�
        Destroy(gameObject, destroyTimer);
    }

    void OnCollisionEnter(Collision collision)
    {


        // �e�ۂ̔j��
        Destroy(gameObject);
    }
}
