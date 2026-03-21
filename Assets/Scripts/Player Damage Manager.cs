using UnityEngine;

public class PlayerDamageManager : MonoBehaviour
{
    public int baseDamage = 1;
    public int currentDamage;

    private void Start()
    {
        currentDamage = baseDamage;
    }

    public void AddFriendBonus(int bonus)
    {
        currentDamage += bonus;
        Debug.Log("Damage increased! New damage: " + currentDamage);
    }
}
