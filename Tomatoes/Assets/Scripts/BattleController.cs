using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReginaGameDev
{

    public class BattleController : MonoBehaviour
    {

        public ReginaGameDev.InitiativeSystem initiative; // This declaration would be commented out if the system is not currently implemented...

        void Start()
        {
            Debug.Log("Initiative System Module Loaded? " + ReginaGameDev.Modules.INITIATIVE_SYSTEM.ToString());
            if (ReginaGameDev.Modules.INITIATIVE_SYSTEM)
            {
                // If the code was not yet implemented, this entire area would be empty until interactions between systems can be done (i.e. Initiative System is implemented)
                initiative = new ReginaGameDev.InitiativeSystem();
                initiative.SetupInitiativeQueue();
            }
        }

        void Update()
        {
            if (ReginaGameDev.Modules.INITIATIVE_SYSTEM)
            {
                // If the code was not yet implemented, this entire area would be empty until interactions between systems can be done (i.e. Initiative System is implemented) 

                // All of the following code accomplishes nothing and is here for the sole purpose of testing the methods and functions of the initiative system...

                // Add a new, randomly-generated BattleActor to the initiativeQueue
                if (Input.GetKeyDown(KeyCode.A))
                {
                    float rnd = UnityEngine.Random.Range(0, 40);
                    initiative.AddToInitiativeQueue(new BattleActor("New BA #" + rnd.ToString(), rnd));
                    initiative.ReorderInitiativeQueue();
                    initiative.Debug_ShowInitiativeQueue();
                }
                // Remove a random BattleACtor from the initiativeQueue
                else if (Input.GetKeyDown(KeyCode.R))
                {
                    if ( initiative.queue.Count <= 0) return;
                    int rnd = UnityEngine.Random.Range(0, initiative.queue.Count);
                    initiative.RemoveFromInitiativeQueue(initiative.queue[rnd]);
                    initiative.ReorderInitiativeQueue();
                    initiative.Debug_ShowInitiativeQueue();
                }
                // Randomize Speeds
                else if (Input.GetKeyDown(KeyCode.Space))
                {
                    initiative.Debug_RandomizeAllInitiativeQueueSpeeds();
                    initiative.ReorderInitiativeQueue();
                    initiative.Debug_ShowInitiativeQueue();
                }
                // Put Current to Back of iniatitiveQueue
                else if (Input.GetKeyDown(KeyCode.X))
                {
                    initiative.MoveCurrentToLastPosition();
                    initiative.Debug_ShowInitiativeQueue();
                }
                // Insert into initiative.queue at index of 4 -- HARD CODED
                else if (Input.GetKeyDown(KeyCode.I))
                {
                    initiative.InsertIntoInitiativeQueueAtIndex(new BattleActor("InsertedActor", 28), 4);
                    Debug.Log("Showing Queue after inserting at index 4, but before sorting...");
                    initiative.Debug_ShowInitiativeQueue();
                    Debug.Log("Showing Queue after sorting after the insertion...");
                    initiative.ReorderInitiativeQueue();
                    initiative.Debug_ShowInitiativeQueue();
                }
                // Insert into initiative.queue randomly
                else if (Input.GetKeyDown(KeyCode.O))
                {
                    initiative.RandomlyInsertIntoInitiativeQueue(new BattleActor("InsertedActor", 28));
                    Debug.Log("Showing Queue after inserting randomly, but before sorting...");
                    initiative.Debug_ShowInitiativeQueue();
                    Debug.Log("Showing Queue after sorting after the insertion...");
                    initiative.ReorderInitiativeQueue();
                    initiative.Debug_ShowInitiativeQueue();
                }
            }
            else
            {
                // if the Initiative System is not present for whatever reason, execute the code here instead...
            }
        }

    }

}
