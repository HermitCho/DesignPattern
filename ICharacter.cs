namespace DesignPattern
{
    public enum State
    {
        Idle,
        Combat,
        Rest
    }

    public interface ICharacter
    {
        public void Display_Created();
        public string GetInfo();
        public void Die();
    }








    //플레이어 클래스
    public class Player : ICharacter
    {
        State currentState = State.Idle;
        static int playerNum = Int32.Parse(File.ReadAllText("playerNum_to_Server"));
        string name;
        int level;
        int strength;
        int health;
        int max_health;

        //기본 생성자
        public Player()
        {
            Console.Write("이름 입력 (Enter로 기본값): ");
            string n = Console.ReadLine();
            name = string.IsNullOrEmpty(n) ? $"플레이어 {playerNum}" : n;

            level = 1;
            strength = 10;
            max_health = 100;
            health = max_health;
        }

        public void Display_Created()
        {
            Console.WriteLine("플레이어 '" + name + "'(이)가 생성되었습니다.");
        }

        public string GetInfo()
        {
            return $"이름 : {name}\n레벨 : {level}\n공격력 : {strength}\n체력 : {health}\n현재 상태 : {currentState}\n플레이어 ID : {playerNum}\r\n";
        }

        public void SaveInfoToFile()
        {
            string filePath = $"{name}정보.txt";
            try
            {
                File.WriteAllText(filePath, GetInfo());
                Console.WriteLine($"{filePath} 에 저장 ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"파일 저장 오류 : {ex.Message}");
            }
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            Console.WriteLine($"{name}(이)가 {damage} 데미지를 받았습니다.");
            if (health <= 0)
            {
                Die();
            }
        }

        public void increaseID()
        {
            playerNum++;
            File.WriteAllText("playerNum_to_Server", playerNum.ToString());
        }
        public void Die()
        {
            Console.Write($"{name}이(가) 죽었습니다. 부활합니다.\n");
            health = max_health;
        }
    }












    //몬스터 클래스 추상
    public abstract class Monster : ICharacter
    {
        protected State currentState = State.Idle;
        protected string name;
        protected int level;
        protected int strength;
        protected int health;
        protected int max_health;

        public void Display_Created()
        {
            Console.WriteLine($"{name}이(가) 나타났습니다.");
        }

        public string GetInfo()
        {
            return $"이름: {name}\n레벨 : {level}\n공격력 : {strength}\n체력 : {health}\n현재 상태 : {currentState.GetType().Name}\r\n";
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
            Console.WriteLine($"{name}(이)가 {damage} 데미지를 받았습니다.");
            if (health <= 0)
            {
                Die();
            }
        }

        //몬스터 사망 시 클래스 삭제 및 메모리 관리
        public void Die()
        {
            Console.WriteLine($"'{name}'이(가) 처치되었습니다.");
            Dispose();
        }

        public void Dispose()
        {
            name = null;
            level = 0;
            strength = 0;
            health = 0;
            max_health = 0;
        }

        ~Monster()
        {
            Dispose();
        }
    }

    //몬스터 클래스를 상속받은 고블린 클래스
    public class Goblin : Monster
    {
        public static int goblinNum = 1;

        //기본 생성자
        public Goblin(string? name, int? level, int? strength, int? max_health)
        {
            this.name = name ?? $"고블린 {goblinNum}";
            this.level = level ?? 1;
            this.strength = strength ?? 5;
            this.max_health = max_health ?? 20;
            this.health = max_health ?? 20;

            goblinNum++;
        }
    }








    public class Boss : Monster
    {
        protected ICharacterState DifficultyState = new EasyMode();
        public void SetState(ICharacterState newState)
        {
            DifficultyState = newState;
        }

        public void PerformAreaAttack(BattleMediator _mediator)
        {
            DifficultyState.HandleAttack(_mediator, strength);
        }
    }


    public class Dragon : Boss
    {
        public static int dragonNum = 1;

        //기본 생성자
        public Dragon(string? name, int? level, int? strength, int? max_health)
        {
            this.DifficultyState = new EasyMode();
            this.name = name ?? $"드래곤 {dragonNum}";
            this.level = level ?? 30;
            this.strength = strength ?? 50;
            this.max_health = max_health ?? 3000;
            this.health = max_health ?? 3000;

            dragonNum++;
        }
    }
}
