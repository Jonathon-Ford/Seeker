using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSelection : MonoBehaviour
{
    public Monster[] monsters = new Monster[4];
    void Start()
    {
        Monster Arachnid = new Monster
        {
            id = 1,
            name = "Arachnid",
            image = "none",
            description = "Grow stronger by hunting prey and eventually elimnate the enemy players"
        };

        monsters[0] = Arachnid;

        Monster Werewolf = new Monster
        {
            id = 2,
            name = "Werewolf",
            image = "none",
            description = "Spawn in as a player and keep your secret hidden, strike with the full moon"
        };

        monsters[1] = Werewolf;

        Monster Vampire = new Monster
        {
            id = 3,
            name = "Vampire",
            image = "none",
            description = "Spawn in as a player and keep your secret hidden, create thralls until all players are under your control"
        };

        monsters[2] = Vampire;

        Monster Poltergeist = new Monster
        {
            id = 4,
            name = "Poltergeist",
            image = "none",
            description = "I don't actually know what the win condition here is yet, but don't get banished"
        };

        monsters[3] = Poltergeist;
    }

    public Monster[] GetMonsters()
    {
        return monsters;
    }


}

public class Monster
{
    public int id { get; set; }
    public string name { get; set; }
    public string image { get; set; }
    public string description { get; set; }
}
