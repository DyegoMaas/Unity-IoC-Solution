public interface INumberGenerator
{
    int Min { get; set; }
    int Max { get; set; }
    int GenerateNumberOfCubes();
}