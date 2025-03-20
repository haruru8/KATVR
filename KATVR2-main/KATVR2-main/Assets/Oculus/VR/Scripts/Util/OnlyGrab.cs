using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[HelpURL("https://developer.oculus.com/reference/unity/latest/class_o_v_r_grabber")]
public class OnlyGrab : MonoBehaviour
{
    public float grabBegin = 0.55f;
    public float grabEnd = 0.35f;

    [SerializeField]
    protected Transform m_gripTransform = null; // ���Transform�i�e��ێ�����ʒu�j
    [SerializeField]
    protected GameObject m_initialGrabObject; // ������ԂŎ��e�I�u�W�F�N�g
    [SerializeField]
    protected bool m_snapPosition = true; // ���������ɏe�����̈ʒu�ɃX�i�b�v�����邩
    [SerializeField]
    protected bool m_snapOrientation = true; // ���������ɏe�����̉�]�ɃX�i�b�v�����邩

    private OVRGrabbable m_grabbedObj = null;

    protected virtual void Start()
    {
        // ���������ɏe�𒼐ڎ���
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
    /// �e�����������Ɏ�Ɏ�������
    /// </summary>
    /// <param name="grabObject">�e��GameObject</param>
    private void SetupInitialObject(GameObject grabObject)
    {
        OVRGrabbable grabbable = grabObject.GetComponent<OVRGrabbable>();
        if (grabbable == null)
        {
            Debug.LogError($"The object {grabObject.name} does not have an OVRGrabbable component.");
            return;
        }

        // �e����ɃZ�b�g
        m_grabbedObj = grabbable;
        Rigidbody grabbedRigidbody = m_grabbedObj.GetComponent<Rigidbody>();

        if (grabbedRigidbody == null)
        {
            Debug.LogError($"The object {grabObject.name} does not have a Rigidbody component.");
            return;
        }

        // ���̂��X�i�b�v������ʒu�Ɖ�]���v�Z
        Vector3 targetPosition = m_snapPosition ? m_gripTransform.position : grabObject.transform.position;
        Quaternion targetRotation = m_snapOrientation ? m_gripTransform.rotation : grabObject.transform.rotation;

        // �e�𕨗��I�ɋ����z�u
        grabbedRigidbody.isKinematic = true; // ��ɌŒ肷�邽�ߕ��������𖳌���
        grabObject.transform.position = targetPosition;
        grabObject.transform.rotation = targetRotation;

        // �e���v���C���[�̎�̎q�I�u�W�F�N�g�ɐݒ�
        grabObject.transform.parent = m_gripTransform;

        Debug.Log($"Successfully attached {grabObject.name} to the hand.");
    }
}
