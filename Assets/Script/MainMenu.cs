using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // NEW

public class MainMenu : MonoBehaviour
{
// NEW: Reference to Total Brain UI
[SerializeField]
private TextMeshProUGUI _totalBrainText;

// NEW: Display saved total brain
private void Start()
{
int totalBrain = PlayerPrefs.GetInt("TotalBrain", 0);

if (_totalBrainText != null)
{
_totalBrainText.text = "Total brain collected : " + totalBrain;
}
}

public void PlayGame()
{
SceneManager.LoadScene("GameScene1");
}
}