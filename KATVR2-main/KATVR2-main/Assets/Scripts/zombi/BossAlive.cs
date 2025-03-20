using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAlive : MonoBehaviour
{
    [SerializeField]
    private string sceneName;  // 変更先のシーン名

    private Player player;
    void Start()
    {
        // シーン内の Player オブジェクトを探す
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("Player オブジェクトが見つかりません。");
        }
    }
    void OnDestroy()
    {
        if (player != null && player.GetCurrentHealth() > 0)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}