using IgUnity.Enum;
using IgUnity.Model;
using UnityEngine;
using UnityEngine.UI;

namespace IgUnity.View
{
    public class FlashlightUI : BaseObject
    {
        private Image _image;

        [SerializeField] private float Amount;

        protected override void Awake()
        {
            base.Awake();
            _image = GetComponent<Image>();
        }

        public void ChangeFillAmount(BatteryChargeDirection direction)
        {
            switch (direction)
            {
                case BatteryChargeDirection.Up:
                    _image.fillAmount += Amount;
                    break;
                case BatteryChargeDirection.Down:
                    _image.fillAmount -= Amount;
                    break;
            }
        }
    }
}