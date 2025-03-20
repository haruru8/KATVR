using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���}�l�[�W���[���g�p���邽�߂ɕK�v

public class SceneTransition : MonoBehaviour
{
    public string targetSceneName = "GameScene"; // �ړ���̃V�[����

    // �g���K�[�ɐG�ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    void OnTriggerEnter(Collider other)
    {
        // �C�ӂ̏������`�F�b�N�i�Ⴆ�΁A����̃^�O�����I�u�W�F�N�g�ɂ̂ݔ����j
        if (other.CompareTag("Player")) // "Player"�^�O�̃I�u�W�F�N�g�ƏՓ˂����ꍇ
        {
            SceneManager.LoadScene(targetSceneName); // �w�肵���V�[���Ɉړ�
        }
    }
}
