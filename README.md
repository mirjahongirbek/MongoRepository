# MongoRepository
Mopngo Repostry Project For Operation CRUD Oprations
# Use MongoRepository
* [nuget](https://www.nuget.org/packages/Joha.MongoDbRepository/) - nuget package
# Entity 

```csharp

public class SomeEntity:IEntity{
  public string Id{get; set;}
}
```
# Use in Service
```csharp 

public class SomeService<Some>:GenericRepository<SomeEntity>, IMongoRepository<SomeRepsitory>
{
  public void OtherMethods();
}
```
