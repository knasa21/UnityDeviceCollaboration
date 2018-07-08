using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PWMValueSender : MonoBehaviour
{

    public SerialHandler serial;

    // PWMの値を送信
    public void SendPWMData( float pwm )
    {
        // PWMは0~255の間
        int sendPWM = (int)Mathf.Clamp( pwm, 0, 255 );
        serial.Write( "s" + sendPWM.ToString() + "e" );
    }
}
