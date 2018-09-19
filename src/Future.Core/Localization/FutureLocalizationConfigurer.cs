using Majid.Configuration.Startup;
using Majid.Localization.Dictionaries;
using Majid.Localization.Dictionaries.Xml;
using Majid.Reflection.Extensions;

namespace Future.Localization
{
    public static class FutureLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(FutureConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(FutureLocalizationConfigurer).GetAssembly(),
                        "Future.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
