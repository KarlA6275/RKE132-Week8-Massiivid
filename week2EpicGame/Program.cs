string folderPath = @"C:\data\";
string heroFile = "heros.txt";
string villainFile = "villains.txt";

string[] heros = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villans = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "Magic Wand", "Plastic Fork", "banananana", "Kohuke", "flower"};


string hero = GetRandomValueFromArray(heros);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrenght = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP) with {heroWeapon} is here to protect the castle");


string villan = GetRandomValueFromArray(villans);
string villanWeapon = GetRandomValueFromArray(weapon);
int villanHP = GetCharacterHP(villan);
int villanStrikeStrenght = villanHP;
Console.WriteLine($"Today {villan}  ({villanHP} HP) with {villanWeapon} tries to conqure the castle");


while (heroHP > 0 && villanHP > 0)
{
    heroHP = heroHP - Hit(villan, villanStrikeStrenght);
    villanHP = villanHP - Hit(hero, heroStrikeStrenght);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villan {villan} HP: {villanHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villanHP > 0)
{
    Console.WriteLine($"The dark side wins!");
}
else
{
    Console.WriteLine("Draw"!);
}

static string GetRandomValueFromArray(string[] someArray) 
{
    Random random = new Random(); 
    int randomIndex = random.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray; 
}


static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}


static int Hit(string characterName, int CharacterHP)
{
    Random random = new Random();
    int strike = random.Next(0, CharacterHP);

    if(strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == CharacterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}
