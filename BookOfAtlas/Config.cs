using BepInEx.Configuration;

namespace BookOfAtlas
{
    public class Config
    {
        public static ConfigEntry<int> SerpensSpawnWeight;
        public static ConfigEntry<float> SerpensSpawnPower;
        public static ConfigEntry<int> SerpensSpawnMax;
        public static ConfigEntry<string> SerpensSpawnLevelsSet;
        public static ConfigEntry<string> SerpensSpawnLevelsWithWeight;
        public static ConfigEntry<float> SerpensVolumeAdjustment;
        public static ConfigEntry<float> SerpensMechanicsReactivationChance;

        public static void Load()
        {
            SerpensMechanicsReactivationChance = Plugin.config.Bind(
                "Mechanics",
                "SerpensMechanicsReactivationChance",
                50f,
                new ConfigDescription(
                    "Chance for the Serpens to reactivate after a chase and begin another lunge at the closest player (rolls a value 0-100 and if below the given value will reactivate)"
                )
            );

            SerpensSpawnWeight = Plugin.config.Bind(
                "Spawn",
                "SerpensSpawnWeight",
                50,
                new ConfigDescription(
                    "What is the chance of the Serpens spawning - higher values make it more common (this is like adding tickets to a lottery - it doesn't guarantee getting picked but it vastly increases the chances)",
                    new AcceptableValueRange<int>(0, 99999)
                )
            );
            SerpensSpawnPower = Plugin.config.Bind(
                "Spawn",
                "SerpensSpawnPower",
                1f,
                new ConfigDescription(
                    "What's the spawn power of a Serpens? How much does it subtract from the moon power pool on spawn?"
                )
            );
            SerpensSpawnMax = Plugin.config.Bind(
                "Spawn",
                "SerpensSpawnMax",
                3,
                new ConfigDescription(
                    "What's the maximum amount of Serpens that can spawn on a given moon?"
                )
            );
            SerpensSpawnLevelsSet = Plugin.config.Bind(
                "Spawn",
                "SerpensSpawnLevelsSet",
                "all",
                new ConfigDescription(
                    "Which set of levels should by default let the Locker spawn on them? (Options are: all/none/modded/vanilla)"
                )
            );
            SerpensSpawnLevelsWithWeight = Plugin.config.Bind(
                "Spawn",
                "SerpensSpawnLevels",
                "experimentation:25, assurance:75, vow:0, march:0, offense:100",
                new ConfigDescription(
                    "Which specific moons/levels can the Serpens spawn on and with what weight? (This takes priority over the level set config option - names are matched leniently and case insensitive)"
                )
            );

            SerpensVolumeAdjustment = Plugin.config.Bind(
                "Volume",
                "SerpensVolumeAdjustment",
                1.0f,
                new ConfigDescription(
                    "Client side volume adjustment - values are a percentage i.e. 50% volume is 0.5"
                )
            );
        }
    }
}
