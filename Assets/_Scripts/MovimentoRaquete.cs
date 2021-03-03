using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour {
    [Range(1,10)]
    public float velocidade;

    GameManager gm;
    // Start is called before the first frame update
    void Start() {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update() {
        // primeira execução nas rotinas de Update() da Bola e Raquete.
        if (gm.gameState != GameManager.GameState.GAME && gm.gameState != GameManager.GameState.PAUSE) {// ||) {
            if (gm.flagReset == true) {
                Reset();
            }
            return;
        }

        if (gm.gameState == GameManager.GameState.PAUSE) {
            return;
        }


        float inputX = Input.GetAxis("Horizontal");

        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        // Debug.Log($"InputX: {inputX}");
        if (posicaoViewport.x <= 0.05 && inputX <= 0.1) {
            transform.position += new Vector3(0, 0, 0) * Time.deltaTime * velocidade;
        } else if (posicaoViewport.x >= 0.95 && inputX >= 0.9) {
            transform.position -= new Vector3(0, 0, 0) * Time.deltaTime * velocidade;
        } else {
            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
        }
        
        
        

        if (Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
    }

    private void Reset() {
        transform.position = new Vector3(0, -4.0f, 0);
    }

}
