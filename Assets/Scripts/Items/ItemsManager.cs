namespace AFSInterview.Items
{
    using UnityEngine;

    public class ItemsManager : MonoBehaviour
    {
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private int itemSellMaxValue;
        [SerializeField] private Transform itemSpawnParent;
        [SerializeField] private GameObject itemPrefab;
        [SerializeField] private GameObject consumableItemPrefab;
        [SerializeField] private BoxCollider itemSpawnArea;
        [SerializeField] private float itemSpawnInterval;

        private float nextItemSpawnTime;
        private int itemLayerMask;

        private void OnEnable()
        {
            itemLayerMask = LayerMask.GetMask("Item");
        }


        private void Update()
        {
            if (Time.time >= nextItemSpawnTime)
                SpawnNewItem();

            if (Input.GetMouseButtonDown(0))
                TryPickUpItem();

            if (Input.GetKeyDown(KeyCode.Space))
                inventoryController.SellAllItemsUpToValue(itemSellMaxValue);

            if (Input.GetKeyDown(KeyCode.C))
                inventoryController.UseAllConsumables();

        }

        private void SpawnNewItem()
        {
            var prefab = Random.Range(0, 2) == 0 ? itemPrefab : consumableItemPrefab;
            nextItemSpawnTime = Time.time + itemSpawnInterval;
            var position = GetRandomSpawnPositionInBounds(itemSpawnArea.bounds);

            Instantiate(prefab, position, Quaternion.identity, itemSpawnParent);
        }

        private void TryPickUpItem()
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit, 100f, itemLayerMask) || !hit.collider.TryGetComponent<IItemHolder>(out var itemHolder))
                return;

            var item = itemHolder.GetItem(true);
            inventoryController.AddItem(item);
            Debug.Log("Picked up " + item.Name + " with value of " + item.Value + " and now have " + inventoryController.ItemsCount + " items");
        }

        private Vector3 GetRandomSpawnPositionInBounds(Bounds bounds)
        {
            return new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                0f,
                Random.Range(bounds.min.z, bounds.max.z)
            );
        }

    }
}