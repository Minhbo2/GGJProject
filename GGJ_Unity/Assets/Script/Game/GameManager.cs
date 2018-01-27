using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState
{
    INITIALIZE,
    WAITING,
    LOADING,
    RUNNING
}



public class GameManager : MonoBehaviour {

    // Singleton pattern (used to access the single instance of the class from anywhere)
    public static GameManager Inst { get { return m_Inst; } }
    static GameManager m_Inst;

    public GameState CurrentState = GameState.INITIALIZE;

    public bool WantsToBeInWaitState,
                WantsToBeInLoadingState,
                WantsToBeInRunningState;



    void Awake()
    {
        // Set the instance for the singleton
        if (m_Inst == null)
            m_Inst = this;
    }




    public void Update()
    {

        // Main game STATE MACHINE
        switch (CurrentState)
        {
            case GameState.INITIALIZE:

                // Initialize your game here


                WantsToBeInWaitState = true;
                if (WantsToBeInWaitState)
                    DoStateTransition(GameState.WAITING);
                break;
            case GameState.WAITING:

                // The game is waiting for player input and other setups

                if (WantsToBeInLoadingState)
                    DoStateTransition(GameState.LOADING);

                break;
            case GameState.LOADING:

                // Load game data, saves, or waiting for game to create level
                // Once complete, switch to Running state

                WantsToBeInRunningState = true;
                if (WantsToBeInRunningState)
                    DoStateTransition(GameState.RUNNING);
                break;
            case GameState.RUNNING:

                // You might need a sub machine state here depending on your game.

                if (WantsToBeInWaitState)
                    DoStateTransition(GameState.WAITING);
                break;
        }
    }

    // Use this to do state transitions in case we later need to keep track of the previous state
    private void DoStateTransition(GameState newState)
    {
        // Set the new state
        CurrentState = newState;

        // Clear all of our flags
        WantsToBeInWaitState = false;
        WantsToBeInLoadingState = false;
        WantsToBeInRunningState = false;
    }
}
