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
            StringCreator.ShowMessage(Class + " уклонился от удара");
        }

        public override BaseFighter ToCopy()
        {
            int сумка = 5;
            return new Assassin(StringCreator);
        }
    }
}
