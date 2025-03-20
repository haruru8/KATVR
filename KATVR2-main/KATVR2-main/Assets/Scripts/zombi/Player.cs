using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 100;
  
    private int currentHealth;
    public string targetSceneName = "GameOver"; // 移動先のシーン名

    [SerializeField]
    private Text healthText; // UI Textコンポーネントを参照するためのフィールド
    void Start()
    {
        Debug.Log("player呼び出す");
        currentHealth = maxHealth;
        UpdateHealthUI();
        // 初期の体力を表示
    }



    public void playerTakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"プレイヤーがダメージを受けました: {damage} 現在の体力: {currentHealth}");
        UpdateHealthUI(); // ダメージを受けた後のUI更新


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
        Debug.Log("プレイヤーが死亡しました");
        // プレイヤーが死亡した際の処理をここに追加
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
            Debug.LogError("Health Text UI が設定されていません。Inspectorで設定してください。");
        }
    }


}