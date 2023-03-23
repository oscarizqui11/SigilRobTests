using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

[CreateAssetMenu(menuName = "FSM/GameManager/Decision/ChangeGameState")]
public class DecChangeGameState : Decision
{
    [SerializeField] private int gameState;

    public override bool Decide(Controller controller)
    {
        GameManager _gameManager = (GameManager)controller;
        
        if (_gameManager.gameState == gameState)
        {
            for (int i = 0; i < _gameManager.controllers.Count; i++)
                if (_gameManager.GameState[i] == gameState)
                    _gameManager.controllers[i].ActiveObject = true;
                else
                    _gameManager.controllers[i].ActiveObject = false;

            return true;
        }
        else
            return false;
    }
}
