using UnityEngine;

public class FootstepManager : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioSource footstepSource;
    public AudioClip[] footstepSounds; // Danh sách các tiếng bước chân để tránh lặp lại nhàm chán
    public float stepInterval = 0.5f;  // Thời gian giữa các bước chân

    private float nextStepTime;
    private CharacterController controller; // Hoặc Rigidbody tùy thuộc vào cách bạn di chuyển

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Kiểm tra nếu nhân vật đang di chuyển trên mặt đất
        if (controller.isGrounded && controller.velocity.magnitude > 0.2f && Time.time > nextStepTime)
        {
            PlayFootstep();
            nextStepTime = Time.time + stepInterval;
        }
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length > 0)
        {
            // Chọn ngẫu nhiên một âm thanh trong danh sách
            int index = Random.Range(0, footstepSounds.Length);
            footstepSource.PlayOneShot(footstepSounds[index]);
        }
    }
}