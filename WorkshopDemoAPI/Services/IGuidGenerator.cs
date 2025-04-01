namespace WorkshopDemoAPI.Services;

public interface IGuidGenerator
{
    Guid Value { get; }
}

public interface IGuidGeneratorSingleton : IGuidGenerator { }
public interface IGuidGeneratorScoped : IGuidGenerator { }
public interface IGuidGeneratorTransient : IGuidGenerator { }


public class GuidGenerator : IGuidGeneratorSingleton, IGuidGeneratorScoped, IGuidGeneratorTransient
{
    public Guid Value { get; } = Guid.NewGuid();
}