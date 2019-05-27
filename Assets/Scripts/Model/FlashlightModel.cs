using IgUnity.Enum;
using UnityEngine;

namespace IgUnity.Model
{
    public class FlashlightModel : BaseObject
    {
        private Light _light;

        private int _batteryChargeCurrent { get; set; }

        private int batteryChargeCurrent
        {
            get => _batteryChargeCurrent;
            set
            {
                if (value < 0)
                    _batteryChargeCurrent = 0;
                else if (value > 100)
                    _batteryChargeCurrent = 100;
                else
                    _batteryChargeCurrent = value;
            }
        }

        [SerializeField] private int BatteryCharge;

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _batteryChargeCurrent = BatteryCharge;
            SetActiveFlashlight(false);
        }

        public void SetActiveFlashlight(bool value)
        {
            _light.enabled = value;
        }

        public void ChangeBatteryCharge()
        {
            if (!_light.enabled)
            {
                ChangeBatteryCharge(BatteryChargeDirection.Up);
            }

            if (_light.enabled && CheckBattery())
            {
                ChangeBatteryCharge(BatteryChargeDirection.Down);
            }
        }

        private void ChangeBatteryCharge(BatteryChargeDirection direction)
        {
            switch (direction)
            {
                case BatteryChargeDirection.Up:
                    batteryChargeCurrent += 1;
                    break;
                case BatteryChargeDirection.Down:
                    batteryChargeCurrent -= 1;
                    break;
            }
        }

        public bool CheckBattery()
        {
            return batteryChargeCurrent != 0;
        }
    }
}