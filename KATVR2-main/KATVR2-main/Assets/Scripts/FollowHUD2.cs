using UnityEngine;

public class FollowHUD2 : MonoBehaviour
{
    public Transform headTransform; // �v���C���[�̃J����Transform

    void Update()
    {
        // Canvas�̈ʒu�Ɖ�]���J�����ɍ��킹��
        transform.position = headTransform.position;
        transform.rotation = headTransform.rotation;
    }
}
