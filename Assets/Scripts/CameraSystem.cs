using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public float moveSpeed;


    // Update is called once per frame
    void Update()
    {
        Vector3 inputDir = new Vector3(0, 0, 0);
        
        if(transform.position.x>=-24){
            if (Input.GetKey(KeyCode.A)) inputDir.x = -1f;
            if(Input.mousePosition.x <Screen.width*0.05) inputDir.x += -1f;
            
        }
        
        if(transform.position.x<=24){
            if (Input.GetKey(KeyCode.D)) inputDir.x = +1f;
            if(Input.mousePosition.x >Screen.width*0.95) inputDir.x += 1f;
        }

        Vector3 moveDir = transform.forward *inputDir.z + transform.right * inputDir.x;

        transform.position += Time.deltaTime* moveSpeed * moveDir ;
        
        




    }
}
