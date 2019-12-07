using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReginaGameDev
{
    // Testing Class for Actors in BattleController (i.e. our 'Worms' aka Tomatoes and other veggies of doom)
    public class BattleActor
    {
        public string name;
        public float speed;

        public BattleActor(string name, float speed)
        {
            this.name = name;
            this.speed = speed;
        }
    }

}