using UnityEngine;
using UnityEngine.UI;

public class UI_MenuPrincipal : MonoBehaviour {
    GameManager gm;

    // Start is called before the first frame update
    private void OnEnable() {
        gm = GameManager.GetInstance();
    }
    
    // Update is called once per frame
    public void Comecar() {
        gm.ChangeState(GameManager.GameState.GAME);
    }
}
