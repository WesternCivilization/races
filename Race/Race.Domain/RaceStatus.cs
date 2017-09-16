using System.ComponentModel;

namespace Race.Domain
{
    public enum RaceStatus
    {
        [Description("Unknown")]
        Unknown,

        [Description("Pending")]
        Pending,

        [Description("In Progress")]
        InProgress,

        [Description("Completed")]
        Completed
    }
}
