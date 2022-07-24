using Colisium.Fighters.Actions;

namespace Colisium.Fighters
{
    class Assassin : BaseFighter, IDodgable
    {
        // шанс уклонения 

        public Assassin()
        {

        }

        public override void UseAbility()
        {
            Dodge();
        }

        public void Dodge()
        {

        }
    }
}
