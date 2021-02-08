using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPLogistics.Common.Model
{
    [Index(nameof(Name))]
    public class LocalizedString
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Name { get; init; }

        [Required]
        public string ZHCN { get; init; }

        [Required]
        public string ENUS { get; init; }

        [Required]
        public string FRFR { get; init; }

        [NotMapped]
        public string Localized
        {
            get
            {
                var culture = CultureInfo.CurrentCulture;
                if (culture.Equals(CultureInfo.GetCultureInfoByIetfLanguageTag("zh-CN")))
                {
                    return ZHCN;
                }
                else if (culture.Equals(CultureInfo.GetCultureInfoByIetfLanguageTag("en-US")))
                {
                    return ENUS;
                }
                else if (culture.Equals(CultureInfo.GetCultureInfoByIetfLanguageTag("fr-FR")))
                {
                    return FRFR;
                }
                else
                {
                    return Name;
                }
            }
        }

        public LocalizedString(/*int iD, */string name, string zHCN, string eNUS, string fRFR)
        {
            Name = name;
            ZHCN = zHCN;
            ENUS = eNUS;
            FRFR = fRFR;
        }
    }
}
