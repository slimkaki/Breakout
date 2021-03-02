using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoSpawner : MonoBehaviour {
    public GameObject Bloco;
    GameManager gm;

    void Start() {
        gm = GameManager.GetInstance();
        GameManager.changeStateDelegate += Construir;
        gm.needToRebuild = true;
        Construir();
    }

    void Construir() {
        if (gm.needToRebuild == true) {
            foreach (Transform child in transform) {
                GameObject.Destroy(child.gameObject);
            }
            for(int i = 0; i < 12; i++) {
                for(int j = 0; j < 4; j++) {
                    
                    Vector3 posicao = new Vector3(-9f + 1.55f * i + 0.48f, 4 - 0.55f * j);

                    Instantiate(Bloco, posicao, Quaternion.identity, transform);
                }
            }
            gm.needToRebuild = false;
        }
    }

    void Update() {
        if (gm.gameState == GameManager.GameState.PAUSE) {
            return;
        }
        if (transform.childCount <= 0 && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.ENDGAME);
        }
    }
}