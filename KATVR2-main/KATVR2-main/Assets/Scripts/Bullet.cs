using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Counter counterScript;  // カウンタースクリプトへの参照
    [SerializeField] private float destroyTimer = 2f; // 自動で破壊される時間

    void Start()
    {

        // 一定時間後に自動で破壊するタイマーを設定
        Destroy(gameObject, destroyTimer);
    }

    void OnCollisionEnter(Collision collision)
    {


        // 弾丸の破壊
        Destroy(gameObject);
    }
}
