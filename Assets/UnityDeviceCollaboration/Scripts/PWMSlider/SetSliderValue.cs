using UnityEngine;
using UnityEngine.UI;

// スライダーの値を表示
public class SetSliderValue: MonoBehaviour
{
    // 必要ではないが、確認用にPublic
    public float value;

    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    // Sliderの値をTextにセット
    public void SetValue( float v )
    {
        value = v;
        text.text = v.ToString();
    }

}
