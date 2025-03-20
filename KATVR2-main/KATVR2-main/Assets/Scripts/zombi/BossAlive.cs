using UnityEngine;
using UnityEngine.SceneManagement;

public class BossAlive : MonoBehaviour
{
    [SerializeField]
    private string sceneName;  // �ύX��̃V�[����

    private Player player;
    void Start()
    {
        // �V�[������ Player �I�u�W�F�N�g��T��
        player = GameObject.FindWithTag("Player").GetComponent<Player>();

        if (player == null)
        {
            Debug.LogError("Player �I�u�W�F�N�g��������܂���B");
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