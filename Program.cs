using System.Diagnostics;

namespace DesignPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BattleMediator mediator = new BattleMediator();

            PlayerFactory playerFactory = new PlayerFactory();
            GoblinFactory goblinFactory= new GoblinFactory();
            DragonFactory dragonFactory= new DragonFactory();

            Player player1 = playerFactory.CreateOperation();
            //캐릭터 커스텀 생성은 시스템 상 막아둠
            //Player player2 = playerFactory.CreateOperation("커스텀 캐릭터", 100, 100, 10000);
            Goblin goblin1 = goblinFactory.CreateOperation();
            //고블린 캐릭터 커스텀 생성
            Goblin goblin2 = goblinFactory.CustomCreateOperation("고블린 족장", 5, 5, 25);
            Dragon dragon1 = dragonFactory.CreateOperation();


            Console.WriteLine("\n------------------\n");
            //상태에 따른 캐릭터의 행동

            mediator.RegisterBoss(dragon1);
            mediator.RegisterPlayer(player1);
            mediator.RegisterMonster(goblin1);
            mediator.RegisterMonster(goblin2);

            dragon1.PerformAreaAttack(mediator);

            player1.SaveInfoToFile();
        }
    }
}
