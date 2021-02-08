using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DSPLogistics.Common.Model
{
    public class Item
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; init; }

        [Required]
        public string NameID { get; init; }

        public LocalizedString? Name { get; set; }

        [Required]
        public string IconPath { get; init; }

        [Required]
        public int GridIndex { get; init; }

        [Required]
        public string DescriptionID { get; init; }

        public LocalizedString? Description { get; set; }

        public Item(int iD, LocalizedString name, string iconPath, int gridIndex, LocalizedString description)
        {
            ID = iD;
            NameID = name.Name;
            Name = name;
            IconPath = iconPath;
            GridIndex = gridIndex;
            DescriptionID = description.Name;
            Description = description;
        }

        public Item(int iD, string nameID, string iconPath, int gridIndex, string descriptionID)
        {
            ID = iD;
            NameID = nameID;
            IconPath = iconPath;
            GridIndex = gridIndex;
            DescriptionID = descriptionID;
        }
    }
}
