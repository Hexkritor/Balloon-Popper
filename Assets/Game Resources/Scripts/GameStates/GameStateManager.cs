using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hexkritor.BalloonPopper.GameStates
{
    public class GameStateManager : MonoBehaviour
    {
        [SerializeField]
        private GameStateType startState;
        [SerializeField]
        private List<AbstractGameState> states = new();

        private AbstractGameState currentState;

        public void Initialize()
        {
            InitializeAll();
            HideAll();
            ShowState(startState);
        }

        public void ShowState(GameStateType type)
        {
            currentState?.Hide();
            currentState = FindState(type);
            currentState?.Show();
        }

        private void InitializeAll()
        {
            foreach (var state in states)
            {
                state.Initialize(this);
            }
        }

        private void HideAll()
        {
            foreach (var state in states)
            {
                state.Hide();
            }
        }

        private AbstractGameState FindState(GameStateType type)
        {
            return states.Find(x => x.StateType == type);
        }
    }
}
