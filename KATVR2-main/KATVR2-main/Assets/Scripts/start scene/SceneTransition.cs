using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーンマネージャーを使用するために必要

public class SceneTransition : MonoBehaviour
{
    public string targetSceneName = "GameScene"; // 移動先のシーン名

    // トリガーに触れたときに呼び出されるメソッド
    void OnTriggerEnter(Collider other)
    {
        // 任意の条件をチェック（例えば、特定のタグを持つオブジェクトにのみ反応）
        if (other.CompareTag("Player")) // "Player"タグのオブジェクトと衝突した場合
        {
            SceneManager.LoadScene(targetSceneName); // 指定したシーンに移動
        }
    }
}
