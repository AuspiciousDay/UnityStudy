using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public enum Difficulty
    {
        None = -1,
        Easy,
        Normal,
        Hard
    }
    public Toggle[] toggles;

    public Difficulty CurrentDifficulty
    {
        get
        {
            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i].isOn)
                {
                    return (Difficulty)i;
                }
            }
            return Difficulty.None;
        }
        set
        {
            toggles[(int)value].isOn = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerPrefs.SetInt("Difficulty", (int)CurrentDifficulty);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InputESC();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int index = (int)CurrentDifficulty;
            index = (int)Mathf.Repeat(index + 1, toggles.Length);
            CurrentDifficulty = (Difficulty)index;
            /*
            if((int)CurrentDifficulty == 2)
            {
                CurrentDifficulty = 0;
            }
            else
            {
                CurrentDifficulty++;
            }
            */
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int index = (int)CurrentDifficulty;
            index = (int)Mathf.Repeat(index - 1, toggles.Length);
            CurrentDifficulty = (Difficulty)index;
            /*
            if(CurrentDifficulty == 0)
            {
                CurrentDifficulty = (Difficulty)2;
            }
            else
            {
                CurrentDifficulty--;
            }
            */
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            manager.Open(Windows.GameOver);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentDifficulty = (Difficulty)0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentDifficulty = (Difficulty)1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentDifficulty = (Difficulty)2;
        }
    }


    public void OnClickEasy(bool value)
    {
        Debug.Log($"OnClickEasy: {value}");
    }

    public void OnClickNormal(bool value)
    {
        Debug.Log($"OnClickNormal: {value}");
    }

    public void OnClickHard(bool value)
    {
        Debug.Log($"OnClickHard: {value}");
    }

    public void InputESC()
    {
        manager.Open(Windows.Start);
    }
    public override void Open()
    {
        CurrentDifficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty", 1);
        base.Open();
    }
    public override void Close()
    {
        PlayerPrefs.SetInt("Difficulty", (int)CurrentDifficulty);
        base.Close();
    }
}
