using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour {
    [Range(1,15)]
    public float velocidade = 5.0f;
    private Vector3 direcao;

    public Transform explosion;

    GameManager gm;
    // Start is called before the first frame update
    void Start() {
        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);

        direcao = new Vector3(dirX, dirY).normalized;

        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update() {
        if (gm.gameState != GameManager.GameState.GAME && gm.gameState != GameManager.GameState.PAUSE) {//|| gm.gameState != GameManager.GameState.PAUSE) {
            if (gm.flagReset == true) {
                Reset();
            }
            return;
        }

        if (gm.gameState == GameManager.GameState.PAUSE) {
            return;
        }

        transform.position += direcao * Time.deltaTime * velocidade;   
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        // // Debug.Log($"posicao: ({posicaoViewport.x}, {posicaoViewport.x})");
        if (posicaoViewport.x < 0 || posicaoViewport.x > 1) {
        //     // Debug.Log($"posicao: ({posicaoViewport.x}, {posicaoViewport.y})");
            
            direcao = new Vector3(-direcao.x, direcao.y);
        }
        else if (posicaoViewport.y > 1) {
            // Debug.Log($"posicao: ({posicaoViewport.x}, {posicaoViewport.y})");
            
            direcao = new Vector3(direcao.x, -direcao.y);
        }
        else if (posicaoViewport.y < 0) {
            // Debug.Log($"posicao: ({posicaoViewport.x}, {posicaoViewport.y})");
            PerdeVida();
        }
    }



    private void PerdeVida() {
       Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
       transform.position = playerPosition + new Vector3(0, 0.5f, 0);

       float dirX = Random.Range(-5.0f, 5.0f);
       float dirY = Random.Range(2.0f, 5.0f);

       direcao = new Vector3(dirX, dirY).normalized;
       
       gm.vidas--;
       if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME) {
           gm.ChangeState(GameManager.GameState.ENDGAME);
       }
    }

    private void Reset() {
       Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
       transform.position = playerPosition + new Vector3(0, 0.5f, 0);

       float dirX = Random.Range(-5.0f, 5.0f);
       float dirY = Random.Range(2.0f, 5.0f);

       direcao = new Vector3(dirX, dirY).normalized;
       
       if (gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME) {
           gm.ChangeState(GameManager.GameState.ENDGAME);
       }

    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.CompareTag("Player")) {
            // SoundEffectsManager.PlaySound("hit");
            // float dirX = Random.Range(-5.0f, 5.0f); 
            float dirY = Random.Range(1.0f, 5.0f); 

            float dirX = transform.position.x - col.transform.position.x;

            direcao = new Vector3(dirX*1.5f, dirY).normalized;

        // } else if (col.gameObject.CompareTag("Parede")) {
        //     if (direcao.x > 0){
        //         direcao = new Vector3(-direcao.x, direcao.y);
        //     }
        //     if (direcao.y > 0) {
        //         direcao = new Vector3(direcao.x, -direcao.y);
        //     }
        //     if (direcao.x < 0) {
        //         direcao = new Vector3(direcao.x, -direcao.y);
        //     }

        } else if (col.gameObject.CompareTag("Tijolo")) {
            Transform newExplosion = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(newExplosion.gameObject, 2.5f);
            SoundEffectsManager.PlaySound("hit2");
            direcao = new Vector3(direcao.x, -direcao.y);
            gm.pontos++;
        }
    }
}
