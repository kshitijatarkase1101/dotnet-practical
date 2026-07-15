namespace StationeryStoreManagement
{
    public interface IBill
    {
        void GenerateBill(StationeryItem item, int quantity);
    }
}