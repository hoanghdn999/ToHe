using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PuzzleWinManager : MonoBehaviour
{
    public static PuzzleWinManager Instance;
    public int totalPieces;
    private int placedPieces = 0;

    public GameObject winImage;
    public float winDelay = 2.5f;

    public static System.Action onCompletePuzzle;

    void Awake()
    {
        Instance = this;
        winImage.SetActive(false);
    }

    public void PiecePlaced()
    {
        placedPieces++;
        if (placedPieces >= totalPieces)
        {
            StartCoroutine(WinSequence());
        }
    }

    IEnumerator WinSequence()
    {
        // 1. Đặt Flag chiến thắng
        PlayerPrefs.SetInt("PuzzleFinished", 1);
        PlayerPrefs.Save(); // Đảm bảo dữ liệu được ghi xuống đĩa ngay lập tức
        Debug.Log("Đã lưu cờ chiến thắng Puzzle!");
        // 2. Hiển thị hiệu ứng Win
        winImage.SetActive(true);
        winImage.transform.localScale = Vector3.zero;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime * 2f;
            winImage.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, t);
            yield return null;
        }

        yield return new WaitForSeconds(winDelay);

        // 3. Tải cảnh SampleScene nơi có Ông Nội
        SceneManager.LoadScene("SampleScene");
    }
}