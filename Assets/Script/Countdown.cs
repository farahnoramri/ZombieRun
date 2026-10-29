
using System.Collections;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [Header("Countdown UI")]
    [SerializeField] private TMP_Text countdownText;

    private void Start()
    {
        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        // Freeze gameplay
        Time.timeScale = 0f;

        // Show countdown
        countdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            // Play countdown sound
            Audio.Instance.PlayCountdown();

            yield return new WaitForSecondsRealtime(1f);
        }

        countdownText.text = "GO!";
        yield return new WaitForSecondsRealtime(1f);
        countdownText.gameObject.SetActive(false);

        // Resume gameplay
        Time.timeScale = 1f;
    }
}


