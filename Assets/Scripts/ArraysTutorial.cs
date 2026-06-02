using UnityEngine;

public class ArraysTutorial : MonoBehaviour
{
    string[] languages;
    private void Start()
    {
        languages = new string[5];

        languages[4] = "c#";

        print(languages[4]);
    }
}
