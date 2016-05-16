using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCD.BL.Utils
{
    public class EnumType
    {
        public readonly int lenght;
        public readonly string name;
        public readonly string creationDate;

        public static readonly EnumType listOfMetadataForTxt = new EnumType(10, "lenght", "2016-05-15"); //new List<EnumType>;

        public EnumType(int lenghtMetadata, string nameMetadata, string creationDateMetadata)
        {
            lenght = lenghtMetadata;
            name = nameMetadata;
            creationDate = creationDateMetadata;
        }

        public static IEnumerable<EnumType> Values
        {
            get {
                yield return listOfMetadataForTxt;
            }
        }
    }

}
