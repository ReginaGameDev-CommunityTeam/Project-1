using System.Collections.Generic;
using UnityEngine;


namespace ReginaGameDev
{
    public class InitiativeSystem
    {
        public List<BattleActor> queue;

        public void SetupInitiativeQueue()
        {
            if (queue == null)
            {
                queue = new List<BattleActor>();
            }

            // For testing purposes, let's set up 8 potential "Actors" - 4 Players, 4 Enemies
            Debug_PopulateInitiativeQueue(4, 4);

            ReorderInitiativeQueue();

            Debug_ShowInitiativeQueue();
        }

        private static int InitiativeQueueSortBySpeed(BattleActor x, BattleActor y) // this method becomes an IComparable by default and when used on a List<> must pass x and y of the type in the list (i.e. BattleActor in this case)
        {
            // Check if equal to, greater, or less than
            if (x.speed == y.speed)
            { 
                // if equal to, there should be some randomization here on just WHICH gets to go first
                return 0;
            }
            else if (x.speed > y.speed)
            {
                // if the current BattleActor is faster than the next BattleActor, move the current BattleActor closer to the 0-index of the List
                return -1;
            }
            else if (x.speed < y.speed)
            {
                // if the current BattleActor is slower than the next BattleActor, move the current BattleActor further from the 0-index of the List
                return 1;
            }
            else 
            {
                // catch-all case - make no adjustments
                return 0;
            }
        }

        // This method is necessary because speeds of the BattleActors in the queue may change, new BattleActors may be added, and old ones may be removed.
        public void ReorderInitiativeQueue()
        {
            queue.Sort( InitiativeQueueSortBySpeed ); // in order to do this, the method has to be private static int
        }

        public void RemoveFromInitiativeQueue(BattleActor ba)
        {
            queue.Remove(ba);
        }

        public void AddToInitiativeQueue(BattleActor ba)
        {
            queue.Add(ba);
        }

        public void RandomlyInsertIntoInitiativeQueue(BattleActor ba)
        {
            int posi = UnityEngine.Random.Range(0, queue.Count);
            queue.Insert(posi, ba);
        }

        public void InsertIntoInitiativeQueueAtIndex(BattleActor ba, int index)
        {
            if (index >= queue.Count)
            {
                Debug.LogWarning("WARNING: Inserting into Initiative Queue at an out-of-bounds index of " + index.ToString() + ". Inserting at the end instead.");
                AddToInitiativeQueue(ba);
            }
            else
            {
                queue.Insert(index, ba);
            }
        }

        // Move the current BattleActor to the last position in the initiativeQueue
        public void MoveCurrentToLastPosition()
        {
            BattleActor cba; // Current Battle Actor
            cba = queue[0];
            RemoveFromInitiativeQueue(queue[0]);
            AddToInitiativeQueue(cba);
        }

        // For debugging purposes, show the contents of initiativeQueue in the debug console...
        public void Debug_ShowInitiativeQueue()
        {
            for(int i = 0; i < queue.Count; i++)
            {
                Debug.Log(i + ") " + queue[i].name + ": " + queue[i].speed);
            }
            Debug.LogError("\n\n\n");
        }

        // For debugging purposes, randomize everyone's speed inside the initiativeQueue...
        public void Debug_RandomizeAllInitiativeQueueSpeeds()
        {
            for (int i = 0; i < queue.Count; i++)
            {
                queue[i].speed = UnityEngine.Random.Range(1.0f, 40.0f);
            }
        }

        // For debugging purposes, populate the initiativeQueue with X Players and Y Enemies with a speed range default of 1 to 50
        private void Debug_PopulateInitiativeQueue(int numPlayers, int numEnemies, float minSpeed = 1, float maxSpeed = 50)
        {
            // Run out-of-bounds checks here... 
            if (numPlayers < 0) numPlayers = 0;
            if (numEnemies < 0) numEnemies = 0;
            if (minSpeed <= 0) minSpeed = 1;
            if (maxSpeed <= minSpeed) maxSpeed = minSpeed + 1;

            // Generate a Random() seed...
            // ... not implemented yet ...

            // Run checks to skip population of Players and Enemies if numN is 0
            if (numPlayers != 0)
            {
                for (int i = 1; i <= numPlayers; i++)
                {
                    AddToInitiativeQueue(new BattleActor(
                                                        "Player" + i.ToString(), 
                                                        UnityEngine.Random.Range(minSpeed, maxSpeed)
                                                        )
                                        );
                }
            }

            if (numEnemies != 0)
            {
                for (int i = 1; i <= numEnemies; i++)
                {
                    AddToInitiativeQueue(new BattleActor(
                                                        "Enemy" + i.ToString(), 
                                                        UnityEngine.Random.Range(minSpeed, maxSpeed)
                                                        )
                                        );
                }
            }
        }
    }

}