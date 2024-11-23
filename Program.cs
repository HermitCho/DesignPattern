public class Program
{
    public static void Main(string[] args)
    {
        // 팩토리 패턴을 사용하여 캐릭터 생성
        ICharacter player1 = CharacterFactory.CreateCharacter("Player");
        ICharacter goblin1 = CharacterFactory.CreateCharacter("Goblin");
        ICharacter goblin3 = CharacterFactory.CreateCharacter("Goblin", "고블린 족장", 5, 9, 40);
        ICharacter goblin2 = CharacterFactory.CreateCharacter("Goblin");
        ICharacter slime1 = CharacterFactory.CreateCharacter("Slime");

        //캐릭터 정보 출력
        Console.WriteLine(player1.GetInfo());
        Console.WriteLine(goblin1.GetInfo());
        Console.WriteLine(goblin3.GetInfo());
        Console.WriteLine(goblin2.GetInfo());
        Console.WriteLine(slime1.GetInfo());

        // 플레이어 정보 txt 파일로 저장
        if (player1 is Player playerInstance)
        {
            playerInstance.SaveInfoToFile("playerInfo.txt");
        }

        // 상태 패턴을 사용하여 전투 모드로 전환
        player1.SetState(new CombatState());
        goblin1.SetState(new CombatState());
        slime1.SetState(new CombatState());

        //캐릭터 전투 모드 전환 확인
        Console.WriteLine(player1.GetInfo());
        Console.WriteLine(goblin1.GetInfo());
        Console.WriteLine(slime1.GetInfo());

        // 전투가 끝난 후 다시 비전투 상태로 변경
        player1.SetState(new IdleState());
        goblin1.SetState(new IdleState());
        slime1.SetState(new IdleState());
    }
}
