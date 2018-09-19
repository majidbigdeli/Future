using Majid.Application.Editions;
using Majid.Application.Features;
using Majid.Domain.Repositories;

namespace Future.Editions
{
    public class EditionManager : MajidEditionManager
    {
        public const string DefaultEditionName = "Standard";

        public EditionManager(
            IRepository<Edition> editionRepository, 
            IMajidZeroFeatureValueStore featureValueStore)
            : base(
                editionRepository,
                featureValueStore)
        {
        }
    }
}
