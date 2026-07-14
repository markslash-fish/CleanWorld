using UnityEngine;

[CreateAssetMenu(menuName = "Trash Monster Data", fileName = "TMonsterData")]
public class TrashMonsterData : ScriptableObject
{
    public string TMonsterName;
    public float moveSpd;
    public float healthpoints = 2F;
}
