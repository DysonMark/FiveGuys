using Kandooz.InteractionSystem.Animations;
using Kandooz.InteractionSystem.Interactions;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Kandooz.InteractionSystem.Core
{
    public enum InteractionSystemType
    {
        TransformBased,
        PhysicsBased
    }

    public class CameraRig : MonoBehaviour
    {
        [SerializeField] private Config config;
        [SerializeField] [HideInInspector] private bool initializeHands = true;
        [SerializeField] [HideInInspector] private InteractionSystemType handTrackingMethod = InteractionSystemType.PhysicsBased;
        [SerializeField] [HideInInspector] private Transform leftHandPivot;
        [SerializeField] [HideInInspector] private Transform rightHandPivot;
        [SerializeField] [HideInInspector] private bool initializeLayers;
        [SerializeField] private Transform offsetObject;
        private HandPoseController _leftPoseController, _rightPoseController;
        public HandPoseController LeftHandPrefab => config.HandData.LeftHandPrefab;
        public HandPoseController RightHandPrefab => config.HandData.RightHandPrefab;
        public Config Config => config;

        private void Awake()
        {
            CreateAndItializeHands();
            InitializeLayers();
        }

        private void InitializeLayers()
        {
            if (!initializeLayers) return;

            ChangeLayerRecursive(transform, config.PlayerLayer);
            ChangeLayerRecursive(leftHandPivot, config.LeftHandLayer);
            ChangeLayerRecursive(rightHandPivot, config.RightHandLayer);
        }

        private void CreateAndItializeHands()
        {
            if (!initializeHands) return;
            switch (handTrackingMethod)
            {
                case InteractionSystemType.TransformBased:
                    InitializeHands();
                    break;
                case InteractionSystemType.PhysicsBased:
                    InitializePhysicsBasedHands();
                    break;
            }
        }

        private static void ChangeLayerRecursive(Transform transform, int layer)
        {
            transform.gameObject.layer = layer;
            for (var i = 0; i < transform.childCount; i++) ChangeLayerRecursive(transform.GetChild(i), layer);
        }

        private void InitializePhysicsBasedHands()
        {
            InitializeHands();
            InitializePhysics(_rightPoseController.gameObject, rightHandPivot);
            InitializePhysics(_leftPoseController.gameObject, leftHandPivot);
        }

        private void InitializeHands()
        {
            _rightPoseController = InitializeHand(RightHandPrefab, rightHandPivot, HandIdentifier.Right);
            _leftPoseController = InitializeHand(LeftHandPrefab, leftHandPivot, HandIdentifier.Left);
        }

        private void InitializePhysics(GameObject hand, Transform target)
        {
            var rb = hand.GetComponent<Rigidbody>();
            if (rb == null) rb = hand.AddComponent<Rigidbody>();
            rb.mass = config.HandMass;
            rb.drag = config.HandLinearDamping;
            rb.angularDrag = config.HandAngularDamping;
            var follower = hand.AddComponent<PhysicsHandFollwer>();
            follower.Target = target;
        }

        private HandPoseController InitializeHand(HandPoseController handPrefab, Transform handPivot, HandIdentifier handIdentifier)
        {
            var hand = Instantiate(handPrefab, handPivot);
            var handTransform = hand.transform;
            handTransform.localPosition = Vector3.zero;
            handTransform.localRotation = Quaternion.identity;
            var handGameObject = hand.gameObject;
            var handController = handGameObject.GetComponent<Hand>();
            handController ??= handGameObject.AddComponent<Hand>();
            handController.HandIdentifier = handIdentifier;
            handController.Config = config;
            handGameObject.AddComponent<TriggerInteractor>();
            return hand;
        }
        public void ResetPosition()
        {
            Debug.Log("helo");
            var direction = transform.position - Camera.main.transform.position;
            direction.y = 0;
            offsetObject.position = direction;
            
        }
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ResetPosition();
            }
        }
        public void OnTrackingStateChanged(CallbackContext ctx )
        {
            var i=ctx.ReadValue<int>();
            Debug.Log(i);

        }

    }
}