using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;    // ���a�̤j�ͩR��
    public int currentHealth;      // ���a��e�ͩR��

    void Start()
    {
        // ��l�ƪ��a�ͩR��
        currentHealth = maxHealth;
    }

    public void Heal(int amount)
    {
        // ��_�ͩR�ȡA�����W�L�̤j�ͩR��
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Player healed! Current health: " + currentHealth);
    }
}
