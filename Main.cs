using UnityEngine;
namespace Lession1
{
    public sealed class Main : MonoBehaviour
    {
        public static Main Instance { get; private set; }

        public Transform Player;

        private GameObject _allControllers;
        private InputController _inputController;
        [HideInInspector] public ObjectManager ObjectManager { get; private set; }
        [HideInInspector] public UIController UiController { get; private set; }
        [HideInInspector] public FlashLightController FlashLightController { get; private set; }
        [HideInInspector] public SelectController SelectController { get; private set; }
        [HideInInspector] public WeaponController WeaponController { get; private set; }

        private void Awake()
        {
            Instance = this;
            _allControllers = new GameObject("All Controllers");
            _inputController = _allControllers.AddComponent<InputController>();
            UiController = _allControllers.AddComponent<UIController>();
            FlashLightController = _allControllers.AddComponent<FlashLightController>();
            SelectController = _allControllers.AddComponent<SelectController>();
            WeaponController = _allControllers.AddComponent<WeaponController>();

            ObjectManager = FindObjectOfType<ObjectManager>();

            _inputController.On();
            SelectController.On();
            UiController.On();

            WeaponController.Off();

            DontDestroyOnLoad(gameObject);
        }
    }
}
