using UnityEngine;

public class JournalFromPuzzle : MonoBehaviour
{
    public GameObject journalImage;
    private bool isShowing = false;

    void Start()
    {
        // Nếu puzzle chưa xong → không làm gì cả
        if (PlayerPrefs.GetInt("PuzzleFinished", 0) == 1)
        {
            ShowJournal();
            PlayerPrefs.SetInt("PuzzleFinished", 0); // reset cờ
        }
    }

    void Update()
    {
        if (isShowing && Input.GetKeyDown(KeyCode.Space))
        {
            HideJournal();
        }
    }

    void ShowJournal()
    {
        journalImage.SetActive(true);
        isShowing = true;

        // Khóa chuột / input nếu cần
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void HideJournal()
    {
        journalImage.SetActive(false);
        isShowing = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
