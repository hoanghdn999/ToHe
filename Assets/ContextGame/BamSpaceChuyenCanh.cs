using UnityEngine;
using UnityEngine.SceneManagement;

public class BamSpaceChuyenCanh : MonoBehaviour
{
    public string tenSceneTiepTheo = "SampleScene"; // Tên màn chơi game

    void Update()
    {
        // Kiểm tra nếu phím Space được bấm
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChuyenCanhNgay();
        }
    }

    // Hàm này để gọi khi bấm nút (nếu muốn dùng cả chuột)
    public void ChuyenCanhNgay()
    {
        SceneManager.LoadScene(tenSceneTiepTheo);
    }
}