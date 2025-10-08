using System;
using System.Collections.Generic;
using System.Linq;

public class Player
{
    public string Name { get; set; }
    public double HP { get; set; }

    public int MaxHP { get; set; }

    public string Equip {  get; set; }

    public string Weapon {  get; set; }

    public Player(string name, double hp, string equip, string weapon)
    {
        Name = name;
        HP = hp;
        Equip = equip;
        Weapon = weapon;
    }

    public void Heal()
    {
        HP = Math.Min(MaxHP, HP + amount);
    }

    public bool IsAlive => HP > 0;
}