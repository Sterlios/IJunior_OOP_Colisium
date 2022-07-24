using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class IceMen : BaseFighter, IStunable
    {
        // Стан врага

        public IceMen(StringCreator stringCreator) : base(fighterClass: "IceMen", stringCreator: stringCreator)
        {

        }

        public override void UseAbility()
        {
            Stun();
        }

        public void Stun()
        {

        }

        public override BaseFighter ToCopy()
        {
            return new IceMen(StringCreator);
        }
    }
}
