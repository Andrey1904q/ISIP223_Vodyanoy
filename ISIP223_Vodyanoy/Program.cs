using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

public  abstract class Entity 


{

    public int MaxHP { get; set; }

    public int HP { get; set; }
    
    public int Attack { get; set; }

    public int Defence { get; set; }

    public Entity(int maxhp, int hp, int attack, int defence)
    {
        MaxHP = maxhp; 
        HP = hp;
        Attack = attack;
        Defence = defence;
    }
    public void Heal(int amount)
    {
        HP = Math.Min(MaxHP, HP + amount);
    }

    public bool IsAlive => HP > 0;

}

class Player : Entity
{
    public string Weapon { get; set; }

    public string Equip { get; set; }

    public bool IsFrozen { get; set; } = false;

    public Player(int maxhp, int hp, int attack, int defence, string weapon, string equip, bool isfrozen)
        : base(maxhp, hp, attack, defence)
    {
        Weapon = weapon;
        Equip = equip;
        IsFrozen = isfrozen;
        MaxHP = 100;
        MaxHP = HP;
    }

    public abstract class Enemy : Entity
    {
        public string Name { get; set; }

        public abstract void ApplySpecEff(Player player, Random rng);

        public Enemy(int maxhp, int hp, int attack, int defence, string name)
            : base(maxhp, hp, attack, defence)
        {
            Name = name;
        }
        public class Goblin : Enemy
        {
            public double CritChance { get; set; } = 0.2;
            public Goblin(int maxhp, int hp, int attack, int defence, string name, double critchance)
                : base(maxhp, hp, attack, defence, name)
            {
                Name = "Гоблин";
                MaxHP = HP = 30;
                Attack = 8;
                Defence = 3;
            }
            public override void ApplySpecEff(Player player, Random rng)
            {
                if (rng.NextDouble() < CritChance)
                {
                    Console.WriteLine("Гоблин наносит критический удар");
                    Attack = (int)(Attack * 1.5);

                }

            }
        }
        public class Skelet : Enemy
        {
            public Skelet(int maxhp, int hp, int attack, int defence, string name)
                : base(maxhp, hp, attack, defence, name)
            {
                Name = "Скелет";
                MaxHP = HP = 44;
                Attack = 7;
                Defence = 2;
            }
            public override void ApplySpecEff(Player player, Random rng)
            {
                Console.WriteLine("Скелет игнорирует вашу защиту.");

            }
        }
        public class Mage : Enemy
        {
            public double FreezeChance { get; set; } = 0.25;
            public Mage(int maxhp, int hp, int attack, int defence, string name, double freezechance)
                : base(maxhp, hp, attack, defence, name)
            {
                Name = "Маг";
                MaxHP = HP = 60;
                Attack = 9;
                Defence = 1;
            }
            public override void ApplySpecEff(Player player, Random rng)
            {
                if (rng.NextDouble() < FreezeChance)
                {

                    Console.WriteLine("На нас наложили морозное заклинание. Вы пропускаете ход ");
                    player.IsFrozen = true;
                }
            }
        }

        public class VVG : Goblin
        {
            public VVG(int maxhp, int hp, int attack, int defence, string name, double critchance)
                : base(maxhp, hp, attack, defence, name, critchance)
            {
                Name = "Босс ВВГ (гоблин)";
                MaxHP = HP = (int)(30 * 2.0);
                Attack = (int)(8 * 1.5);
                Defence = (int)(3 * 1.2);
                CritChance += 0.1;
            }
        }
        public class Kovaleskiy : Skelet
        {
            public Kovaleskiy(int maxhp, int hp, int attack, int defence, string name)
                : base(maxhp, hp, attack, defence, name)
            {
                Name = "Босс Скелет Ковалевский";
                MaxHP = HP = (int)(44 * 2.5);
                Attack = (int)(7 * 1.5);
                Defence = (int)(2 * 1.4);
            }
        }
        public class Arcmag : Mage
        {
            public Arcmag(int maxhp, int hp, int attack, int defence, string name, double freezechance)
                : base(maxhp, hp, attack, defence, name, freezechance)
            {
                Name = "Босс Архимаг C++";
                MaxHP = HP = (int)(60 * 1.8);
                Attack = (int)(9 * 1.6);
                Defence = (int)(1 * 1.1);
                FreezeChance += 0.1;
            }

        }
        public class Pestov : Skelet
        {

            public double FreezeChance { get; set; } = 0.25 + 0.15;
            public Pestov(int maxhp, int hp, int attack, int defence, string name)
                : base(maxhp, hp, attack, defence, name)
            {
                Name = "Босс Скелет Пестов";
                MaxHP = HP = (int)(44 * 1.3);
                Attack = (int)(7 * 1.8);
                Defence = (int)(2 * 0.6);
            }
            public override void ApplySpecEff(Player player, Random rng)
            {
                if (rng.NextDouble() < FreezeChance)
                {
                    Console.WriteLine("Пестов заморозил вас. Вы пропускаете один ход");
                    player.IsFrozen = true;
                }
            }
        }
        public class Weapon
        {
            public string Name { get; set; }
            public int Damage { get; set; }

            public Weapon(string name, int damage)
            {
                Name = name;
                Damage = damage;
            }

            public override string ToString() => $"{Name} (урон:  {Damage})";

        }
        public class Armor
        {
            public string Name { get; set; }
            public int DefenseValue { get; set; }

            public Armor(string name, int defenseValue)
            {
                Name = name;
                DefenseValue = defenseValue;

            }
            public override string ToString() => $"{Name} (защита: {DefenseValue})";
        }
    }
}

class Program
{
    static Random rng = new Random();
    static Player player = new Player();
    static int turn = 0;

    static void Main(string[] args)
    {
        Console.WriteLine("добро пожаловать в игру.\n");
        Console.WriteLine("Каждый ход либо сундук либо враг, но каждые 10 ходов будет босс");
        Console.WriteLine("удачи");
    
    while (player.IsAlive)
        {
            turn++;
            Console.WriteLine($"\nВаш ход.");
            Console.WriteLine("Здоровье: {player.HP}/{player.MaxHP} | Оружие: {player.Weapon} | Броня: {player.Armor}");


        }