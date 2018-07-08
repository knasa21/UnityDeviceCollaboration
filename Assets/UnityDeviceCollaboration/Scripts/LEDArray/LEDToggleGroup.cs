using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEDToggleGroup : MonoBehaviour
{
    public SerialHandler serial;
    public Toggle[] ledToggles;
    public string   sendData;
    
    // 初期化
    private void Awake()
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

        // データ送信
        LEDDataSend();
    }

    // LED設定データの送信
    private void LEDDataSend()
    {
        serial.Write( sendData );
    }
}
