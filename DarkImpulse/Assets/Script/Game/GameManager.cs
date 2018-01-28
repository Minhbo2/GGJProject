
using UnityEngine;





public class GameManager : MonoBehaviour {

    // Singleton pattern (used to access the single instance of the class from anywhere)
    public static GameManager Inst { get { return m_Inst; } }
    static GameManager m_Inst;

    public UIManager uiManager;


    private GameObject hider;
    private GameObject[] seeker;

    public float currentTime;

    [SerializeField]
    public float maxRoundTime;


    private void Start()
    {
        if (m_Inst == null)
            m_Inst = this;
    }


    private void Update()
    {
        currentTime = maxRoundTime - Time.time;

        if (currentTime <= 0 && !GameIsOver())
        {
            uiManager.HiderWin();
            Time.timeScale = 0;
        }

        if (GameIsOver())
        {
            uiManager.SeekerWin();
            Time.timeScale = 0;
        }
    }


    bool GameIsOver()
    {
        seeker = GameObject.FindGameObjectsWithTag("Hider");

        if (seeker.Length < 1)
            return true;
        return false;
    }
}
