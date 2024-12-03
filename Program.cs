using System.Diagnostics;

namespace DesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CharacterFactory[] characterFactory =
            {
            new PlayerFactory(),
            new PlayerFactory(),
            new GoblinFactory(),
            new GoblinFactory(),
            new SlimeFactory()
        };

            ICharacter player1 = characterFactory[0].CreateOperation();
            //캐릭터 커스텀 생성은 시스템 상 막아둠
            //ICharacter player2 = characterFactory[1].CustomCreateOperation("커스텀 캐릭터", 100, 100, 10000);
            ICharacter goblin1 = characterFactory[2].CreateOperation();
            //고블린 캐릭터 커스텀 생성
            ICharacter goblin2 = characterFactory[3].CustomCreateOperation("고블린 족장", 5, 5, 25);
            ICharacter Slime1 = characterFactory[4].CreateOperation();


            Console.WriteLine("\n------------------\n");
            //상태에 따른 캐릭터의 행동

            //goblin1.Ready();
            // goblin1.Die();
            // Console.Write(goblin1.GetInfo());
        }
    }

}
