using System.Linq;
using IgUnity.Model;
using UnityEngine;
using UnityEngine.UI;

namespace IgUnity.View
{
    public class AmmoUI : BaseObject
    {
        private Text _patrons;
        private Text _holders;

        protected override void Awake()
        {
            base.Awake();
            _patrons = GetComponentsInChildren<Text>().First();
            _holders = GetComponentsInChildren<Text>().Last();
        }

        public void SetAmmo(int patrons)
        {
            _patrons.text = patrons.ToString();
        }

        public void SetAmmo(int patrons, int holders)
        {
            _patrons.text = patrons.ToString();
            _holders.text = holders.ToString();
        }

        public void SetActive(bool flag)
        {
            gameObject.SetActive(flag);
        }
    }
}