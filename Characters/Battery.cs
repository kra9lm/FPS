namespace Lession1
{
    public class Battery
    {
        private float _currentCapacity;

        public Battery()
        {
            Capacity = 75f;
            _currentCapacity = Capacity;
        }
        public float Capacity { get; private set; }
        public float CurrentCapacity
        {
            get
            {
                return _currentCapacity / Capacity * 100;
            }
        }
        public void DrainCapacity(float value)
        {
            if (value <= 0) return;
            _currentCapacity -= value;
        }
    }
}
