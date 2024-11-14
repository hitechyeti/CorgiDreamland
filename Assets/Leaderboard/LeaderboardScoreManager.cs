using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class LeaderboardScoreManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI inputScore;
    [SerializeField] private TMP_InputField inputName;

    public UnityEvent<string, int> submitScoreEvent;

    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }
}
