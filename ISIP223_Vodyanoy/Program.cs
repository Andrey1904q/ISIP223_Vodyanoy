using System;
using System.Collections.Generic;
using System.Linq;

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

    class 
    }

}

