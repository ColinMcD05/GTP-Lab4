using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    private int playerScore;

    public void GainedScore(int amountGained)
    {
        playerScore += amountGained;
    }    
}
