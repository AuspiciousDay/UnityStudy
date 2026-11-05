using UnityEngine;
using TMPro;
using System.Collections;

public class GameOverWindow : GenericWindow
{
    public TMP_Text leftStatsLabel;
    public TMP_Text rightStatsLabel;
    public TMP_Text leftStatsValues;
    public TMP_Text rightStatsValues;
    public TMP_Text textTotalScore;

    private int[] scores = new int[6];
    private int totalScore;

    private Coroutine routine;

    public override void Open()
    {
        base.Open();
        routine = StartCoroutine(ResetScore());
    }

    public override void Close()
    {
        if (routine != null)
        {
            StopCoroutine(routine);
            routine = null;
        }
        base.Close();
    }

    private IEnumerator ResetScore()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(0, 10000);
        }
        totalScore = Random.Range(0, 1000000000);
        leftStatsLabel.text = string.Empty;
        rightStatsLabel.text = string.Empty;
        leftStatsValues.text = string.Empty;
        rightStatsValues.text = string.Empty;
        textTotalScore.text = string.Empty;
        for (int i = 0; i < scores.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            TMP_Text lable = i < 3 ? leftStatsLabel : rightStatsLabel;
            TMP_Text value = i < 3 ? leftStatsValues : rightStatsValues;

            lable.text += $"STAT {i + 1}\n";
            value.text += $"{scores[i]:D4}\n";
        }
        yield return new WaitForSeconds(0.5f);

        float elapsed = 0f;
        while (elapsed < 2f)
        {
            elapsed += Time.deltaTime;

            float t = elapsed / 2f;
            int value = Mathf.RoundToInt(Mathf.Lerp(0, totalScore, t)); //선형보간(실수값이 리턴) LerpUnclamped?
            textTotalScore.text = $"{value:D9}";
            yield return null;
        }
        textTotalScore.text = $"{totalScore:D9}";

    }
    /*
        for (int i = totalScore / 100; i <= totalScore; i += totalScore / 100)
        {
            textTotalScore.text = $"{i:D9}";
            yield return new WaitForSeconds(0.01f);
        }
        textTotalScore.text = $"{totalScore:D9}";
    */

    public void OnNext()
    {
        manager.Open(Windows.Start);
    }
}
