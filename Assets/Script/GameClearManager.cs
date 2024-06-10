using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    public GameObject gameClearPanel;

    public void ShowGameClearUI()
    {
        gameClearPanel.SetActive(true);
    }
}
