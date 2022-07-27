using System.Collections.Generic;

namespace Colisium.Fighters.Actions
{
    class Damage
    {
        public bool IsStun { get; private set; }
        private List<float> _damages;

        public Damage(List<float> damages, bool isStun = false)
        {
            IsStun = isStun;
            _damages = damages;
        }

        public List<float> GetDamage()
        {
            List<float> damages = new List<float>();

            foreach(float damage in _damages)
            {
                damages.Add(damage);
            }

            return damages;
        }
    }
}
