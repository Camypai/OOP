using System.Collections.Generic;
using IgUnity.Model;
using UnityEngine;
using UnityEngine.Rendering;

namespace IgUnity.Helper
{
    public class ObjectManager
    {
        private List<WeaponModel> Weapons = new List<WeaponModel>();

        public List<WeaponModel> GetWeapons => Weapons;
        public FlashlightModel FlashlightModel { get; private set; }

        public void Start()
        {
            Weapons = new List<WeaponModel>(Main.Instance.Player.GetComponentsInChildren<WeaponModel>());

            foreach (var weapon in Weapons)
            {
                weapon.IsVisible = false;
            }

            FlashlightModel = Object.FindObjectOfType<FlashlightModel>();
            FlashlightModel.SetActiveFlashlight(false);
        }
    }
}