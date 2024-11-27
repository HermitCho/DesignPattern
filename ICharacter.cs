using characterState;
namespace characterInterface
{
    public interface ICharacter
    {
        void Display();
        void SetState(ICharacterState newState);
        string GetInfo();
        void Attack();

        void Ready();

        void Rest();
    }

    //플레이어 클래스
    public class Player : ICharacter
    {
        public static int playerNum = 1;
        public ICharacterState CurrentState;
        public string name;
        public int level;
        public int strength;
        public int health;

        public Player()
        {
            CurrentState = new IdleState();

            Console.Write("이름 입력 (Enter로 기본값): ");
            string n = Console.ReadLine();
            name = string.IsNullOrEmpty(n) ? $"플레이어 {playerNum}" : n;

            level = 1;
            strength = 10;
            health = 100;
        }

        public void Display()
        {
            Console.WriteLine("플레이어 '" + name + "'(이)가 생성되었습니다.");
        }

        public void SetState(ICharacterState newState)
        {
            CurrentState = newState;
        }

        public string GetInfo()
        {
            return $"이름 : {name}\n레벨 : {level}\n공격력 : {strength}\n체력 : {health}\n현재 상태 : {CurrentState.GetType().Name}\n플레이어 ID : {playerNum}\r\n";
        }

        public void SaveInfoToFile(string filePath)
        {
            try
            {
                File.WriteAllText(filePath, GetInfo());
                Console.WriteLine($"{filePath}에 정보 저장");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"파일 저장 오류 : {ex.Message}");
            }
        }

        public void Attack()
        {
            CurrentState.HandleAttack();
        }

        public void Ready()
        {
            CurrentState.HandleReady();
        }

        public void Rest()
        {
            CurrentState.HandleRest();
        }

        public void increaseID()
        {
            playerNum++;
        }
    }

    //몬스터 클래스 추상
    public abstract class Monster : ICharacter
    {
        public ICharacterState CurrentState;
        public string name;
        public int level;
        public int strength;
        public int health;

        public abstract void Display();

        public abstract void SetState(ICharacterState newState);

        public abstract string GetInfo();

        public abstract void Attack();

        public abstract void Ready();

        public abstract void Rest();
    }

    //몬스터 클래스를 상속받은 고블린 클래스
    public class Goblin : Monster
    {
        public static int goblinNum = 1;

        public Goblin(string? name, int? level, int? strength, int? health)
        {
            this.CurrentState = new IdleState();
            this.name = name ?? $"고블린 {goblinNum}";
            this.level = level ?? 1;
            this.strength = strength ?? 5;
            this.health = health ?? 20;

            goblinNum++;
        }
        public override void Display()
        {
            Console.WriteLine(name + " 이 나타났습니다.");
        }
        public override void SetState(ICharacterState newState)
        {
            CurrentState = newState;
        }

        public override string GetInfo()
        {
            return $"이름: {name}\n레벨 : {level}\n공격력 : {strength}\n체력 : {health}\n현재 상태 : {CurrentState.GetType().Name}\r\n";
        }

        public override void Attack()
        {
            CurrentState.HandleAttack();
        }

        public override void Ready()
        {
            CurrentState.HandleReady();
        }

        public override void Rest()
        {
            CurrentState.HandleRest();
        }
    }

    public class Slime : Monster
    {
        public static int slimeNum = 1;

        public Slime(string? name, int? level, int? strength, int? health)
        {
            this.CurrentState = new IdleState();
            this.name = name ?? $"슬라임 {slimeNum}";
            this.level = level ?? 1;
            this.strength = strength ?? 3;
            this.health = health ?? 10;

            slimeNum++;
        }

        public override void Display()
        {
            Console.WriteLine(name + " 이 나타났습니다.");
        }
        public override void SetState(ICharacterState newState)
        {
            CurrentState = newState;
        }

        public override string GetInfo()
        {
            return $"이름: {name}\n레벨 : {level}\n공격력 : {strength}\n체력 : {health}\n현재 상태 : {CurrentState.GetType().Name}\r\n";
        }

        public override void Attack()
        {
            CurrentState.HandleAttack();
        }

        public override void Ready()
        {
            CurrentState.HandleReady();
        }

        public override void Rest()
        {
            CurrentState.HandleRest();
        }
    }
}
