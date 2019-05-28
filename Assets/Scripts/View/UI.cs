using UnityEngine;

namespace IgUnity.View
{
    public static class UI
    {
        private static FlashlightUI _flashlightUi;

        public static FlashlightUI FlashlightUi
        {
            get
            {
                if (!_flashlightUi)
                    _flashlightUi = Object.FindObjectOfType<FlashlightUI>();
                return _flashlightUi;
            }
        }

        private static AmmoUI _ammoUi;

        public static AmmoUI AmmoUi
        {
            get
            {
                if (!_ammoUi)
                    _ammoUi = Object.FindObjectOfType<AmmoUI>();
                return _ammoUi;
            }
        }
    }
}