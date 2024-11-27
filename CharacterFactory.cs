using System;
using System.IO;
using System.Runtime.ConstrainedExecution;
using characterInterface;

namespace characterFactory
{
    // 캐릭터 팩토리
    public abstract class CharacterFactory
    {
        public ICharacter CreateOperation()
        {
            ICharacter character = CreateCharacter();
            character.Display();
            character.GetInfo();
            return character;
        }

        public abstract ICharacter CreateCharacter();
    }

    public class PlayerFactory : CharacterFactory
    {
        public override ICharacter CreateCharacter()
        {
            // 기본값을 사용하여 Player 인스턴스 생성
            Player player = new Player();
            player.SaveInfoToFile($"{player.name} 정보.txt"); // 정보 파일로 저장
            player.increaseID();
            return player;
        }
    }

    public class GoblinFactory : CharacterFactory
    {
        public override ICharacter CreateCharacter()
        {
            // 기본값을 사용하여 Goblin 인스턴스 생성
            string name = $"고블린 {Goblin.goblinNum}";;
            int level = 1;
            int strength = 5;
            int health = 50;

            Goblin goblin = new Goblin(name, level, strength, health);
            return goblin;
        }
    }

    public class SlimeFactory : CharacterFactory
    {
        public override ICharacter CreateCharacter()
        {
            // 기본값을 사용하여 Slime 인스턴스 생성
            string name = $"슬라임 {Slime.slimeNum}";;
            int level = 1;
            int strength = 3;
            int health = 30;

            Slime slime = new Slime(name, level, strength, health);
            return slime;
        }
    }
}