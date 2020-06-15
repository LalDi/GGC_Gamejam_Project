using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UI_Score : MonoBehaviour
{
    public Image ScoreGauge;
    [Range(0,800)] public int Score;
    private int MaxScore = 800;

    void Update()
    {
        Score = GameManager.Instance.Score;
        ScoreGauge.fillAmount = Mathf.Lerp(0f, 1f, (float)Score / MaxScore);
    }
}
