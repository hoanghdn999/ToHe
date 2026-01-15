using UnityEngine;
using UnityEngine.SceneManagement;

public class ChuyenCanh : MonoBehaviour
{
    // Đổi tên biến thành "tenSceneTiepTheo" cho dễ hiểu
    public string tenSceneTiepTheo; 

    void OnEnable() 
    {
        SceneManager.LoadScene(tenSceneTiepTheo);
    }
}