using System.Text.Json;
using Domain.models;

namespace FileData;

public class FileContext
{
	private const string FilePath = "data.json";

	private DataContainer? _dataContainer;

	public ICollection<User>? Users
	{
		get
		{
			LazyLoadData();
			return _dataContainer?.Users;
		}
	}

	public ICollection<Post>? Posts
	{
		get
		{
			LazyLoadData();
			return _dataContainer?.Posts;
		}
	}
	private void LazyLoadData()
	{
		if (_dataContainer != null) return;

		if (!File.Exists(FilePath))
		{
			_dataContainer = new ()
			{
				Posts = new List<Post>(),
				Users = new List<User>()
			};
			return;
		}
		string content = File.ReadAllText(FilePath);
		_dataContainer = JsonSerializer.Deserialize<DataContainer>(content);
	}


	public void SaveChanges()
	{
		string serialized = JsonSerializer.Serialize(_dataContainer, new JsonSerializerOptions { WriteIndented = true});
		File.WriteAllText(FilePath, serialized);
		_dataContainer = null;
	}
}
