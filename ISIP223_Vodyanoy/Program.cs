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
    public void Heal()
    {
        HP = Math.Min(MaxHP, HP + amount);
    }

    public bool IsAlive => HP > 0;

}