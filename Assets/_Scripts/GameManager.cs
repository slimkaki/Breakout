using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
    public enum GameState { MENU, GAME, PAUSE, ENDGAME };
    public GameState gameState { get; private set; }
    public int vidas;
    public int pontos;

    public bool flagReset = false;
    public bool needToRebuild = false;

    private static GameManager _instance;

    public delegate void ChangeStateDelegate();
    public static ChangeStateDelegate changeStateDelegate;

    public void ChangeState(GameState nextState) {
        if ((gameState == GameState.MENU && nextState == GameState.GAME) || (gameState == GameState.ENDGAME && nextState == GameState.GAME)) {
            flagReset = true;
            needToRebuild = true;
            Reset();
        }
        gameState = nextState;
        changeStateDelegate();
    }

    private void Reset() {
        vidas = 3;
        pontos = 0;
    }

    public static GameManager GetInstance() {
        if (_instance == null) {
            _instance = new GameManager();
        }

        return _instance;
    }

    private GameManager() {
        vidas = 3;
        pontos = 0;
        gameState = GameState.MENU;
    }
}
