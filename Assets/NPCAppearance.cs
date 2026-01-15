using UnityEngine;

public class NPCAppearance : MonoBehaviour
{
    public BoxCollider colliderBan;
    void Awake()
    {
        //
    }
    void OnEnable()
    {
        CheckStatus();
    }

    public void CheckStatus()
    {
        int isFinished = PlayerPrefs.GetInt("PuzzleFinished", 0);

        colliderBan.enabled = !(isFinished == 1);

        if (isFinished == 1)
        {
            gameObject.SetActive(true);
            Debug.Log("Flag nhận diện: Đã thắng! Hiện Ông Nội.");
        }
        else
        {
            gameObject.SetActive(false);
            Debug.Log("Flag nhận diện: Chưa thắng. Ẩn Ông Nội.");
        }
    }
}