using UnityEngine;


[CreateAssetMenu(menuName = "Query Data", fileName = "EcoTriviaData")]
public class EcoTriviaQueryData : ScriptableObject
{
    public int queryNumber;
    public string queryText;
    public string choice1, choice2, correctAnswer;
    
}
