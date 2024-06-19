using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int multiplier = 1; // Inisialisasi dengan nilai 1
    int streak = 0;

    void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("RockMeter", 1);
    }

    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        Destroy(col.gameObject);
    }

    void UpdateGUI()
    {
        PlayerPrefs.SetInt("Streak", streak);
        PlayerPrefs.SetInt("Multi", multiplier);
    }

    public void AddStreak()
    {
        if (PlayerPrefs.GetInt("RockMeter") + 1 < 50)
            PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") + 1);
        streak++;
        if (streak >= 24)
            multiplier = 4;
        else if (streak >= 16)
            multiplier = 3;
        else if (streak >= 8)
            multiplier = 2;
        else
            multiplier = 1;

        UpdateGUI(); // Update GUI setelah mengubah streak dan multiplier
    }

    public void ResetStreak()
    {
        PlayerPrefs.SetInt("RockMeter", PlayerPrefs.GetInt("RockMeter") - 2);
        if (PlayerPrefs.GetInt("RockMeter") < 0)
            Lose();
        streak = 0;
        multiplier = 1;
        UpdateGUI();
    }

    void Lose()
    {
        print("LOSER!");
    }

    public void Win()
    {
        print("You Win!");
    }

    public int GetScore()
    {
        return 10 * multiplier;
    }
}