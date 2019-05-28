using IgUnity.Enum;
using IgUnity.Interface;
using IgUnity.Model;
using IgUnity.View;
using UnityEngine;

namespace IgUnity.Controller
{
    public sealed class FlashlightController : BaseController, IUpdate, IStart
    {
        private FlashlightModel _flashlightModel;

        public void Start()
        {
            _flashlightModel = Object.FindObjectOfType<FlashlightModel>();
        }

        public void Update()
        {
            if (!Enabled)
            {
                UI.FlashlightUi.ChangeFillAmount(BatteryChargeDirection.Up);
            }

            if (Enabled)
            {
                if (_flashlightModel.CheckBattery())
                {
                    UI.FlashlightUi.ChangeFillAmount(BatteryChargeDirection.Down);
                }
                else
                    Off();
            }

            _flashlightModel.ChangeBatteryCharge();
        }

        public override void Toggle()
        {
            if (Enabled)
            {
                Off();
            }
            else if (!Enabled)
            {
                On();
            }
        }

        public override void On()
        {
            if (Enabled) return;
            base.On();
            _flashlightModel.SetActiveFlashlight(Enabled);
        }

        public override void Off()
        {
            if (!Enabled) return;
            base.Off();
            _flashlightModel.SetActiveFlashlight(Enabled);
        }
    }
}