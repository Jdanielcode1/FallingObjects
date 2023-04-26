using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FloorCollider : MonoBehaviour
{
    public static FloorCollider instanciar;
    public int collidedCount = 0;
    public TextMeshProUGUI pointsText;

    private void Awake()
    {
        instanciar = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collidedCount++;
            UpdatePointsText();
            

        }
    }

    private void UpdatePointsText()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points:   " + collidedCount;
        } 
    }

    public void LogCount()
    {
        Debug.Log("Points: " + collidedCount);
    }

   

}