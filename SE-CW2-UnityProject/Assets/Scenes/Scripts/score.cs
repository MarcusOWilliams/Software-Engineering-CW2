using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{

    public Transform character;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = character.position.x.ToString("0");
    }
}
