using UnityEngine;
using UnityEngine.UI;

public class UI_Pontos : MonoBehaviour {

    Text textComp;
    GameManager gm;
    // Start is called before the first frame update
    void Start() {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update() {
        if (gm.gameState == GameManager.GameState.MENU) { 
            textComp.text = " ";
            return;
        }
        textComp.text = $"Pontos: {gm.pontos}";
    }
}
