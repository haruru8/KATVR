using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text blackText;  // Black Target�̃J�E���g��\������Text�R���|�[�l���g
    public Text blueText;   // Blue Target�̃J�E���g��\������Text�R���|�[�l���g
    public Text yellowText; // Yellow Target�̃J�E���g��\������Text�R���|�[�l���g
    public Text redText;    // Red Target�̃J�E���g��\������Text�R���|�[�l���g

    private int blackCount = 0;
    private int blueCount = 0;
    private int yellowCount = 0;
    private int redCount = 0;

    void Start()
    {
        Debug.Log("�����Ă��");
        // ������Ԃ̃e�L�X�g��ݒ�
        UpdateText();
    }

    public void Increment(string targetName)
    {
        Debug.Log($"Increment called with target: {targetName}");  // �f�o�b�O���O�ǉ�

        // ���̖̂��O�ɉ����ăJ�E���g�𑝂₵�AText�R���|�[�l���g�̓��e���X�V
        switch (targetName)
        {
            case "black":
                blackCount++;
                blackText.text = GetColoredString($"Black Target count: {blackCount}", "black");
                Debug.Log($"Black Target count: {blackCount}");
                break;
            case "blue":
                blueCount++;
                blueText.text = GetColoredString($"Blue Target count: {blueCount}", "blue");
                Debug.Log($"Blue Target count: {blueCount}");
                break;
            case "yellow1":
            case "yellow2":
                yellowCount++;
                yellowText.text = GetColoredString($"Yellow Target count: {yellowCount}", "yellow");
                Debug.Log($"Yellow Target count: {yellowCount}");
                break;
            case "red":
                redCount++;
                redText.text = GetColoredString($"Red Target count: {redCount}", "red");
                Debug.Log($"Red Target count: {redCount}");
                break;
            default:
                Debug.LogWarning($"Unknown target: {targetName}");
                break;
        }

        // �e�L�X�g���X�V
        UpdateText();
    }

    private void UpdateText()
    {
        // �����Ńe�L�X�g���X�V���邱�Ƃ��ł��܂����AIncrement���\�b�h���ōX�V���Ă���̂ŁA�R�����g�A�E�g���܂���
        // blackText.text = $"Black Target count: {blackCount}";
        // blueText.text = $"Blue Target count: {blueCount}";
        // yellowText.text = $"Yellow Target count: {yellowCount}";
        // redText.text = $"Red Target count: {redCount}";
    }

    private string GetColoredString(string src, string color)
    {
        return $"<color={color}>{src}</color>";
    }
}
