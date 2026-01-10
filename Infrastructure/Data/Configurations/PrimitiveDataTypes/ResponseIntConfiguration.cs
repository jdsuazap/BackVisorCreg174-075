using Core.ModelResponse;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations.PrimitiveDataTypes
{
    public class ResponseIntConfiguration : IEntityTypeConfiguration<ResponseInt>
    {
        public void Configure(EntityTypeBuilder<ResponseInt> builder)
        {
            builder.HasNoKey();
        }
    }
}
