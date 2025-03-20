using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private int maxHp = 3; // ゾンビの最大HP

    private int currentHp;
    [SerializeField]
    private int damage = 1; // 一回のダメージで減らすHPの量
    [SerializeField]
    private int playerdamage = 10;
    [SerializeField]
    private Slider hpSlider; // HPバーのスライダー

    private bool canAttack = true; // ダメージを受けられるかどうか
    [SerializeField]
    private float attackCooldown = 2f; // ダメージを受けた後のクールダウン時間


    [SerializeField]
    private float attackRange = 2.0f;
    private Transform playerTransform;
    private Player player;

    void Start()
    {
        Debug.Log("zombie動いてる");
        GameObject playerObject = GameObject.FindWithTag("Player");

        if (playerObject != null)
        {
            Debug.Log("プレイヤーが見つかりました: " + playerObject.name);
            playerTransform = playerObject.transform;
            player = playerTransform.GetComponent<Player>();
        }
        else
        {
            Debug.LogError("Playerタグが付いたオブジェクトがシーン内に見つかりませんでした。");
        }

        currentHp = maxHp;

        if (hpSlider != null)
        {
            hpSlider.maxValue = 1;
            hpSlider.value = (float)currentHp / (float)maxHp;
   
        }
        else
        {
            Debug.LogError("hpSlider が設定されていません。Inspectorで設定してください。");
        }
    }

    void Update()
    {
        if (playerTransform == null)
        {
            return; // プレイヤーが見つからない場合は処理を行わない
        }

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        Debug.Log("プレイヤーとの距離: " + distanceToPlayer);

        if (distanceToPlayer <= attackRange && canAttack)
        {
            Debug.Log("プレイヤーに攻撃します。");
            AttackPlayer();
        }
        else
        {
            Debug.Log("プレイヤーは攻撃範囲外です。距離: " + distanceToPlayer);
        }
    }

    private IEnumerator AttackCooldown()
    {
        canAttack = false; // 攻撃を無効にする
        yield return new WaitForSeconds(attackCooldown); // 指定した時間待つ
        canAttack = true; // 攻撃を再び有効にする
    }
    public void TakeDamage()
    {

        currentHp -= damage;
        if (currentHp < 0)
        {
            currentHp = 0;
        }
        hpSlider.value = (float)currentHp / (float)maxHp;  // ダメージを受けるごとにHPバーを減少


        Debug.Log($"{gameObject.name} がヒットされました。現在のHP: {currentHp}");

        if (currentHp <= 0)
        {
            Die();
        }
    }
   

    private void Die()
    {
        Destroy(gameObject);
        Debug.Log($"{gameObject.name} が破壊されました。");
        if (hpSlider != null)
        {
            Destroy(hpSlider.gameObject); // HPバーを削除
        }
    }

    private void AttackPlayer()
    {
        if (canAttack)
        {
            player.playerTakeDamage(playerdamage);
            Debug.Log("プレイヤーがゾンビに近づかれ、ダメージを受けました");
            StartCoroutine(AttackCooldown()); // クールダウンを開始
        }
    }
}