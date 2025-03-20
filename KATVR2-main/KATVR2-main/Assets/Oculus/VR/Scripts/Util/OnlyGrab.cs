using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[HelpURL("https://developer.oculus.com/reference/unity/latest/class_o_v_r_grabber")]
public class OnlyGrab : MonoBehaviour
{
    public float grabBegin = 0.55f;
    public float grabEnd = 0.35f;

    [SerializeField]
    protected Transform m_gripTransform = null; // 手のTransform（銃を保持する位置）
    [SerializeField]
    protected GameObject m_initialGrabObject; // 初期状態で持つ銃オブジェクト
    [SerializeField]
    protected bool m_snapPosition = true; // 初期化時に銃を特定の位置にスナップさせるか
    [SerializeField]
    protected bool m_snapOrientation = true; // 初期化時に銃を特定の回転にスナップさせるか

    private OVRGrabbable m_grabbedObj = null;

    protected virtual void Start()
    {
        // 初期化時に銃を直接持つ
        if (m_initialGrabObject != null)
        {
            SetupInitialObject(m_initialGrabObject);
        }
        else
        {
            Debug.LogError("Initial grab object is not set. Please assign it in the Inspector.");
        }
    }

    /// <summary>
    /// 銃を初期化時に手に持たせる
    /// </summary>
    /// <param name="grabObject">銃のGameObject</param>
    private void SetupInitialObject(GameObject grabObject)
    {
        OVRGrabbable grabbable = grabObject.GetComponent<OVRGrabbable>();
        if (grabbable == null)
        {
            Debug.LogError($"The object {grabObject.name} does not have an OVRGrabbable component.");
            return;
        }

        // 銃を手にセット
        m_grabbedObj = grabbable;
        Rigidbody grabbedRigidbody = m_grabbedObj.GetComponent<Rigidbody>();

        if (grabbedRigidbody == null)
        {
            Debug.LogError($"The object {grabObject.name} does not have a Rigidbody component.");
            return;
        }

        // 物体をスナップさせる位置と回転を計算
        Vector3 targetPosition = m_snapPosition ? m_gripTransform.position : grabObject.transform.position;
        Quaternion targetRotation = m_snapOrientation ? m_gripTransform.rotation : grabObject.transform.rotation;

        // 銃を物理的に強制配置
        grabbedRigidbody.isKinematic = true; // 手に固定するため物理挙動を無効化
        grabObject.transform.position = targetPosition;
        grabObject.transform.rotation = targetRotation;

        // 銃をプレイヤーの手の子オブジェクトに設定
        grabObject.transform.parent = m_gripTransform;

        Debug.Log($"Successfully attached {grabObject.name} to the hand.");
    }
}
