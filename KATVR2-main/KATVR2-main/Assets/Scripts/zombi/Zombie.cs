using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private int maxHp = 3; // �]���r�̍ő�HP

    private int currentHp;
    [SerializeField]
    private int damage = 1; // ���̃_���[�W�Ō��炷HP�̗�
    [SerializeField]
    private int playerdamage = 10;
    [SerializeField]
    private Slider hpSlider; // HP�o�[�̃X���C�_�[

    private bool canAttack = true; // �_���[�W���󂯂��邩�ǂ���
    [SerializeField]
    private float attackCooldown = 2f; // �_���[�W���󂯂���̃N�[���_�E������


    [SerializeField]
    private float attackRange = 2.0f;
    private Transform playerTransform;
    private Player player;

    void Start()
    {
        Debug.Log("zombie�����Ă�");
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            Debug.Log("�v���C���[��������܂���: " + playerObject.name);
            playerTransform = playerObject.transform;
            player = playerTransform.GetComponent<Player>();
        }
        else
        {
            Debug.LogError("Player�^�O���t�����I�u�W�F�N�g���V�[�����Ɍ�����܂���ł����B");
        }

        currentHp = maxHp;

        if (hpSlider != null)
        {
            hpSlider.maxValue = 1;
            hpSlider.value = (float)currentHp / (float)maxHp;
   
        }
        else
        {
            Debug.LogError("hpSlider ���ݒ肳��Ă��܂���BInspector�Őݒ肵�Ă��������B");
        }
    }

    void Update()
    {
        if (playerTransform == null)
        {
            return; // �v���C���[��������Ȃ��ꍇ�͏������s��Ȃ�
        }

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        Debug.Log("�v���C���[�Ƃ̋���: " + distanceToPlayer);

        if (distanceToPlayer <= attackRange && canAttack)
        {
            Debug.Log("�v���C���[�ɍU�����܂��B");
            AttackPlayer();
        }
        else
        {
            Debug.Log("�v���C���[�͍U���͈͊O�ł��B����: " + distanceToPlayer);
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false; // �U���𖳌��ɂ���
        yield return new WaitForSeconds(attackCooldown); // �w�肵�����ԑ҂�
        canAttack = true; // �U�����ĂїL���ɂ���
    }
    public void TakeDamage()
    {

        currentHp -= damage;
        if (currentHp < 0)
        {
            currentHp = 0;
        }
        hpSlider.value = (float)currentHp / (float)maxHp;  // �_���[�W���󂯂邲�Ƃ�HP�o�[������


        Debug.Log($"{gameObject.name} ���q�b�g����܂����B���݂�HP: {currentHp}");

        if (currentHp <= 0)
        {
            Die();
        }
    }
   

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log($"{gameObject.name} ���j�󂳂�܂����B");
        if (hpSlider != null)
        {
            Destroy(hpSlider.gameObject); // HP�o�[���폜
        }
    }

    private void AttackPlayer()
    {
        if (canAttack)
        {
            player.playerTakeDamage(playerdamage);
            Debug.Log("�v���C���[���]���r�ɋ߂Â���A�_���[�W���󂯂܂���");
            StartCoroutine(AttackCooldown()); // �N�[���_�E�����J�n
        }
    }
}