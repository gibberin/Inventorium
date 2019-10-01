using System;
using System.Collections.Generic;
using System.Text;

namespace InventoriumLib
{
    class OBC : Item
    {
        IEnumerable<string> Interfaces;

        string Platform { get; set; }
        string CPU { get; set; }
        float Voltage { get; set; }
        float FlashMemory { get; set; }
        float RAM { get; set; }
        int GPIOCount { get; set; }
        int AnalogPinCount { get; set; }
        int PWMPinCount { get; set; }
        int USBConnectorCount { get; set; }
        bool PowerJack { get; set; }
        bool USBPower { get; set; }
        bool ResetButton { get; set; }
        bool Wifi { get; set; }
        bool Bluetooth { get; set; }
        bool BLE { get; set; }
        bool Out5V { get; set; }
        bool Out3_3V { get; set; }
        float MaxSourceAmps { get; set; }

        public OBC()
        {
            Interfaces = new List<string>();
        }

    }
}
