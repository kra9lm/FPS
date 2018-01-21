using UnityEngine;
namespace Lession1
{
    public class GarbageManager : MonoBehaviour
    {
        [SerializeField] private Garbage[] _garbages = new Garbage[5];

        private void Start()
        {
            var garbage = _garbages[1] as GarbageCube;
            if (_garbages[0] is GarbageSphere)
            {
                _garbages[0].Name = "Test of name func";
                _garbages[0].Color = Color.red;
            }
        }
    }
}
