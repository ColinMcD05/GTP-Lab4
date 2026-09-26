using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    //Amount of meteors player has destroyed
    private int playerScore = 0;

    //Increase score
    public void GainedScore(int amountGained)
    {
        playerScore += amountGained;
    } 
    
    //Getters
    public int GetPlayerScore()
    {
        return playerScore;
    }
}
