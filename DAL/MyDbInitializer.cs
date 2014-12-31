public class MyDbInitializer : CreateDatabaseIfNotExists<MyDbContext>
{
  protected override void Seed(MyDbContext context)
  {
    // create 1 user
    context.Users.Add(new Users {Name="Rogério R. Alcantara", UserName="roalcantara", Password="qazwsx" });
    base.Seed(context);
  }
}