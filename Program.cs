using System.Diagnostics;
using characterFactory;
using characterInterface;
using characterState;

public class Program
{
    public static void Main(string[] args)
    {
        CharacterFactory[] characterFactory =
        {
            new PlayerFactory(),
            new GoblinFactory(),
            new SlimeFactory()
        };

        ICharacter player1 = characterFactory[0].CreateOperation();
        ICharacter goblin1 = characterFactory[1].CreateOperation();
        ICharacter Slime1 = characterFactory[2].CreateOperation();

        player1.Attack();
    }
}
