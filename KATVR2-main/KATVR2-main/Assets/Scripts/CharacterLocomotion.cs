//これ何にも使われていません
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform playerCamera; // 繝励Ξ繧､繝､繝ｼ縺ｮ繧ｫ繝｡繝ｩ縺ｮ繝医Λ繝ｳ繧ｹ繝輔か繝ｼ繝�
    public float moveSpeed = 3f; // 遘ｻ蜍暮�溷ｺｦ
    public float sensitivity = 2f; // 諢溷ｺｦ

    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        // CharacterController繧貞叙蠕�
        characterController = GetComponent<CharacterController>();

        // 螟画峩轤ｹ: playerCamera縺悟牡繧雁ｽ薙※繧峨ｌ縺ｦ縺�縺ｪ縺�蝣ｴ蜷医�∬�ｪ蜍輔〒Main Camera繧貞牡繧雁ｽ薙※繧�
        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = playerCamera.forward;
        forward.y = 0; // 蝙ら峩縺ｮ謌仙��繧堤┌隕悶☆繧�
        forward.Normalize();

        // 繧ｫ繝｡繝ｩ縺ｮ譁ｹ蜷代↓蝓ｺ縺･縺�縺ｦ遘ｻ蜍墓婿蜷代ｒ險育ｮ励☆繧�
        Vector3 moveDirection = forward * moveSpeed * Time.deltaTime;

        // CharacterController繧剃ｽｿ縺｣縺ｦ遘ｻ蜍輔☆繧�
        characterController.Move(moveDirection);

        // 繧ｫ繝｡繝ｩ縺ｮ蝗櫁ｻ｢縺ｫ蝓ｺ縺･縺�縺ｦ繧ｭ繝｣繝ｩ繧ｯ繧ｿ繝ｼ繧貞屓霆｢縺輔○繧�
        float horizontalRotation = Input.GetAxis("Mouse X") * sensitivity;
        transform.Rotate(0, horizontalRotation, 0);
    }
}
