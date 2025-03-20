using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
  
    private int currentHealth;
    public string targetSceneName = "GameOver"; // �ړ���̃V�[����

    [SerializeField]
    private Text healthText; // UI Text�R���|�[�l���g���Q�Ƃ��邽�߂̃t�B�[���h
    void Start()
    {
        Debug.Log("player�Ăяo��");
        currentHealth = maxHealth;
        UpdateHealthUI();
        // �����̗̑͂�\��
    }



    public void playerTakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"�v���C���[���_���[�W���󂯂܂���: {damage} ���݂̗̑�: {currentHealth}");
        UpdateHealthUI(); // �_���[�W���󂯂����UI�X�V


        if (currentHealth <= 0)
        {
            playerDie();
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    private void playerDie()
    {
        Debug.Log("�v���C���[�����S���܂���");
        // �v���C���[�����S�����ۂ̏����������ɒǉ�
        SceneManager.LoadScene(targetSceneName);
    }
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = currentHealth.ToString();
            if (currentHealth <= 30)
            {
                healthText.color = Color.red;
            }
        }
        else
        {
            Debug.LogError("Health Text UI ���ݒ肳��Ă��܂���BInspector�Őݒ肵�Ă��������B");
        }
    }


}