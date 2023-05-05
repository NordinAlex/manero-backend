using Microsoft.AspNetCore.Mvc;

namespace Manero_backend.Factories;

public class StatusFactory<T> where T : IActionResult, new()
{
    public static T Create() => new();
}
