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
    public string Weapon {  get; set; }

    public string Equip { get; set; }

    public bool IsFrozen { get; set; } = false;

    public Player(int maxhp, int hp, int attack, int defence, string weapon, string equip, bool isfrozen)
        :base(maxhp, hp, attack, defence)
    {
        Weapon = weapon;
        Equip = equip;
        IsFrozen = isfrozen;
        MaxHP = 100;
    }

    public abstract class Enemy : Entity
    {
        public string Name { get; set; }

        public abstract void ApplySpecEff(Player player, Random rng);

        public Enemy(int maxhp, int hp, int attack, int defence, string name)
            :base(maxhp,hp, attack, defence)
        {
            Name = name;   
        }
    public class Goblin : Enemy
        {
            public double CritChance { get; set; } = 0.2;
            public Goblin()
            {
                Name = "Гоблин";
                MaxHP = HP = 30;
                Attack = 8;
                Defence = 3;
            }
                
                
                
                }
    }

    



