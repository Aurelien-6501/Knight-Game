using UnityEngine;
using UnityEngine.UI;

public class PrincessHealthUI : MonoBehaviour
{
    public GameObject heartPrefab;
    public Transform heartContainer;
    public int maxHearts = 5;
    private int currentHearts;

    public void SetHearts(int health)
    {
        foreach (Transform child in heartContainer)
        {
            Destroy(child.gameObject);
        }

        currentHearts = health;
        for (int i = 0; i < currentHearts; i++)
        {
            Instantiate(heartPrefab, heartContainer);
        }
    }
}