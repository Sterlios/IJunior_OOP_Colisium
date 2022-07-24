using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Assassin : BaseFighter, IDodgable
    {
        // шанс уклонения 

        public Assassin(StringCreator stringCreator) :base(fighterClass: "Assassin", stringCreator: stringCreator)
        {

        }

        public override void UseAbility()
        {
            Dodge();
        }

        public void Dodge()
        {

        }

        public override BaseFighter ToCopy()
        {
            return new Assassin(StringCreator);
        }
    }
}
