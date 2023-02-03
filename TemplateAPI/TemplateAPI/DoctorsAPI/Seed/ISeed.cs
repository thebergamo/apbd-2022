using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorsAPI.Seed;

public interface ISeed<TModel> where TModel : class
{
    public static abstract void Seed(EntityTypeBuilder<TModel> build);

}