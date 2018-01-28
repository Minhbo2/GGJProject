
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private Text gameTimer;
    [SerializeField]
    private Text endText;
    [SerializeField]
    private GameObject WinLosePanel;


    private void Update()
    {
        int currentLevelTime = Mathf.RoundToInt(GameManager.Inst.currentTime);
        gameTimer.text = "Time left: " + currentLevelTime;
    }



    public void HiderWin()
    {
        WinLosePanel.SetActive(true);
        endText.text = "Hider Win!";
    }

    public void SeekerWin()
    {
        WinLosePanel.SetActive(true);
        endText.text = "Seeker Win!";
    }
}
