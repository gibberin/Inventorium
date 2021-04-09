using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NventoriumLib
{
    public class OBC : Item
    {
        public IEnumerable<string> Interfaces;

        public string Platform { get; set; }
        public string CPU { get; set; }
        public float? Voltage { get; set; }
        [DisplayName("Flash Memory")]
        public float? FlashMemory { get; set; }
        public float? RAM { get; set; }
        [DisplayName("GPIO Pins")]
        public int? GPIOCount { get; set; }
        [DisplayName("Analog Pins")]
        public int? AnalogPinCount { get; set; }
        [DisplayName("PWM Pins")]
        public int? PWMPinCount { get; set; }
        [DisplayName("USB Connectors")]
        public int? USBConnectorCount { get; set; }
        [DisplayName("Power Jack")]
        public bool PowerJack { get; set; }
        [DisplayName("USB Power")]
        public bool USBPower { get; set; }
        [DisplayName("Reset Button")]
        public bool ResetButton { get; set; }
        public bool Wifi { get; set; }
        public bool Bluetooth { get; set; }
        public bool BLE { get; set; }
        [DisplayName("5V Out")]
        public bool Out5V { get; set; }
        [DisplayName("3.3V Out")]
        public bool Out3_3V { get; set; }
        [DisplayName("Max Source Amps")]
        public float? MaxSourceAmps { get; set; }

        public OBC()
        {
            Interfaces = new List<string>();
        }
    }
}
