using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public Text blackText;  // Black Targetのカウントを表示するTextコンポーネント
    public Text blueText;   // Blue Targetのカウントを表示するTextコンポーネント
    public Text yellowText; // Yellow Targetのカウントを表示するTextコンポーネント
    public Text redText;    // Red Targetのカウントを表示するTextコンポーネント

    private int blackCount = 0;
    private int blueCount = 0;
    private int yellowCount = 0;
    private int redCount = 0;

    void Start()
    {
        Debug.Log("動いてるよ");
        // 初期状態のテキストを設定
        UpdateText();
    }

    public void Increment(string targetName)
    {
        Debug.Log($"Increment called with target: {targetName}");  // デバッグログ追加

        // 物体の名前に応じてカウントを増やし、Textコンポーネントの内容を更新
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

        // テキストを更新
        UpdateText();
    }

    private void UpdateText()
    {
        // ここでテキストを更新することもできますが、Incrementメソッド内で更新しているので、コメントアウトしました
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
