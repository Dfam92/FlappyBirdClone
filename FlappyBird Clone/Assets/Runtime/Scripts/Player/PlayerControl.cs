using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] PlayerControlAnim playerAnim;
    [SerializeField] AudioManager playerAudio;

    [SerializeField] AudioClip playerFlapAudio;
    
    [Header("Player Movement")]
    [SerializeField] private float playerSpeed;
    [SerializeField] private float distanceMaxY;
    [SerializeField] private float distanceMinY;
    [SerializeField] private float flyUpForce;
    [SerializeField] private float fallDownForce;
    [Header("Player Rotation")]
    [SerializeField] private float rotationUpForce;
    [SerializeField] private float rotationDownForce;
    [SerializeField] private float angleRotationUp;
    [SerializeField] private float angleRotationDown;
    [SerializeField] private Vector3 startPos;
    private void Awake()
    {
        startPos = transform.position;
    }
    // Update is called once per frame
    void Update()
    {   
       PlayerInputs();
    }

    #region Movimentation
    private void PlayerInputs()
    {

        Vector3 position = transform.position;
        Quaternion rotation = transform.rotation;


        position.x = PlayerMovimentation();
        if (Input.GetKeyDown(KeyCode.W))
        {
            position.y += PlayerMoveUp();
            rotation.z = PlayerRotationUp();
            playerAnim.FlapWings();
            playerAudio.PlayAudio(playerFlapAudio);
        }
        else
        {
            position.y = PlayerMoveDown();
            rotation.z = PlayerRotationDown();
            playerAnim.StopFlapWing();
        }

        transform.position = position;
        transform.rotation = rotation;
    }
    private float PlayerMovimentation()
    {

        return transform.position.x + playerSpeed * Time.deltaTime;
    }
    private float PlayerMoveUp()
    {
        return Mathf.Lerp(startPos.y, distanceMaxY, Time.deltaTime * flyUpForce);

    }
    private float PlayerMoveDown()
    {
        return Mathf.Lerp(transform.position.y, -distanceMinY, Time.deltaTime * fallDownForce);
    }
    private float PlayerRotationUp()
    {
        return Mathf.Lerp(transform.rotation.z, angleRotationUp, Time.deltaTime * rotationUpForce);
    }
    private float PlayerRotationDown()
    {
        return Mathf.Lerp(transform.rotation.z, angleRotationDown, Time.deltaTime * rotationDownForce);
    }
    #endregion
}

