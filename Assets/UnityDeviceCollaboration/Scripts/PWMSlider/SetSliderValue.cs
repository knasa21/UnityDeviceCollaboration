using UnityEngine;
using UnityEngine.UI;

// スライダーの値を表示
public class ValueText: MonoBehaviour
{
    public SerialHandler serial;
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
