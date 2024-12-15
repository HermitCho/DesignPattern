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


            //보스와 전투 흐름 : 보스의 공격에 피격당함

            dragon1.SetState(new NormalMode()); // 난이도 조절로 공격 패턴 변경경

            //전투 중인 보스와 피격 몬스터들 중재자에 속하게 만듦
            mediator.RegisterBoss(dragon1);
            mediator.RegisterPlayer(player1);
            mediator.RegisterMonster(goblin1);
            mediator.RegisterMonster(goblin2);

            dragon1.PerformAttack(mediator); //광역 공격

            //사망한 몬스터 중재자 소속 해제
            mediator.UnregisterMonster(goblin1);
            mediator.UnregisterMonster(goblin2);

            dragon1.SetState(new HardMode()); // 난이도 조절로 공격 패턴 변경경

            dragon1.PerformAttack(mediator); //단일 공격 + 광역 공격격


            //피격 상황을 보기 위해 플레이어 상태 저장
            player1.SaveInfoToFile();
        }
    }
}
