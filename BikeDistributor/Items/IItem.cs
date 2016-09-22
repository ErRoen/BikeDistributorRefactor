namespace BikeDistributor.Library.Items
{
	public interface IItem
	{
		string Brand { get; }
		string Model { get; }
		decimal Price { get; }
		// Any future useful values...
	}
}