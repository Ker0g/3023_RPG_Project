using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class Character 
{
   

    public string name;
    public int Level
    {
        get; private set;
    }

    private int health = 100;
    public int Health
    {
        get { return health; }
        private set { health = value; }
    }


    private int maxHealth = 100;
    public int MaxHealth 
    { 
        get { return maxHealth; } 
        private set { maxHealth = value; }
    }

    //private List<Ability> abilities;
    //public List<Ability> Abilities
    //{
    //    get { return abilities; }
    //    private set { abilities = value; }
    //}
    
    public Ability[] abilities = new Ability[4];

    Dictionary<string, int> status;

    public void AddStatus(string statusName, int duration)
    {
        if (status.ContainsKey(statusName))
        {
            status[statusName] += duration;
        }
        else
        {
            status.Add(statusName, duration);
        }
    }

    public Action<Character, int> onDamageTaken;

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (onDamageTaken != null)
        {
            onDamageTaken?.Invoke(this, damage);
        }
    }
}

