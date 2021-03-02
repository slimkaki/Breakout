using UnityEngine;
using UnityEngine.UI;
public class UI_Pause : MonoBehaviour {

    GameManager gm;
    // Start is called before the first frame update
    private void OnEnable() {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    public void Retornar() {
        gm.ChangeState(GameManager.GameState.GAME);
    }

    public void Inicio() {
        gm.ChangeState(GameManager.GameState.MENU);
    }
}
