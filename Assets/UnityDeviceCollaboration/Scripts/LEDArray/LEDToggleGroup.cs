using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// LED点灯用Toggleグループの制御
public class LEDToggleGroup : MonoBehaviour
{
    public SerialHandler serial;

    // Toggleは複数なので配列で持つ
    Toggle[] ledToggles;

    // 送信文字列
    string   sendData;
    
    // 初期化
    private void Start()
    {
        TogglesSetting();
        TogglesValueCheck();
    }

    private void Update()
    {

    }

    // 終了処理
    private void OnDestroy()
    {
        // 開始フラグ
        sendData = "s";

        foreach ( var toggle in ledToggles ) {
            sendData += "0";
        }

        // 終了フラグ
        sendData += "e";

        // データ送信
        LEDDataSend();
    }


    // 子からToggleを取得し、コールバックの設定
    private void TogglesSetting()
    {
        // 子オブジェクト全体からToggleコンポーネントの取得
        ledToggles = gameObject.GetComponentsInChildren<Toggle>();

        // Toggleの値が変わった時に呼び出される関数の設定
        foreach ( var toggle in ledToggles ) {
            toggle.onValueChanged.AddListener( ToggleChange );
        }
    }

    // Toggleの値が変わった時に呼び出される
    private void ToggleChange( bool isChecked )
    {
        TogglesValueCheck();

        LEDDataSend();
    }

    // Toggle配列から値の確認
    private void TogglesValueCheck()
    {
        // 開始フラグ
        sendData = "s";

        foreach ( var toggle in ledToggles ) {
            // toggleの値を見て1/0をセット
            sendData += toggle.isOn ? "1" : "0";
        }

        // 終了フラグ
        sendData += "e";

    }

    // LED設定データの送信
    private void LEDDataSend()
    {
        serial.Write( sendData );
        Debug.Log( "Send data = " + sendData );
    }
}
