using NUnit.Framework;

namespace AniListNet.Tests;

public class GetTests
{

    private readonly AniClient _client = new();

    [Test]
    public async Task GetGenreCollection()
    {
        var data = await _client.GetGenreCollection();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    public async Task GetMediaTagCollection()
    {
        var data = await _client.GetMediaTagCollection();
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(1)]
    public async Task GetCharacterTest(int id)
    {
        var data = await _client.GetCharacterAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(95269)]
    public async Task GetStaffTest(int id)
    {
        var data = await _client.GetStaffAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

    [Test]
    [TestCase(5741649)]
    public async Task GetUserTest(int id)
    {
        var data = await _client.GetUserAsync(id);
        Console.WriteLine(ObjectDumper.Dump(data));
        Assert.Pass();
    }

}