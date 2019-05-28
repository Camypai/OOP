using System.Collections.Generic;
using IgUnity.Controller;
using IgUnity.Helper;
using IgUnity.Interface;
using IgUnity.View;
using UnityEngine;

namespace IgUnity
{
    public class Main : MonoBehaviour
    {
        public InputController InputController;
        public FlashlightController FlashlightController;
        public WeaponController WeaponController;
        public ObjectManager ObjectManager;
        public Transform Player;

        private readonly List<IUpdate> _updates = new List<IUpdate>();
        public static Main Instance { get; private set; }

        private void Awake()
        {
            Instance = this;

            Player = GameObject.FindGameObjectWithTag("Player").transform;
            InputController = new InputController();
            FlashlightController = new FlashlightController();
            WeaponController = new WeaponController();
            ObjectManager = new ObjectManager();

            _updates.AddRange(new IUpdate[] {InputController, FlashlightController, WeaponController});
        }

        // Start is called before the first frame update
        void Start()
        {
            FlashlightController.Start();
            ObjectManager.Start();
            UI.AmmoUi.SetActive(false);
            InputController.On();
        }

        // Update is called once per frame
        void Update()
        {
            foreach (var update in _updates)
            {
                update.Update();
            }
        }
    }
}