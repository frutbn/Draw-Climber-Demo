using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class UIManager : Manager<UIManager>
{
    [Header("Panels")]
    [SerializeField] private GameObject Panel_Finish;
    [SerializeField] private GameObject Panel_Game;

    [Header("DrawZone")]
    [SerializeField] private RawImage rawImage_Draw_Zone;
    [SerializeField] private Transform Image_Draw_Zone_Background;

    [Header("Finish")]
    [SerializeField] private TMP_Text Text_Win_Lose;
    [SerializeField] private GameObject Button_Next_LevelOBJ;
    [SerializeField] private GameObject Button_RetryOBJ;

    private void Start()
    {
        SetDrawZone();
    }

    private void SetDrawZone()
    {
        rawImage_Draw_Zone.texture.width = Screen.width;
        rawImage_Draw_Zone.texture.height = Screen.height;
        rawImage_Draw_Zone.transform.SetParent(Image_Draw_Zone_Background.transform);
    }

    public void SetFinishPanel(string tag)
    {
        Panel_Game.SetActive(false);
        Panel_Finish.SetActive(true);

        Button_Next_LevelOBJ.SetActive(false);
        Button_RetryOBJ.SetActive(false);

        switch (tag)
        {
            case "Player":
                Text_Win_Lose.text = "VICTORY!";
                Button_Next_LevelOBJ.SetActive(true);
                break;
            case "AIPlayer":
                Text_Win_Lose.text = "LOSE!";
                Button_RetryOBJ.SetActive(true);
                break;
        }
    }

    public void Button_ChangeGameObjectEnabling(GameObject obj) => obj.SetActive(!obj.activeSelf);

    public void Button_Retry()
    {
        GameManager.Instance.ResetGame();
    }

    public void Button_NextLevel()
    {
        GameManager.Instance.ResetGame();
        LevelManager.Instance.NextLevel();
    }
}