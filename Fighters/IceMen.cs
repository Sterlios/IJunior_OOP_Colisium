using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class IceMen : BaseFighter, IStunable
    {
        // Стан врага

        public IceMen()
        {

        }

        public override void UseAbility()
        {
            Stun();
        }

        public void Stun()
        {

        }
    }
}
