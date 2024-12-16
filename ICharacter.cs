namespace DesignPattern
{
    public enum State
    {
        Idle,
        Combat,
        Rest
    }


    //캐릭터 인터페이스
    public interface ICharacter
    {
        public void Display_Created();
        public void Die();

    }



    //플레이어 캐릭터 클래스
    public class Player : ICharacter, IBattleCharacter
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
            max_health = 1000;
            health = max_health;
        }

        //캐릭터 생성 표시
        public void Display_Created()
        {
            Console.WriteLine("플레이어 '" + name + "'(이)가 생성되었습니다.");
        }

        //저장을 위한 정보 가져오기
        public string GetInfo()
        {
            return $"이름 : {name}\n레벨 : {level}\n공격력 : {strength}\n체력 : {health}\n현재 상태 : {currentState}\n플레이어 ID : {playerNum}\r\n";
        }

        //캐릭터 저장
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

        //데미지 피격
        public void TakeDamage(int damage)
        {
            health -= damage;
            currentState = State.Combat;
            Console.WriteLine($"{name}(이)가 {damage} 데미지를 받았습니다.");
            if (health <= 0)
            {
                Die();
            }
        }

        //캐릭터 별 고유 아이디 설정을 위한 아이디 증가
        public void increaseID()
        {
            playerNum++;
            File.WriteAllText("playerNum_to_Server", playerNum.ToString());
        }

        //플레이어 사망 시 부활
        public void Die()
        {
            Console.Write($"{name}이(가) 죽었습니다. 부활합니다.\n");
            health = max_health;
        }
    }












    //몬스터 캐릭터 추상 클래스
    public abstract class Monster : ICharacter, IBattleCharacter, IDisposable
    {
        // 몬스터 상태와 기본 속성
        protected State currentState = State.Idle;
        protected string name;
        protected int level;
        protected int strength;
        protected int health;
        protected int max_health;

        private bool _disposed = false;

        // 캐릭터 생성 표시
        public void Display_Created()
        {
            Console.WriteLine($"{name}이(가) 나타났습니다.");
        }

        // 데미지 피격
        public void TakeDamage(int damage)
        {
            if (_disposed) throw new ObjectDisposedException(nameof(Monster));

            health -= damage;
            currentState = State.Combat;
            Console.WriteLine($"{name}(이)가 {damage} 데미지를 받았습니다.");
            if (health <= 0)
            {
                Die();
            }
        }

        // 몬스터 사망
        public void Die()
        {
            Console.WriteLine($"'{name}'이(가) 처치되었습니다.");
            Dispose(); // Dispose를 호출하여 리소스를 해제
        }

        // 리소스 해제
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // 관리되는 리소스 해제
                    name = null;
                }

                // 관리되지 않는 리소스 해제 (필요 시)
                level = 0;
                strength = 0;
                health = 0;
                max_health = 0;

                _disposed = true;
            }
        }

        ~Monster()
        {
            Dispose(false);
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







    //보스 캐릭터 클래스
    public class Boss : Monster
    {
        protected ICharacterState DifficultyState = new EasyMode(); //보스 기본 난이도 설정

        //보스 난이도 변경
        public void SetState(ICharacterState newState)
        {
            DifficultyState = newState;
        }

        //보스 공격 함수
        public void PerformAttack(BattleMediator _mediator)
        {
            DifficultyState.HandleAttack(_mediator, this, strength);
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
