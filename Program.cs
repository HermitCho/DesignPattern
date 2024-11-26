public class Program
{
    public static void Main(string[] args)
    {
        // 팩토리 패턴을 사용하여 캐릭터 생성
        ICharacter player1 = CharacterFactory.CreateCharacter("Player");
        ICharacter player2 = CharacterFactory.CreateCharacter("Player");
        ICharacter goblin1 = CharacterFactory.CreateCharacter("Goblin");
        ICharacter goblin3 = CharacterFactory.CreateCharacter("Goblin", "고블린 족장", 5, 9, 40);
        ICharacter goblin2 = CharacterFactory.CreateCharacter("Goblin");
        ICharacter slime1 = CharacterFactory.CreateCharacter("Slime");

        // //캐릭터 정보 출력
        // Console.WriteLine(player1.GetInfo());
        // Console.WriteLine(player2.GetInfo());
        // Console.WriteLine(goblin1.GetInfo());
        // Console.WriteLine(goblin3.GetInfo());
        // Console.WriteLine(goblin2.GetInfo());
        // Console.WriteLine(slime1.GetInfo());

        //상태 패턴을 사용하여 전투/비전투 상태로 전환
        player1.CombatState();
        player1.CombatState();
        player1.IdleState();

        // 플레이어 정보 txt 파일로 저장
        if (player1 is Player playerInstance1)
        {
            playerInstance1.SaveInfoToFile($"{player1.name}의 정보.txt");
        }
        if (player2 is Player playerInstance2)
        {
            playerInstance2.SaveInfoToFile($"{player2.name}의 정보.txt");
        }
        // // 플레이어가 아니면 저장 안됨
        // if (slime1 is Player playerInstance3)
        // {
        //     playerInstance3.SaveInfoToFile($"{slime1.name}의 정보.txt");
        // }
    }
}
