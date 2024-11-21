using UnityEngine;

namespace YHBGAME.YHB_Mono
{
    
    
    public class RotationCamera : MonoBehaviour
    {
        
        [Header("The game object to surround")]
        public Transform TargetLookAt = null;

        [Header("The initial distance between the camera and the target point")]
        public float InitDistance = 10.0f;

        [Header("Mouse wheel zoom zooms in and zooms out the minimum distance of the camera's perspective")]
        public float MinMouseWheelDistance = 5.0f;
        [Header("Mouse wheel zoom zooms in and out the maximum distance of the camera angle")]
        public float MaxMouseWheelDistance = 15.0f;

        [Header("Mouse X-axis sensitivity")]
        public float MouseXSensitivity = 5.0f;
        [Header("Mouse Y-axis sensitivity")]
        public float MouseYSensitivity = 5.0f;
        [Header("Mouse wheel sensitivity")]
        public float MouseWheelSensitivity = 5.0f;

        [Header("Linear interpolation component of X-axis smooth movement")]
        public float SmoothLerpX = 0.05f;
        [Header("Linear interpolation component of Y-axis smooth movement")]
        public float SmoothLerpY = 0.1f;
        [Header("Smooth interpolated component of distance")]
        public float SmoothLerpDistance = 0.025f;

        [Header("Look at the smallest position of the Y-axis")]
        public float MinLimitY = 15.0f;
        [Header("Look at the maximum position of the Y-axis")]
        public float MaxLimitY = 70.0f;
       

  
        private float startingDistance = 0.0f;
        private float desiredDistance = 0.0f;
        private float mouseX = 0.0f;
        private float mouseY = 0.0f;
        private float velocityDistance = 0.0f;
        private float velX = 0.0f;
        private float velY = 0.0f;
        private float velZ = 0.0f;
        private Vector3 desiredPosition = Vector3.zero;
        private Vector3 position = Vector3.zero;
        

        
        void Start()
        {
            InitDistance = Vector3.Distance(TargetLookAt.transform.position, gameObject.transform.position);

            if (InitDistance > MaxMouseWheelDistance)
            {
                MaxMouseWheelDistance = InitDistance;
            }

            startingDistance = InitDistance;
            Reset();
        }
       

       
        void LateUpdate()
        {
            if (TargetLookAt == null)
            {
                return;
            }

            HandlePlayerInput();
            CalculateDesiredPosition();
            UpdatePosition();
        }
        

       
        private void HandlePlayerInput()
        {
            float deadZone = 0.01f;

            if (Input.GetMouseButton(0))
            {
                mouseX += Input.GetAxis("Mouse X") * MouseXSensitivity;
                mouseY -= Input.GetAxis("Mouse Y") * MouseYSensitivity;
            }

            mouseY = ClampAngle(mouseY, MinLimitY, MaxLimitY);

            
            if (Input.GetAxis("Mouse ScrollWheel") < -deadZone || Input.GetAxis("Mouse ScrollWheel") > deadZone)
            {
                desiredDistance = Mathf.Clamp(InitDistance - (Input.GetAxis("Mouse ScrollWheel") * MouseWheelSensitivity), MinMouseWheelDistance, MaxMouseWheelDistance);
            }
        }
        

       

        
        private void CalculateDesiredPosition()
        {
            InitDistance = Mathf.SmoothDamp(InitDistance, desiredDistance, ref velocityDistance, SmoothLerpDistance);

            
            desiredPosition = CalculatePosition(mouseY, mouseX, InitDistance);
        }
       

        
        private Vector3 CalculatePosition(float rotationX, float rotationY, float distance)
        {
            Vector3 direction = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
            return TargetLookAt.position + (rotation * direction);
        }
       

       
        private void UpdatePosition()
        {
            float posX = Mathf.SmoothDamp(position.x, desiredPosition.x, ref velX, SmoothLerpX);
            float posY = Mathf.SmoothDamp(position.y, desiredPosition.y, ref velY, SmoothLerpY);
            float posZ = Mathf.SmoothDamp(position.z, desiredPosition.z, ref velZ, SmoothLerpX);
            position = new Vector3(posX, posY, posZ);
            transform.position = position;
            transform.LookAt(TargetLookAt);
        }
        

        
        private void Reset()
        {
            mouseX = 0;
            mouseY = 0;
            InitDistance = startingDistance;
            desiredDistance = InitDistance;
        }
       

       
        private float ClampAngle(float angle, float min, float max)
        {
            while (angle < -360.0f || angle > 360.0f)
            {
                if (angle < -360.0f)
                {
                    angle += 360.0f;
                }

                if (angle > 360.0f)
                {
                    angle -= 360.0f;
                }
            }

            return Mathf.Clamp(angle, min, max);
        }
      

        
    }
}