using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoriumLib
{
    public class OBC : Item
    {
        public IEnumerable<string> Interfaces;

        public string Platform { get; set; }
        public string CPU { get; set; }
        public float Voltage { get; set; }
        public float FlashMemory { get; set; }
        public float RAM { get; set; }
        public int GPIOCount { get; set; }
        public int AnalogPinCount { get; set; }
        public int PWMPinCount { get; set; }
        public int USBConnectorCount { get; set; }
        public bool PowerJack { get; set; }
        public bool USBPower { get; set; }
        public bool ResetButton { get; set; }
        public bool Wifi { get; set; }
        public bool Bluetooth { get; set; }
        public bool BLE { get; set; }
        public bool Out5V { get; set; }
        public bool Out3_3V { get; set; }
        public float MaxSourceAmps { get; set; }

        public OBC()
        {
            Interfaces = new List<string>();
        }
    }
}
